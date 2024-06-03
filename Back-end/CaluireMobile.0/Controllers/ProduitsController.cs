using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IProduitsService _service;
        private readonly IMapper _mapper;

        public ProduitsController(IProduitsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{flag}/{type}")]
        public async Task<ActionResult<IEnumerable<ProduitDtoAvecTypesProduitEtTraiter>>> GetProduitsByFlagAndTypeAsync(string flag, string type)
        {
            var produits = await _service.GetProduitsByFlagAndTypeAsync(flag, type);
            return Ok(_mapper.Map<IEnumerable<ProduitDtoAvecTypesProduitEtTraiter>>(produits));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduitDtoAvecTypesProduitEtTraiter>>> GetAllProduitsAsync()
        {
            var produits = await _service.GetAllProduitsAsync();
            return Ok(_mapper.Map<IEnumerable<ProduitDtoAvecTypesProduitEtTraiter>>(produits));
        }

        [HttpGet("{id}", Name = "GetProduitByIdAsync")]
        public async Task<ActionResult<ProduitDtoAvecTypesProduitEtTraiter>> GetProduitByIdAsync(int id)
        {
            var produit = await _service.GetProduitByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProduitDtoAvecTypesProduitEtTraiter>(produit));
        }

        [HttpPost]
        public async Task<ActionResult<Produit>> AddProduitAsync(ProduitDtoIn produitCreateDto)
        {
            var produitModel = _mapper.Map<Produit>(produitCreateDto);
            await _service.AddProduitAsync(produitModel);
            return CreatedAtRoute(nameof(GetProduitByIdAsync), new { Id = produitModel.IdProduit }, _mapper.Map<ProduitDtoIn>(produitModel));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduitAsync(int id, ProduitDtoIn produitUpdateDto)
        {
            var produitModelFromRepo = await _service.GetProduitByIdAsync(id);
            if (produitModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(produitUpdateDto, produitModelFromRepo);
            await _service.UpdateProduitAsync(produitModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialProduitUpdateAsync(int id, JsonPatchDocument<Produit> patchDoc)
        {
            var produitModelFromRepo = await _service.GetProduitByIdAsync(id);
            if (produitModelFromRepo == null)
            {
                return NotFound();
            }

            var produitToPatch = _mapper.Map<Produit>(produitModelFromRepo);
            patchDoc.ApplyTo(produitToPatch, error => ModelState.AddModelError("", error.ErrorMessage));

            if (!TryValidateModel(produitToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(produitToPatch, produitModelFromRepo);
            await _service.UpdateProduitAsync(produitModelFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduitAsync(int id)
        {
            var produitModelFromRepo = await _service.GetProduitByIdAsync(id);
            if (produitModelFromRepo == null)
            {
                return NotFound();
            }
            await _service.DeleteProduitAsync(id);
            return NoContent();
        }
    }
}
