using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaluireMobile._0.Models.Services
{
    public class ProduitsService : IProduitsService
    {
        private readonly ICaluireMobileContext _context;

        public ProduitsService(ICaluireMobileContext context)
        {
            _context = context;
        }

        public async Task AddProduitAsync(Produit produit)
        {
            if (produit == null)
            {
                throw new ArgumentNullException(nameof(produit));
            }

            await _context.Produits.AddAsync(produit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduitAsync(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                throw new ArgumentNullException(nameof(produit));
            }

            _context.Produits.Remove(produit);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produit>> GetAllProduitsAsync()
        {
            return await _context.Produits
                                 .Include(p => p.Traiters)
                                 .Include(p => p.TypesProduit)
                                 .ToListAsync();
        }

        public async Task<Produit> GetProduitByIdAsync(int id)
        {
            var produitFromDb = await _context.Produits
                                              .Include(p => p.Traiters)
                                              .Include(p => p.TypesProduit)
                                              .FirstOrDefaultAsync(p => p.IdProduit == id);

            if (produitFromDb == null)
            {
                throw new KeyNotFoundException($"Produit with id {id} was not found.");
            }

            return produitFromDb;
        }

        public async Task<IEnumerable<Produit>> GetProduitsByFlagAndTypeAsync(string flag, string typeProduit)
        {
            return await _context.Produits
                                 .Include(p => p.TypesProduit)
                                 .Where(p => p.FlagProduit == flag && p.TypesProduit.NomTypes == typeProduit)
                                 .ToListAsync();
        }

        public async Task UpdateProduitAsync(Produit produit)
        {
            _context.Produits.Update(produit);
            await _context.SaveChangesAsync();
        }
    }
}
