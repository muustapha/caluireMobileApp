using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketiosController : ControllerBase
    {
        private readonly ISocketioServices _service;
        private readonly IMapper _mapper;

        public SocketiosController(ISocketioServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SocketioDtoOut>> GetAllSocketio()
        {
            var socketios = _service.GetAllSocketio();
            return Ok(_mapper.Map<IEnumerable<SocketioDtoOut>>(socketios));
        }

        [HttpGet("{id}", Name = "GetSocketioById")]
        public ActionResult<SocketioDtoAvecClientEtEmploye> GetSocketioById(int id)
        {
            var socketio = _service.GetSocketioById(id);
            if (socketio == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SocketioDtoAvecClientEtEmploye>(socketio));
        }

        [HttpPost]
        public ActionResult<SocketioDtoOut> AddSocketio(SocketioDtoIn socketioCreateDto)
        {
            var socketioModel = _mapper.Map<Socketio>(socketioCreateDto);
            _service.AddSocketio(socketioModel);
            return CreatedAtRoute(nameof(GetSocketioById), new { Id = socketioModel.IdSocketio }, _mapper.Map<SocketioDtoOut>(socketioModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSocketio(int id, SocketioDtoIn socketioUpdateDto)
        {
            var socketioModelFromRepo = _service.GetSocketioById(id);
            if (socketioModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(socketioUpdateDto, socketioModelFromRepo);
            _service.UpdateSocketio(socketioModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialSocketioUpdate(int id, JsonPatchDocument<SocketioDtoIn> patchDoc)
        {
            var socketioModelFromRepo = _service.GetSocketioById(id);
            if (socketioModelFromRepo == null)
            {
                return NotFound();
            }
            var socketioToPatch = _mapper.Map<SocketioDtoIn>(socketioModelFromRepo);
            patchDoc.ApplyTo(socketioToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("", err.ErrorMessage));

            if (!TryValidateModel(socketioToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(socketioToPatch, socketioModelFromRepo);
            _service.UpdateSocketio(socketioModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSocketio(int id)
        {
            var socketioModelFromRepo = _service.GetSocketioById(id);
            if (socketioModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteSocketio(id);
            return NoContent();
        }
    }
}