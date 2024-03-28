using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;

using CaluireMobile._0.Models;
using CaluireMobile._0.Models.Datas;
using caluireMobile.Models.Dtos;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsService _service;
        private readonly IMapper _mapper;

        public ClientsController(ClientsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Clients
        // ...

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

        // ...

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, ClientDtoIn clientDtoIn)
        {
            var client = _mapper.Map<Client>(clientDtoIn);
            _service.UpdateClient(id, client);
            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        [HttpPost]
        public ActionResult<ClientDtoOut> CreateClient(ClientDtoIn clientDtoIn)
        {
            var client = _mapper.Map<Client>(clientDtoIn);
            _service.AddClient(client);
            return CreatedAtAction(nameof(GetClient), new { id = client.IdClient }, _mapper.Map<ClientDtoOut>(client));
        }
        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            _service.DeleteClient(id);
            return NoContent();
        }
    }
}