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
    public class PriseEnChargesController : ControllerBase
    {
        private readonly PriseEnChargesService _service;
        private readonly IMapper _mapper;

        public PriseEnChargesController(PriseEnChargesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PriseEnChargeDto>> GetAllPriseEnCharges()
        {
            var priseEnCharges = _service.GetAllPriseEnCharges();
            return Ok(_mapper.Map<IEnumerable<PriseEnChargeDto>>(priseEnCharges));
        }

        [HttpGet("{id}", Name = "GetPriseEnChargeById")]
        public ActionResult<PriseEnChargeDto> GetPriseEnChargeById(int id)
        {
            var priseEnCharge = _service.GetPriseEnChargeById(id);
            if (priseEnCharge == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PriseEnChargeDto>(priseEnCharge));
        }

        [HttpPost]
        public ActionResult<PriseEnChargeDto> AddPriseEnCharge(PriseEnChargeCreateDto priseEnChargeCreateDto)
        {
            var priseEnChargeModel = _mapper.Map<PriseEnCharge>(priseEnChargeCreateDto);
            _service.AddPriseEnCharge(priseEnChargeModel);
            return CreatedAtRoute(nameof(GetPriseEnChargeById), new { Id = priseEnChargeModel.Id }, _mapper.Map<PriseEnChargeDto>(priseEnChargeModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePriseEnCharge(int id, PriseEnChargeUpdateDto priseEnChargeUpdateDto)
        {
            var priseEnChargeModelFromRepo = _service.GetPriseEnChargeById(id);
            if (priseEnChargeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(priseEnChargeUpdateDto, priseEnChargeModelFromRepo);
            _service.UpdatePriseEnCharge(priseEnChargeModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialPriseEnChargeUpdate(int id, JsonPatchDocument<PriseEnChargeUpdateDto> patchDoc)
        {
            var priseEnChargeModelFromRepo = _service.GetPriseEnChargeById(id);
            if (priseEnChargeModelFromRepo == null)
            {
                return NotFound();
            }
            var priseEnChargeToPatch = _mapper.Map<PriseEnChargeUpdateDto>(priseEnChargeModelFromRepo);
            patchDoc.ApplyTo(priseEnChargeToPatch, ModelState);
            if (!TryValidateModel(priseEnChargeToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(priseEnChargeToPatch, priseEnChargeModelFromRepo);
            _service.UpdatePriseEnCharge(priseEnChargeModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePriseEnCharge(int id)
        {
            var priseEnChargeModelFromRepo = _service.GetPriseEnChargeById(id);
            if (priseEnChargeModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeletePriseEnCharge(id);
            return NoContent();
        }
    }
}