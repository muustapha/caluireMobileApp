using caluireMobile.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class ProduitsService
    {
        private readonly CaluiremobileContext _context;

        public ProduitsService(CaluiremobileContext context)
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
            .Include("operation")
            .Include("typesproduit")            
            .ToList();
        }

        public Produit GetProduitbyId(int id)
        {
            return _context.Produits
            .Include("operation")
            .Include("typesproduit")            
            .FirstOrDefault(c => c.IdProduit == id);
        }

        public void UpdateProduit(Produit produit)
        {
            _context.Produits.Update(produit);
            _context.SaveChanges();
        }
    }
}