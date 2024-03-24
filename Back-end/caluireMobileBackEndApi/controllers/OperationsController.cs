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
    public class OperationsController : ControllerBase
    {
        private readonly OperationsService _service;
        private readonly IMapper _mapper;

        public OperationsController(OperationsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OperationDto>> GetAllOperations()
        {
            var operations = _service.GetAllOperations();
            return Ok(_mapper.Map<IEnumerable<OperationDto>>(operations));
        }

        [HttpGet("{id}", Name = "GetOperationById")]
        public ActionResult<OperationDto> GetOperationById(int id)
        {
            var operation = _service.GetOperationById(id);
            if (operation == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OperationDto>(operation));
        }

        [HttpPost]
        public ActionResult<OperationDto> AddOperation(OperationCreateDto operationCreateDto)
        {
            var operationModel = _mapper.Map<Operation>(operationCreateDto);
            _service.AddOperation(operationModel);
            return CreatedAtRoute(nameof(GetOperationById), new { Id = operationModel.Id }, _mapper.Map<OperationDto>(operationModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOperation(int id, OperationUpdateDto operationUpdateDto)
        {
            var operationModelFromRepo = _service.GetOperationById(id);
            if (operationModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(operationUpdateDto, operationModelFromRepo);
            _service.UpdateOperation(operationModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialOperationUpdate(int id, JsonPatchDocument<OperationUpdateDto> patchDoc)
        {
            var operationModelFromRepo = _service.GetOperationById(id);
            if (operationModelFromRepo == null)
            {
                return NotFound();
            }
            var operationToPatch = _mapper.Map<OperationUpdateDto>(operationModelFromRepo);
            patchDoc.ApplyTo(operationToPatch, ModelState);
            if (!TryValidateModel(operationToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(operationToPatch, operationModelFromRepo);
            _service.UpdateOperation(operationModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOperation(int id)
        {
            var operationModelFromRepo = _service.GetOperationById(id);
            if (operationModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteOperation(id);
            return NoContent();
        }
    }
}