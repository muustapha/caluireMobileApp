using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaluireMobile._0.Models.Services
{
    public class TypesproduitsService : ITypesproduitsService
    {
        private readonly ICaluireMobileContext _context;

        public TypesproduitsService(ICaluireMobileContext context)
        {
            _context = context;
        }

        public async Task AddTypesproduitAsync(Typesproduit typesproduit)
        {
            await _context.Typesproduits.AddAsync(typesproduit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTypesproduitsAsync(int id)
        {
            var typesproduit = await _context.Typesproduits.FirstOrDefaultAsync(t => t.IdTypesProduit == id);
            if (typesproduit == null)
            {
                throw new ArgumentNullException(nameof(typesproduit));
            }

            _context.Typesproduits.Remove(typesproduit);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Typesproduit>> GetAllTypesproduitsAsync()
        {
            return await _context.Typesproduits
                                 .Include(t => t.Produits)
                                 .ToListAsync();
        }

        public async Task<Typesproduit> GetTypesproduitsByIdAsync(int id)
        {
            var typesproduitFromDb = await _context.Typesproduits
                                                   .Include(t => t.Produits)
                                                   .FirstOrDefaultAsync(t => t.IdTypesProduit == id);

            if (typesproduitFromDb == null)
            {
                throw new KeyNotFoundException($"Typesproduit with id {id} was not found.");
            }

            return typesproduitFromDb;
        }

        public async Task UpdateTypesproduitsAsync(Typesproduit typesproduit)
        {
            _context.Typesproduits.Update(typesproduit);
            await _context.SaveChangesAsync();
        }
    }
}
