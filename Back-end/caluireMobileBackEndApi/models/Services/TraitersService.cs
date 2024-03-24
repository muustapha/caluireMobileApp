using caluireMobile.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class TraitersService
    {
        private readonly CaluiremobileContext _context;

        public TraitersService(CaluiremobileContext context)
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
            return _context.Traiters.ToList();
        }

        public Traiter GetTraiterbyId(int id)
        {
            return _context.Traiters.Find(id);
        }

        public void UpdateTraiter(Traiter traiter)
        {
            _context.Traiters.Update(traiter);
            _context.SaveChanges();
        }
    }
}