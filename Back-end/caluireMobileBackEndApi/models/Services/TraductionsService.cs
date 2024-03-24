using caluireMobile.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class TraductionsService
    {
        private readonly CaluiremobileContext _context;

        public TraductionsService(CaluiremobileContext context)
        {
            _context = context;
        }

        public void AddTraduction(Traduction traduction)
        {
            if (traduction == null)
            {
                throw new ArgumentNullException(nameof(traduction));
            }

            _context.Traductions.Add(traduction);
            _context.SaveChanges();
        }

        public void DeleteTraduction(int id)
        {
            var traduction = _context.Traductions.Find(id);
            if (traduction == null)
            {
                throw new ArgumentNullException(nameof(traduction));
            }

            _context.Traductions.Remove(traduction);
            _context.SaveChanges();
        }

        public IEnumerable<Traduction> GetAllTraductions()
        {
            return _context.Traductions.ToList();
        }

        public Traduction GetTraductionbyId(int id)
        {
            return _context.Traductions.Find(id);
        }

        public void UpdateTraduction(Traduction traduction)
        {
            _context.Traductions.Update(traduction);
            _context.SaveChanges();
        }
    }
}