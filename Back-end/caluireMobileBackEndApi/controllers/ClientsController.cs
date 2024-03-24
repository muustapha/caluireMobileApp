using AutoMapper;
using caluireMobile.Models.Data;
using caluireMobile.Models.Services;
using caluireMobile.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace caluireMobile.Models.Controllers
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

        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> GetAllClients()
        {
            var clients = _service.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clients));
        }

        [HttpGet("{id}", Name = "GetClientById")]
        public ActionResult<ClientDto> GetClientById(int id)
        {
            var client = _service.GetClientbyId(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ClientDto>(client));
        }

        [HttpPost]
        public ActionResult<ClientDto> AddClient(ClientCreateDto clientCreateDto)
        {
            var clientModel = _mapper.Map<Client>(clientCreateDto);
            _service.AddClient(clientModel);
            return CreatedAtRoute(nameof(GetClientById), new { Id = clientModel.Id }, _mapper.Map<ClientDto>(clientModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id, ClientUpdateDto clientUpdateDto)
        {
            var clientModelFromRepo = _service.GetClientbyId(id);
            if (clientModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(clientUpdateDto, clientModelFromRepo);
            _service.UpdateClient(clientModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialClientUpdate(int id, JsonPatchDocument<ClientUpdateDto> patchDoc)
        {
            var clientModelFromRepo = _service.GetClientbyId(id);
            if (clientModelFromRepo == null)
            {
                return NotFound();
            }
            var clientToPatch = _mapper.Map<ClientUpdateDto>(clientModelFromRepo);
            patchDoc.ApplyTo(clientToPatch, ModelState);
            if (!TryValidateModel(clientToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(clientToPatch, clientModelFromRepo);
            _service.UpdateClient(clientModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            var clientModelFromRepo = _service.GetClientbyId(id);
            if (clientModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteClient(id);
            return NoContent();
        }
    }
}