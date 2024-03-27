using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class TraitersService
    {
        private readonly CaluireMobileContext _context;

        public TraitersService(CaluireMobileContext context)
        {
            _context = context;
        }

        public void AddTraiter(Traiter traiter)
        {
            if (traiter == null)
            {
                throw new ArgumentNullException(nameof(traiter));
            }

            _context.Traiters.Add(traiter);
            _context.SaveChanges();
        }

        public void DeleteTraiter(int id)
        {
            var traiter = _context.Traiters.Find(id);
            if (traiter == null)
            {
                throw new ArgumentNullException(nameof(traiter));
            }

            _context.Traiters.Remove(traiter);
            _context.SaveChanges();
        }

        public IEnumerable<Traiter> GetAllTraiters()
        {
            return _context.Traiters
                           .Include(t => t.Operation)
                            .Include(t => t.Produit)
                           .ToList();
        }

        public Traiter GetTraiterbyId(int id)
        {
            return _context.Traiters
                           .Include(t => t.Operation)
                            .Include(t => t.Produit)
                           .FirstOrDefault(t => t.IdTraiter == id);
        }

        public void UpdateTraiter(Traiter traiter)
        {
            _context.Traiters.Update(traiter);
            _context.SaveChanges();
        }
    }
}