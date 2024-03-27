using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class ProduitsService
    {
        private readonly CaluireMobileContext _context;

        public ProduitsService(CaluireMobileContext context)
        {
            _context = context;
        }

        public void AddProduit(Produit produit)
        {
            if (produit == null)
            {
                throw new ArgumentNullException(nameof(produit));
            }

            _context.Produits.Add(produit);
            _context.SaveChanges();
        }

        public void DeleteProduit(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null)
            {
                throw new ArgumentNullException(nameof(produit));
            }

            _context.Produits.Remove(produit);
            _context.SaveChanges();
        }

        public IEnumerable<Produit> GetAllProduits()
        {
            return _context.Produits
                           .Include(p => p.Traiters)
                           .Include(p => p.TypesProduit)
                           .ToList();
        }

        public Produit GetProduitbyId(int id)
        {
            return _context.Produits
                           .Include(p => p.Traiters)
                           .Include(p => p.TypesProduit)
                           .FirstOrDefault(p => p.IdProduit == id);
        }

        public void UpdateProduit(Produit produit)
        {
            _context.Produits.Update(produit);
            _context.SaveChanges();
        }
    }
}