using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using CaluireMobile._0.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly RendezVousService _service;
        private readonly IMapper _mapper;

        public RendezVousController(RendezVousService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RendezVousDto>> GetAllRendezVous()
        {
            var rendezVous = _service.GetAllRendezVous();
            return Ok(_mapper.Map<IEnumerable<RendezVousDto>>(rendezVous));
        }

        [HttpGet("{id}", Name = "GetRendezVousById")]
        public ActionResult<RendezVousDto> GetRendezVousById(int id)
        {
            var rendezVous = _service.GetRendezVousById(id);
            if (rendezVous == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RendezVousDto>(rendezVous));
        }

        [HttpPost]
        public ActionResult<RendezVousDto> AddRendezVous(RendezVousCreateDto rendezVousCreateDto)
        {
            var rendezVousModel = _mapper.Map<RendezVous>(rendezVousCreateDto);
            _service.AddRendezVous(rendezVousModel);
            return CreatedAtRoute(nameof(GetRendezVousById), new { Id = rendezVousModel.Id }, _mapper.Map<RendezVousDto>(rendezVousModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRendezVous(int id, RendezVousUpdateDto rendezVousUpdateDto)
        {
            var rendezVousModelFromRepo = _service.GetRendezVousById(id);
            if (rendezVousModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(rendezVousUpdateDto, rendezVousModelFromRepo);
            _service.UpdateRendezVous(rendezVousModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialRendezVousUpdate(int id, JsonPatchDocument<RendezVousUpdateDto> patchDoc)
        {
            var rendezVousModelFromRepo = _service.GetRendezVousById(id);
            if (rendezVousModelFromRepo == null)
            {
                return NotFound();
            }
            var rendezVousToPatch = _mapper.Map<RendezVousUpdateDto>(rendezVousModelFromRepo);
            patchDoc.ApplyTo(rendezVousToPatch, ModelState);
            if (!TryValidateModel(rendezVousToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(rendezVousToPatch, rendezVousModelFromRepo);
            _service.UpdateRendezVous(rendezVousModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRendezVous(int id)
        {
            var rendezVousModelFromRepo = _service.GetRendezVousById(id);
            if (rendezVousModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteRendezVous(id);
            return NoContent();
        }
    }
}