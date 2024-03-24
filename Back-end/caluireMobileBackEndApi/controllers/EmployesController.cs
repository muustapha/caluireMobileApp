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
    public class EmployesController : ControllerBase
    {
        private readonly EmployesService _service;
        private readonly IMapper _mapper;

        public EmployesController(EmployesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeDto>> GetAllEmployes()
        {
            var employes = _service.GetAllEmployes();
            return Ok(_mapper.Map<IEnumerable<EmployeDto>>(employes));
        }

        [HttpGet("{id}", Name = "GetEmployeById")]
        public ActionResult<EmployeDto> GetEmployeById(int id)
        {
            var employe = _service.GetEmployeById(id);
            if (employe == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeDto>(employe));
        }

        [HttpPost]
        public ActionResult<EmployeDto> AddEmploye(EmployeCreateDto employeCreateDto)
        {
            var employeModel = _mapper.Map<Employe>(employeCreateDto);
            _service.AddEmploye(employeModel);
            return CreatedAtRoute(nameof(GetEmployeById), new { Id = employeModel.Id }, _mapper.Map<EmployeDto>(employeModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmploye(int id, EmployeUpdateDto employeUpdateDto)
        {
            var employeModelFromRepo = _service.GetEmployeById(id);
            if (employeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(employeUpdateDto, employeModelFromRepo);
            _service.UpdateEmploye(employeModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialEmployeUpdate(int id, JsonPatchDocument<EmployeUpdateDto> patchDoc)
        {
            var employeModelFromRepo = _service.GetEmployeById(id);
            if (employeModelFromRepo == null)
            {
                return NotFound();
            }
            var employeToPatch = _mapper.Map<EmployeUpdateDto>(employeModelFromRepo);
            patchDoc.ApplyTo(employeToPatch, ModelState);
            if (!TryValidateModel(employeToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(employeToPatch, employeModelFromRepo);
            _service.UpdateEmploye(employeModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmploye(int id)
        {
            var employeModelFromRepo = _service.GetEmployeById(id);
            if (employeModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteEmploye(id);
            return NoContent();
        }
    }
}