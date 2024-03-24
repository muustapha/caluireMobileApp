using caluireMobile.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class TypesproduitssService
    {
        private readonly CaluiremobileContext _context;

        public TypesproduitssService(CaluiremobileContext context)
        {
            _context = context;
        }

        public void AddTypesproduits(Typesproduitss Typesproduits)
        {
            if (Typesproduits == null)
            {
                throw new ArgumentNullException(nameof(Typesproduits));
            }

            _context.Typesproduitss.Add(Typesproduits);
            _context.SaveChanges();
        }

        public void DeleteTypesproduits(int id)
        {
            var Typesproduits = _context.Typesproduitss.Find(id);
            if (Typesproduits == null)
            {
                throw new ArgumentNullException(nameof(Typesproduits));
            }

            _context.Typesproduitss.Remove(Typesproduits);
            _context.SaveChanges();
        }

        public IEnumerable<Typesproduitss> GetAllTypesproduitss()
        {
            return _context.Typesproduitss.ToList();
        }

        public Typesproduitss GetTypesproduitsbyId(int id)
        {
            return _context.Typesproduitss.Find(id);
        }

        public void UpdateTypesproduits(Typesproduitss Typesproduits)
        {
            _context.Typesproduitss.Update(Typesproduits);
            _context.SaveChanges();
        }
    }
}