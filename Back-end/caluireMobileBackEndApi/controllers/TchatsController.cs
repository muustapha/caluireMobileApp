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
    public class TchatsController : ControllerBase
    {
        private readonly TchatsService _service;
        private readonly IMapper _mapper;

        public TchatsController(TchatsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TchatDto>> GetAllTchats()
        {
            var tchats = _service.GetAllTchats();
            return Ok(_mapper.Map<IEnumerable<TchatDto>>(tchats));
        }

        [HttpGet("{id}", Name = "GetTchatById")]
        public ActionResult<TchatDto> GetTchatById(int id)
        {
            var tchat = _service.GetTchatById(id);
            if (tchat == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TchatDto>(tchat));
        }

        [HttpPost]
        public ActionResult<TchatDto> AddTchat(TchatCreateDto tchatCreateDto)
        {
            var tchatModel = _mapper.Map<Tchat>(tchatCreateDto);
            _service.AddTchat(tchatModel);
            return CreatedAtRoute(nameof(GetTchatById), new { Id = tchatModel.Id }, _mapper.Map<TchatDto>(tchatModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTchat(int id, TchatUpdateDto tchatUpdateDto)
        {
            var tchatModelFromRepo = _service.GetTchatById(id);
            if (tchatModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(tchatUpdateDto, tchatModelFromRepo);
            _service.UpdateTchat(tchatModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTchatUpdate(int id, JsonPatchDocument<TchatUpdateDto> patchDoc)
        {
            var tchatModelFromRepo = _service.GetTchatById(id);
            if (tchatModelFromRepo == null)
            {
                return NotFound();
            }
            var tchatToPatch = _mapper.Map<TchatUpdateDto>(tchatModelFromRepo);
            patchDoc.ApplyTo(tchatToPatch, ModelState);
            if (!TryValidateModel(tchatToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(tchatToPatch, tchatModelFromRepo);
            _service.UpdateTchat(tchatModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTchat(int id)
        {
            var tchatModelFromRepo = _service.GetTchatById(id);
            if (tchatModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTchat(id);
            return NoContent();
        }
    }
}