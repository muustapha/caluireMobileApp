using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class RendezVousService
    {
        private readonly CaluireMobileContext _context;

        public RendezVousService(CaluireMobileContext context)
        {
            _context = context;
        }

        public void AddRendezVous(RendezVou rendezVous)
        {
            if (rendezVous == null)
            {
                throw new ArgumentNullException(nameof(rendezVous));
            }

            _context.RendezVous.Add(rendezVous);
            _context.SaveChanges();
        }

        public void DeleteRendezVous(int id)
        {
            var rendezVous = _context.RendezVous.Find(id);
            if (rendezVous == null)
            {
                throw new ArgumentNullException(nameof(rendezVous));
            }

            _context.RendezVous.Remove(rendezVous);
            _context.SaveChanges();
        }

        public IEnumerable<RendezVou> GetAllRendezVous()
        {
            return _context.RendezVous
                           .Include(r => r.Client)
                           .Include(r => r.Operation)
                           .ToList();
        }

        public void UpdateRendezVous(int id, RendezVou rendezVous)
        {
            var existingRendezVous = _context.RendezVous.Find(id);
            if (existingRendezVous == null)
            {
                throw new KeyNotFoundException($"RendezVous with id {id} was not found.");
            }

            _context.RendezVous.Update(rendezVous);
            _context.SaveChanges();
        }

        public void UpdateRendezVous(RendezVou rendezVous)
        {
            _context.RendezVous.Update(rendezVous);
            _context.SaveChanges();
        }
    }
}