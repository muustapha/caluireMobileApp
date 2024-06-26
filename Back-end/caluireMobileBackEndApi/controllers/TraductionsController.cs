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
        public ActionResult<IEnumerable<TraductionDto>> GetAllTraductions()
        {
            var traductions = _service.GetAllTraductions();
            return Ok(_mapper.Map<IEnumerable<TraductionDto>>(traductions));
        }

        [HttpGet("{id}", Name = "GetTraductionById")]
        public ActionResult<TraductionDto> GetTraductionById(int id)
        {
            var traduction = _service.GetTraductionById(id);
            if (traduction == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TraductionDto>(traduction));
        }

        [HttpPost]
        public ActionResult<TraductionDto> AddTraduction(TraductionCreateDto traductionCreateDto)
        {
            var traductionModel = _mapper.Map<Traduction>(traductionCreateDto);
            _service.AddTraduction(traductionModel);
            return CreatedAtRoute(nameof(GetTraductionById), new { Id = traductionModel.Id }, _mapper.Map<TraductionDto>(traductionModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTraduction(int id, TraductionUpdateDto traductionUpdateDto)
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
        public ActionResult PartialTraductionUpdate(int id, JsonPatchDocument<TraductionUpdateDto> patchDoc)
        {
            var traductionModelFromRepo = _service.GetTraductionById(id);
            if (traductionModelFromRepo == null)
            {
                return NotFound();
            }
            var traductionToPatch = _mapper.Map<TraductionUpdateDto>(traductionModelFromRepo);
            patchDoc.ApplyTo(traductionToPatch, ModelState);
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