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
        public ActionResult<IEnumerable<ProduitDto>> GetAllProduits()
        {
            var produits = _service.GetAllProduits();
            return Ok(_mapper.Map<IEnumerable<ProduitDto>>(produits));
        }

        [HttpGet("{id}", Name = "GetProduitById")]
        public ActionResult<ProduitDto> GetProduitById(int id)
        {
            var produit = _service.GetProduitById(id);
            if (produit == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProduitDto>(produit));
        }

        [HttpPost]
        public ActionResult<ProduitDto> AddProduit(ProduitCreateDto produitCreateDto)
        {
            var produitModel = _mapper.Map<Produit>(produitCreateDto);
            _service.AddProduit(produitModel);
            return CreatedAtRoute(nameof(GetProduitById), new { Id = produitModel.Id }, _mapper.Map<ProduitDto>(produitModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduit(int id, ProduitUpdateDto produitUpdateDto)
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
        public ActionResult PartialProduitUpdate(int id, JsonPatchDocument<ProduitUpdateDto> patchDoc)
        {
            var produitModelFromRepo = _service.GetProduitById(id);
            if (produitModelFromRepo == null)
            {
                return NotFound();
            }
            var produitToPatch = _mapper.Map<ProduitUpdateDto>(produitModelFromRepo);
            patchDoc.ApplyTo(produitToPatch, ModelState);
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