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
    public class TypesproduitsController : ControllerBase
    {
        private readonly TypesproduitsService _service;
        private readonly IMapper _mapper;

        public TypesproduitsController(TypesproduitsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TypesproduitDto>> GetAllTypesproduits()
        {
            var typesproduits = _service.GetAllTypesproduits();
            return Ok(_mapper.Map<IEnumerable<TypesproduitDto>>(typesproduits));
        }

        [HttpGet("{id}", Name = "GetTypesproduitById")]
        public ActionResult<TypesproduitDto> GetTypesproduitById(int id)
        {
            var typesproduit = _service.GetTypesproduitById(id);
            if (typesproduit == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TypesproduitDto>(typesproduit));
        }

        [HttpPost]
        public ActionResult<TypesproduitDto> AddTypesproduit(TypesproduitCreateDto typesproduitCreateDto)
        {
            var typesproduitModel = _mapper.Map<Typesproduit>(typesproduitCreateDto);
            _service.AddTypesproduit(typesproduitModel);
            return CreatedAtRoute(nameof(GetTypesproduitById), new { Id = typesproduitModel.Id }, _mapper.Map<TypesproduitDto>(typesproduitModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTypesproduit(int id, TypesproduitUpdateDto typesproduitUpdateDto)
        {
            var typesproduitModelFromRepo = _service.GetTypesproduitById(id);
            if (typesproduitModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(typesproduitUpdateDto, typesproduitModelFromRepo);
            _service.UpdateTypesproduit(typesproduitModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTypesproduitUpdate(int id, JsonPatchDocument<TypesproduitUpdateDto> patchDoc)
        {
            var typesproduitModelFromRepo = _service.GetTypesproduitById(id);
            if (typesproduitModelFromRepo == null)
            {
                return NotFound();
            }
            var typesproduitToPatch = _mapper.Map<TypesproduitUpdateDto>(typesproduitModelFromRepo);
            patchDoc.ApplyTo(typesproduitToPatch, ModelState);
            if (!TryValidateModel(typesproduitToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(typesproduitToPatch, typesproduitModelFromRepo);
            _service.UpdateTypesproduit(typesproduitModelFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTypesproduit(int id)
        {
            var typesproduitModelFromRepo = _service.GetTypesproduitById(id);
            if (typesproduitModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTypesproduit(id);
            return NoContent();
        }
    }
}