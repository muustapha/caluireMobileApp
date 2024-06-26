using AutoMapper;
using caluireMobile.Models.Dtos;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraductionsController : ControllerBase
    {
        private readonly TraductionsService _service;
        private readonly IMapper _mapper;

        public TraductionsController(TraductionsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TraductionDtoOut>> GetAllTraductions()
        {
            var traductions = _service.GetAllTraductions();
            return Ok(_mapper.Map<IEnumerable<TraductionDtoOut>>(traductions));
        }

        [HttpGet("{id}", Name = "GetTraductionById")]
        public ActionResult<TraductionDtoIn> GetTraductionById(int id)
        {
            var traduction = _service.GetTraductionById(id);
            if (traduction == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TraductionDtoIn>(traduction));
        }

        [HttpPost]
        public ActionResult<Traduction> AddTraduction(TraductionDtoIn traductionCreateDto)
        {
            var traductionModel = _mapper.Map<Traduction>(traductionCreateDto);
            _service.AddTraduction(traductionModel);
            return CreatedAtRoute(nameof(GetTraductionById), new { Id = traductionModel.IdTraduction }, _mapper.Map<TraductionDtoOut>(traductionModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTraduction(int id, TraductionDtoIn traductionUpdateDto)
        {
            var traductionModelFromRepo = _service.GetTraductionById(id);
            if (traductionModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(traductionUpdateDto, traductionModelFromRepo);
            _service.UpdateTraduction(traductionModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTraductionUpdate(int id, JsonPatchDocument<Traduction> patchDoc)
        {
            var traductionModelFromRepo = _service.GetTraductionById(id);
            if (traductionModelFromRepo == null)
            {
                return NotFound();
            }
            var traductionToPatch = _mapper.Map<Traduction>(traductionModelFromRepo);
            patchDoc.ApplyTo(traductionToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("", err.ErrorMessage));

            if (!TryValidateModel(traductionToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(traductionToPatch, traductionModelFromRepo);
            _service.UpdateTraduction(traductionModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTraduction(int id)
        {
            var traductionModelFromRepo = _service.GetTraductionById(id);
            if (traductionModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTraduction(id);
            return NoContent();
        }
    }
}