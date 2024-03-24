using caluireMobile.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class RendezVousService
    {
        private readonly CaluiremobileContext _context;

        public RendezVousService(CaluiremobileContext context)
        {
            _context = context;
        }

        public void AddRendezVous(RendezVous rendezVous)
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

        public IEnumerable<RendezVous> GetAllRendezVous()
        {
            return _context.RendezVous.ToList();
        }

        public RendezVous GetRendezVousbyId(int id)
        {
            return _context.RendezVous.Find(id);
        }

        public void UpdateRendezVous(RendezVous rendezVous)
        {
            _context.RendezVous.Update(rendezVous);
            _context.SaveChanges();
        }
    }
}