using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaluireMobile._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesproduitsController : ControllerBase
    {
        private readonly ITypesproduitsService _typesproduitsService;

        public TypesproduitsController(ITypesproduitsService typesproduitsService)
        {
            _typesproduitsService = typesproduitsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Typesproduit>>> GetAllTypesproduits()
        {
            var typesproduits = await _typesproduitsService.GetAllTypesproduitsAsync();
            return Ok(typesproduits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Typesproduit>> GetTypesproduitsById(int id)
        {
            var typesproduit = await _typesproduitsService.GetTypesproduitsByIdAsync(id);
            if (typesproduit == null)
            {
                return NotFound();
            }
            return Ok(typesproduit);
        }

        [HttpPost]
        public async Task<ActionResult> AddTypesproduit(Typesproduit typesproduit)
        {
            await _typesproduitsService.AddTypesproduitAsync(typesproduit);
            return CreatedAtAction(nameof(GetTypesproduitsById), new { id = typesproduit.IdTypesProduit }, typesproduit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTypesproduits(int id, Typesproduit typesproduit)
        {
            if (id != typesproduit.IdTypesProduit)
            {
                return BadRequest();
            }
            await _typesproduitsService.UpdateTypesproduitsAsync(typesproduit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTypesproduits(int id)
        {
            await _typesproduitsService.DeleteTypesproduitsAsync(id);
            return NoContent();
        }
    }
}
