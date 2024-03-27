using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class TypesproduitssService
    {
        private readonly CaluireMobileContext _context;

        public TypesproduitssService(CaluireMobileContext context)
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

        public Typesproduit GetTypesproduitsbyId(int id)
        {
            return _context.Typesproduits
            .Include(t => t.Produits)
            .FirstOrDefault(t => t.IdTypesProduit == id);
        }

        public void UpdateTypesproduits(Typesproduit Typesproduits)
        {
            _context.Typesproduits.Update(Typesproduits);
            _context.SaveChanges();
        }
    }
}