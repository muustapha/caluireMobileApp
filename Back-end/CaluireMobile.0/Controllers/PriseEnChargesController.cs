using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.IService;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriseEnChargesController : ControllerBase
    {
        private readonly IPriseEnChargesService _service;
        private readonly IMapper _mapper;

        public PriseEnChargesController(IPriseEnChargesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PriseEnChargeDtoOut>> GetAllPriseEnCharges()
        {
            var priseEnCharges = _service.GetAllPriseEnCharges();
            return Ok(_mapper.Map<IEnumerable<PriseEnChargeDtoOut>>(priseEnCharges));
        }

        [HttpGet("{id}")]
        public ActionResult<PriseEnChargeDtoAvecEmployeEtOperation> GetPriseEnChargeById(int id)
        {
            var priseEnCharge = _service.GetPriseEnChargeById(id);
            if (priseEnCharge == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PriseEnChargeDtoAvecEmployeEtOperation>(priseEnCharge));
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePriseEnCharge(int id, PriseEnChargeDtoIn priseEnChargeDtoIn)
        {
            var priseEnCharge = _mapper.Map<PriseEnCharge>(priseEnChargeDtoIn);
            _service.UpdatePriseEnCharge(id, priseEnCharge);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<PriseEnChargeDtoOut> AddPriseEnCharge(PriseEnChargeDtoIn priseEnChargeDtoIn)
        {
            var priseEnCharge = _mapper.Map<PriseEnCharge>(priseEnChargeDtoIn);
            _service.AddPriseEnCharge(priseEnCharge);
            return CreatedAtAction(nameof(GetPriseEnChargeById), new { id = priseEnCharge.IdPriseEnCharge }, _mapper.Map<PriseEnChargeDtoOut>(priseEnCharge));
        }
        [HttpPatch("{id}")]
        public ActionResult PartialPriseEnChargeUpdate(int id, JsonPatchDocument<PriseEnChargeDtoIn> patchDoc)
{
    var priseEnChargeFromRepo = _service.GetPriseEnChargeById(id);
    if (priseEnChargeFromRepo == null)
    {
        return NotFound();
    }

    var priseEnChargeToPatch = _mapper.Map<PriseEnChargeDtoIn>(priseEnChargeFromRepo);
    patchDoc.ApplyTo(priseEnChargeToPatch, error => ModelState.AddModelError("", error.ErrorMessage));

    if (!TryValidateModel(priseEnChargeToPatch))
    {
        return ValidationProblem(ModelState);
    }

    _mapper.Map(priseEnChargeToPatch, priseEnChargeFromRepo);
    _service.UpdatePriseEnCharge(id, priseEnChargeFromRepo);

    return NoContent();
}

        [HttpDelete("{id}")]
        public IActionResult DeletePriseEnCharge(int id)
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