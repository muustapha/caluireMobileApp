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
        public ActionResult<IEnumerable<RendezVouDtoOut>> GetAllRendezVous()
        {
            var rendezVous = _service.GetAllRendezVous();
            return Ok(_mapper.Map<IEnumerable<RendezVouDtoOut>>(rendezVous));
        }

        [HttpGet("{id}", Name = "GetRendezVousById")]
        public ActionResult<RendezVouDtoAvecClientEtOperation> GetRendezVousById(int id)
        {
            var rendezVous = _service.GetRendezVousById(id);
            if (rendezVous == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RendezVouDtoAvecClientEtOperation>(rendezVous));
        }

        [HttpPost]
        public ActionResult<RendezVouDtoOut> AddRendezVous(RendezVouDtoIn rendezVousCreateDto)
        {
            var rendezVousModel = _mapper.Map<RendezVou>(rendezVousCreateDto);
            _service.AddRendezVous(rendezVousModel);
            return CreatedAtRoute(nameof(GetRendezVousById), new { Id = rendezVousModel.IdRendezVous }, _mapper.Map<RendezVouDtoOut>(rendezVousModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRendezVous(int id, RendezVouDtoIn rendezVousUpdateDto)
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
        public ActionResult PartialRendezVousUpdate(int id, JsonPatchDocument<RendezVouDtoIn> patchDoc)
        {
            var rendezVousModelFromRepo = _service.GetRendezVousById(id);
            if (rendezVousModelFromRepo == null)
            {
                return NotFound();
            }

            var rendezVousToPatch = _mapper.Map<RendezVouDtoIn>(rendezVousModelFromRepo);
            patchDoc.ApplyTo(rendezVousToPatch, error => ModelState.AddModelError("", error.ErrorMessage));

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