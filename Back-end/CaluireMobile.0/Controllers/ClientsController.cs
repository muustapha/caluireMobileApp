using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile._0.Models.Dtos;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaluireMobile._0.Models.IService;
using CaluireMobile._0.Models.Dtos;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _service;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IEmailService _emailService;

        public ClientsController(IClientsService service, IMapper mapper, IMemoryCache memoryCache, IEmailService emailService)
        {
            _service = service;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _emailService = emailService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.AdresseMail) || string.IsNullOrEmpty(model.MotDePasse))
            {
                return BadRequest(new { success = false, message = "Adresse mail et mot de passe requis." });
            }

            var client = await _service.GetClientByAdresseMailAsync(model.AdresseMail);
            if (client == null)
            {
                return NotFound(new { success = false, message = "Utilisateur non trouvé." });
            }

            if (!VerifyPassword(model.MotDePasse, client.MotDePasse ?? string.Empty))
            {
                return Unauthorized(new { success = false, message = "Mot de passe incorrect." });
            }

            return Ok(new { success = true, message = "Connexion réussie.", clientId = client.IdClient });
        }

        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            return enteredPassword == storedPasswordHash; // Exemple simpliste, utilisez un meilleur hachage dans la pratique
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDtoOut>>> GetClients()
        {
            var clients = await _service.GetAllClientsAsync();
            return Ok(_mapper.Map<IEnumerable<ClientDtoOut>>(clients));
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDtoAvecrendezVousEtSocketios>> GetClient(int id)
        {
            var client = await _service.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ClientDtoAvecrendezVousEtSocketios>(client));
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientDtoIn clientDtoIn)
        {
            if (clientDtoIn == null)
            {
                return BadRequest("ClientDtoIn ne peut pas être null.");
            }

            var clientInDb = await _service.GetClientByIdAsync(id);
            if (clientInDb == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(clientDtoIn.AdresseMail))
                clientInDb.AdresseMail = clientDtoIn.AdresseMail;
            if (!string.IsNullOrWhiteSpace(clientDtoIn.MotDePasse))
                clientInDb.MotDePasse = clientDtoIn.MotDePasse;

            await _service.UpdateClientAsync(id, clientInDb);

            var emailSubject = "Confirmation de mise à jour du profil";
            var emailBody = "Votre profil a été mis à jour avec succès.";
            try
            {
                if (!string.IsNullOrEmpty(clientInDb.AdresseMail))
                {
                    await _emailService.SendEmailAsync(clientInDb.AdresseMail, emailSubject, emailBody);
                    return Ok(new { success = true, message = "Profil mis à jour avec succès. Email de confirmation envoyé." });
                }
                else
                {
                    return Ok(new { success = true, message = "Profil mis à jour avec succès. L'adresse email est manquante, aucun email de confirmation envoyé." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Profil mis à jour, mais l'email n'a pas pu être envoyé. " + ex.Message });
            }
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<ClientDtoOut>> CreateClient(ClientDtoIn clientDtoIn)
        {
            if (clientDtoIn == null)
            {
                return BadRequest(new { success = false, message = "ClientDtoIn ne peut pas être null." });
            }

            var client = _mapper.Map<Client>(clientDtoIn);
            await _service.AddClientAsync(client);
            if (client.IdClient > 0)
            {
                return Ok(new { success = true, clientId = client.IdClient, client = _mapper.Map<ClientDtoOut>(client) });
            }
            else
            {
                return BadRequest(new { success = false, message = "Impossible de créer le client" });
            }
        }

        // POST: api/Clients/SendEmail/{id}
        [HttpPost("SendEmail/{id}")]
        public async Task<IActionResult> SendEmail(int id)
        {
            Console.WriteLine("SendEmail method called");

            try
            {
                var client = await _service.GetClientByIdAsync(id);
                if (client == null)
                {
                    return NotFound("Client not found");
                }

                var emailSubject = "Confirmation de mise à jour du profil";
                var emailBody = $"Cher {client.Nom}, votre profil a été mis à jour. Si vous n'avez pas demandé cette mise à jour, veuillez contacter le support.";

                if (string.IsNullOrEmpty(client.AdresseMail))
                {
                    return BadRequest(new { success = false, message = "Adresse email manquante." });
                }

                await _emailService.SendEmailAsync(client.AdresseMail, emailSubject, emailBody);

                return Ok(new { success = true, message = "Email de confirmation envoyé." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Erreur lors de l'envoi de l'email.", details = ex.Message });
            }
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _service.DeleteClientAsync(id);
            return NoContent();
        }

        // POST: api/Clients/Verify/{id}
        [HttpPost("Verify/{id}")]
        public async Task<IActionResult> VerifyClient(int id)
        {
            var client = await _service.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var verificationCode = GenerateVerificationCode();

            StoreVerificationCode(client.IdClient, verificationCode);

            if (string.IsNullOrEmpty(client.AdresseMail))
            {
                return BadRequest(new { success = false, message = "Adresse email manquante." });
            }

            await SendVerificationEmail(client.AdresseMail, verificationCode);

            return Ok(new { success = true, message = "Code de vérification envoyé avec succès." });
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void StoreVerificationCode(int clientId, string verificationCode)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _memoryCache.Set(clientId.ToString(), verificationCode, cacheEntryOptions);
        }

        private async Task SendVerificationEmail(string emailAddress, string verificationCode)
        {
            var subject = "Code de vérification";
            var body = $"Votre code de vérification est : {verificationCode}";
            await _emailService.SendEmailAsync(emailAddress, subject, body);
        }
    }
}
