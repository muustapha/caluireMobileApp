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
    public class OperationsController : ControllerBase
    {
        private readonly IOperationsServices _service;
        private readonly IMapper _mapper;

        public OperationsController(IOperationsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OperationDtoOut>> GetAllOperations()
        {
            var operations = _service.GetAllOperations();
            return Ok(_mapper.Map<IEnumerable<OperationDtoOut>>(operations));
        }

        [HttpGet("{id}")]
        public ActionResult<OperationDtoAvecPriseEnCharges> GetOperationById(int id)
        {
            var operation = _service.GetOperationById(id);
            if (operation == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OperationDtoAvecPriseEnCharges>(operation));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOperation(int id, OperationDtoIn operationDtoIn)
        {
            var operation = _mapper.Map<Operation>(operationDtoIn);
            _service.UpdateOperation(id, operation);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<OperationDtoOut> AddOperation(OperationDtoIn operationDtoIn)
        {
            var operation = _mapper.Map<Operation>(operationDtoIn);
            _service.AddOperation(operation);
            return CreatedAtAction(nameof(GetOperationById), new { id = operation.IdOperation }, _mapper.Map<OperationDtoOut>(operation));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOperation(int id)
        {
            _service.DeleteOperation(id);
            return NoContent();
        }
    }
}