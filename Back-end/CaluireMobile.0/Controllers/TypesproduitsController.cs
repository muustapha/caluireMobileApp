using AutoMapper;
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
        public ActionResult<IEnumerable<TypesproduitDtoAvecProduitsEtTraiters>> GetAllTypesproduits()
        {
            var typesproduits = _service.GetAllTypesproduits();
            return Ok(_mapper.Map<IEnumerable<TypesproduitDtoAvecProduitsEtTraiters>>(typesproduits));
        }

        [HttpGet("{id}", Name = "GetTypesproduitById")]
        public ActionResult<TypesproduitDtoAvecProduitsEtTraiters> GetTypesproduitById(int id)
        {
            var typesproduit = _service.GetTypesproduitById(id);
            if (typesproduit == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TypesproduitDtoAvecProduitsEtTraiters>(typesproduit));
        }

        [HttpPost]
        public ActionResult<Typesproduit> AddTypesproduit(TypesproduitDtoIn typesproduitCreateDto)
        {
            var typesproduitModel = _mapper.Map<Typesproduit>(typesproduitCreateDto);
            _service.AddTypesproduit(typesproduitModel);
            return CreatedAtRoute(nameof(GetTypesproduitById), new { Id = typesproduitModel.Id }, _mapper.Map<TypesproduitDtoOut>(typesproduitModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTypesproduit(int id, TypesproduitDtoIn typesproduitUpdateDto)
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
        public ActionResult PartialTypesproduitUpdate(int id, JsonPatchDocument<Typesproduit> patchDoc)
        {
            var typesproduitFromRepo = _service.GetTypesproduitById(id);
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
            _service.UpdateTypesproduit(typesproduitFromRepo);
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