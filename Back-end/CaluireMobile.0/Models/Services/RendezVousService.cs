using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;

namespace CaluireMobile._0.Models.Services
{
    public class RendezVousService : IRendezVousService
    {
        private readonly ICaluireMobileContext _context;

        public RendezVousService(ICaluireMobileContext context)
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
        public RendezVou GetRendezVousById(int id)
        {
            var rendezVous = _context.RendezVous
                                     .Include(r => r.Client)
                                     .Include(r => r.Operation)
                                     .FirstOrDefault(r => r.IdRendezVous == id);

            if (rendezVous == null)
            {
                throw new KeyNotFoundException($"RendezVous with id {id} was not found.");
            }

            return rendezVous;
        }

        public void UpdateRendezVous(RendezVou rendezVous)
        {
            _context.RendezVous.Update(rendezVous);
            _context.SaveChanges();
        }
    }
}