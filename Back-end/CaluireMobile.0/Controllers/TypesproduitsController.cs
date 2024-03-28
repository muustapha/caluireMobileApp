using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CaluireMobile._0.Models.Controllers
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
        public ActionResult<IEnumerable<TypesproduitDtoAvecProduits>> GetAllTypesproduits()
        {
            var typesproduits = _service.GetAllTypesproduits();
            return Ok(_mapper.Map<IEnumerable<TypesproduitDtoAvecProduits>>(typesproduits));
        }

        [HttpGet("{id}", Name = "GetTypesproduitById")]
        public ActionResult<TypesproduitDtoAvecProduits> GetTypesproduitById(int id)
        {
            var typesproduit = _service.GetTypesproduitsById(id);
            if (typesproduit == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TypesproduitDtoAvecProduits>(typesproduit));
        }

        [HttpPost]
        public ActionResult<Typesproduit> AddTypesproduit(TypesproduitDtoIn typesproduitCreateDto)
        {
            var typesproduitModel = _mapper.Map<Typesproduit>(typesproduitCreateDto);
            _service.AddTypesproduits(typesproduitModel);
            return CreatedAtRoute(nameof(GetTypesproduitById), new { Id = typesproduitModel.IdTypesProduit }, _mapper.Map<TypesproduitDtoOut>(typesproduitModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTypesproduit(int id, TypesproduitDtoIn typesproduitUpdateDto)
        {
            var typesproduitModelFromRepo = _service.GetTypesproduitsById(id);
            if (typesproduitModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(typesproduitUpdateDto, typesproduitModelFromRepo);
            _service.UpdateTypesproduits(typesproduitModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTypesproduitUpdate(int id, JsonPatchDocument<Typesproduit> patchDoc)
        {
            var typesproduitFromRepo = _service.GetTypesproduitsById(id);
            if (typesproduitFromRepo == null)
            {
                return NotFound();
            }
            var typesproduitToPatch = _mapper.Map<Typesproduit>(typesproduitFromRepo);
            patchDoc.ApplyTo(typesproduitToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("", err.ErrorMessage));

            if (!TryValidateModel(typesproduitToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(typesproduitToPatch, typesproduitFromRepo);
            _service.UpdateTypesproduits(typesproduitFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTypesproduit(int id)
        {
            var typesproduitModelFromRepo = _service.GetTypesproduitsById(id);
            if (typesproduitModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTypesproduits(id);
            return NoContent();
        }
    }
}