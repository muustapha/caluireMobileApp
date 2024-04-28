using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile._0.Models.Dtos;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaluireMobile._0.Models.Dtos;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsService _service;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly EmailService _emailService; // Ajout du service d'e-mail

        public ClientsController(ClientsService service, IMapper mapper, IMemoryCache memoryCache, EmailService emailService)
        {
            _service = service;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _emailService = emailService;
        }

   [HttpPost("Login")]
public async Task<IActionResult> Login([FromBody] LoginModel model)
{
    var client = _service.GetClientByAdresseMail(model.AdresseMail);
    if (client == null)
    {
        return NotFound(new { success = false, message = "Utilisateur non trouvé." });
    }

    if (!VerifyPassword(model.MotDePasse, client.MotDePasse))
    {
        return Unauthorized(new { success = false, message = "Mot de passe incorrect." });
    }

    return Ok(new { success = true, message = "Connexion réussie.", clientId = client.IdClient });
}

    private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
    {
        // Implémentation du hachage de mot de passe à insérer ici, retourne true si le mot de passe correspond
        return enteredPassword == storedPasswordHash; // Exemple simpliste, utilisez un meilleur hachage dans la pratique
    }

        // GET: api/Clients
        [HttpGet]
        public ActionResult<IEnumerable<ClientDtoOut>> GetClients()
        {
            var clients = _service.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientDtoOut>>(clients));
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public ActionResult<ClientDtoAvecrendezVousEtSocketios> GetClient(int id)
        {
            var client = _service.GetClientById(id);
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
    var clientInDb = _service.GetClientById(id);
    if (clientInDb == null)
    {
        return NotFound();
    }

    // Mise à jour des champs du profil client
    if (!string.IsNullOrWhiteSpace(clientDtoIn.AdresseMail))
        clientInDb.AdresseMail = clientDtoIn.AdresseMail;
    if (!string.IsNullOrWhiteSpace(clientDtoIn.MotDePasse))
        clientInDb.MotDePasse = clientDtoIn.MotDePasse;

    _service.Save(); // Sauvegarder les modifications

    // Envoyer un email de confirmation
    var emailSubject = "Confirmation de mise à jour du profil";
    var emailBody = "Votre profil a été mis à jour avec succès.";
    try
    {
        await _emailService.SendEmailAsync(clientInDb.AdresseMail, emailSubject, emailBody);
        return Ok(new { success = true, message = "Profil mis à jour avec succès. Email de confirmation envoyé." });
    }
    catch (Exception ex)
    {
        // Log de l'exception ou gestion d'erreur
        return StatusCode(500, new { success = false, message = "Profil mis à jour, mais l'email n'a pas pu être envoyé. " + ex.Message });
    }
}

        // POST: api/Clients
        [HttpPost]
        public ActionResult<ClientDtoOut> CreateClient(ClientDtoIn clientDtoIn)
        {
            var client = _mapper.Map<Client>(clientDtoIn);
            _service.AddClient(client);
            if (client.IdClient > 0)
            {
                // Supposons que l'ID du client est correctement défini après l'ajout
                return Ok(new { success = true, clientId = client.IdClient, client = _mapper.Map<ClientDtoOut>(client) });
            }
            else
            {
                return BadRequest(new { success = false, message = "Impossible de créer le client" });
            }
        }
// POST: api/Clients/SendEmail
[HttpPost("SendEmail/{id}")]
public async Task<IActionResult> SendEmail(int id)
{     Console.WriteLine("SendEmail method called"); // Ajout du log

    try
    {
        var client = _service.GetClientById(id);
        if (client == null)
        {
            return NotFound("Client not found");
        }

        var emailSubject = "Confirmation de mise à jour du profil";
        var emailBody = $"Cher {client.Nom}, votre profil a été mis à jour. Si vous n'avez pas demandé cette mise à jour, veuillez contacter le support.";

        // Envoyer l'e-mail avec l'adresse e-mail du client
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
        public IActionResult DeleteClient(int id)
        {
            _service.DeleteClient(id);
            return NoContent();
        }

        // POST: api/Clients/Verify/{id}
        [HttpPost("Verify/{id}")]
        public async Task<IActionResult> VerifyClient(int id)
        {
            var client = _service.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            // Générer le code de vérification
            var verificationCode = GenerateVerificationCode();

            // Stocker le code de vérification
            StoreVerificationCode(client.IdClient, verificationCode);

            // Envoyer le code de vérification par e-mail
            await SendVerificationEmail(client.AdresseMail, verificationCode);

            // Retourner une réponse de succès
            return Ok(new { success = true, message = "Code de vérification envoyé avec succès." });
        }

        private string GenerateVerificationCode()
        {
            // Implémentation de la logique pour générer un code de vérification
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void StoreVerificationCode(int clientId, string verificationCode)
        {
            // Implémentation de la logique pour stocker le code de vérification
 var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)); // Expiration dans 5 minutes
            _memoryCache.Set(clientId.ToString(), verificationCode, cacheEntryOptions);        }

        private async Task SendVerificationEmail(string emailAddress, string verificationCode)
        {
            // Implémentation de la logique pour envoyer l'e-mail de vérification
  var subject = "Code de vérification";
            var body = $"Votre code de vérification est : {verificationCode}";
            await _emailService.SendEmailAsync(emailAddress, subject, body);        }
    }
    
}
