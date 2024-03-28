using AutoMapper;
using caluireMobile.Models.Dtos;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly ProduitsService _service;
        private readonly IMapper _mapper;

        public ProduitsController(ProduitsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProduitDtoAvecTypesProduitEtTraiter>> GetAllProduits()
        {
            var produits = _service.GetAllProduits();
            return Ok(_mapper.Map<IEnumerable<ProduitDtoAvecTypesProduitEtTraiter>>(produits));
        }

        [HttpGet("{id}", Name = "GetProduitById")]
        public ActionResult<ProduitDtoAvecTypesProduitEtTraiter> GetProduitById(int id)
        {
            var produit = _service.GetProduitById(id);
            if (produit == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProduitDtoAvecTypesProduitEtTraiter>(produit));
        }

        [HttpPost]
        public ActionResult<Produit> AddProduit(ProduitDtoIn produitCreateDto)
        {
            var produitModel = _mapper.Map<Produit>(produitCreateDto);
            _service.AddProduit(produitModel);
            return CreatedAtRoute(nameof(GetProduitById), new { Id = produitModel.IdProduit }, _mapper.Map<ProduitDtoIn>(produitModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduit(int id, ProduitDtoIn produitUpdateDto)
        {
            var produitModelFromRepo = _service.GetProduitById(id);
            if (produitModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(produitUpdateDto, produitModelFromRepo);
            _service.UpdateProduit(produitModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialProduitUpdate(int id, JsonPatchDocument<Produit> patchDoc)
        {
            var produitModelFromRepo = _service.GetProduitById(id);
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
            _service.UpdateProduit(produitModelFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduit(int id)
        {
            var produitModelFromRepo = _service.GetProduitById(id);
            if (produitModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteProduit(id);
            return NoContent();
        }
    }
}