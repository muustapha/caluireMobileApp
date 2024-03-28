using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using CaluireMobile._0.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraitersController : ControllerBase
    {
        private readonly TraitersService _service;
        private readonly IMapper _mapper;

        public TraitersController(TraitersService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TraiterDtoOut>> GetAllTraiters()
        {
            var traiters = _service.GetAllTraiters();
            return Ok(_mapper.Map<IEnumerable<TraiterDtoOut>>(traiters));
        }

        [HttpGet("{id}", Name = "GetTraiterById")]
        public ActionResult<TraiterDtoAvecClientEtOperation> GetTraiterById(int id)
        {
            var traiter = _service.GetTraiterById(id);
            if (traiter == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TraiterDtoAvecClientEtOperation>(traiter));
        }

        [HttpPost]
        public ActionResult<TraiterDtoOut> AddTraiter(TraiterDtoIn traiterCreateDto)
        {
            var traiterModel = _mapper.Map<Traiter>(traiterCreateDto);
            _service.AddTraiter(traiterModel);
            return CreatedAtRoute(nameof(GetTraiterById), new { Id = traiterModel.Id }, _mapper.Map<TraiterDtoOut>(traiterModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTraiter(int id, TraiterDtoIn traiterUpdateDto)
        {
            var traiterModelFromRepo = _service.GetTraiterById(id);
            if (traiterModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(traiterUpdateDto, traiterModelFromRepo);
            _service.UpdateTraiter(traiterModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTraiterUpdate(int id, JsonPatchDocument<TraiterDtoIn> patchDoc)
        {
            var traiterModelFromRepo = _service.GetTraiterById(id);
            if (traiterModelFromRepo == null)
            {
                return NotFound();
            }
            var traiterToPatch = _mapper.Map<TraiterDtoIn>(traiterModelFromRepo);
            patchDoc.ApplyTo(traiterToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("", err.ErrorMessage));

            if (!TryValidateModel(traiterToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(traiterToPatch, traiterModelFromRepo);
            _service.UpdateTraiter(traiterModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTraiter(int id)
        {
            var traiterModelFromRepo = _service.GetTraiterById(id);
            if (traiterModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTraiter(id);
            return NoContent();
        }
    }
}