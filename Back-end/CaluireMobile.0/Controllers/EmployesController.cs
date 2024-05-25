using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.IService;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly IEmployesService _service;
        private readonly IMapper _mapper;

        public EmployesController(IEmployesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeDtoOut>> GetAllEmployes()
        {
            var employes = _service.GetAllEmployes();
            return Ok(_mapper.Map<IEnumerable<EmployeDtoOut>>(employes));
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeDtoAvecPriseEnChargesEtSocketios> GetEmployeById(int id)
        {
            var employe = _service.GetEmployeById(id);
            if (employe == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeDtoAvecPriseEnChargesEtSocketios>(employe));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmploye(int id, EmployeDtoIn employeDtoIn)
        {
            var employe = _mapper.Map<Employe>(employeDtoIn);
            _service.UpdateEmploye(id, employe);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<EmployeDtoOut> AddEmploye(EmployeDtoIn employeDtoIn)
        {
            var employe = _mapper.Map<Employe>(employeDtoIn);
            _service.AddEmploye(employe);
            return CreatedAtAction(nameof(GetEmployeById), new { id = employe.IdEmploye }, _mapper.Map<EmployeDtoOut>(employe));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmploye(int id)
        {
            _service.DeleteEmploye(id);
            return NoContent();
        }
    }
}