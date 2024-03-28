using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class TypesproduitsService
    {
        private readonly CaluireMobileContext _context;

        public TypesproduitsService(CaluireMobileContext context)
        {
            _context = context;
        }

        public void AddTypesproduits(Typesproduit Typesproduits)
        {
            if (Typesproduits == null)
            {
                throw new ArgumentNullException(nameof(Typesproduits));
            }

            _context.Typesproduits.Add(Typesproduits);
            _context.SaveChanges();
        }

        public void DeleteTypesproduits(int id)
        {
            var Typesproduits = _context.Typesproduits.FirstOrDefault(t => t.IdTypesProduit == id);
            if (Typesproduits == null)
            {
                throw new ArgumentNullException(nameof(Typesproduits));
            }

            _context.Typesproduits.Remove(Typesproduits);
            _context.SaveChanges();
        }

        public IEnumerable<Typesproduit> GetAllTypesproduitss()
        {
            return _context.Typesproduits
            .Include(t => t.Produits)
            .ToList();
        }

        public Typesproduit GetTypesproduitsById(int id)
        {
            var typesproduitFromDb = _context.Typesproduits
                                             .Include(t => t.Produits)
                                             .FirstOrDefault(t => t.IdTypesProduit == id);

            if (typesproduitFromDb == null)
            {
                throw new KeyNotFoundException($"Typesproduit with id {id} was not found.");
            }

            return typesproduitFromDb;
        }
        public void UpdateTypesproduits(Typesproduit Typesproduits)
        {
            _context.Typesproduits.Update(Typesproduits);
            _context.SaveChanges();
        }
    }
}