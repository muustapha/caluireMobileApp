using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;

namespace CaluireMobile._0.Models.Services
{
    public class TraitersService: ITraitersService
    {
        private readonly ICaluireMobileContext _context;

        public TraitersService(ICaluireMobileContext context)
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

        public Traiter GetTraiterById(int id)
        {
            var traiteurFromDb = _context.Traiters
                                         .Include(t => t.Operation)
                                         .Include(t => t.Produit)
                                         .FirstOrDefault(t => t.IdTraiter == id);

            if (traiteurFromDb == null)
            {
                throw new KeyNotFoundException($"Traiter with id {id} was not found.");
            }

            return traiteurFromDb;
        }

        public void UpdateTraiter(Traiter traiter)
        {
            _context.Traiters.Update(traiter);
            _context.SaveChanges();
        }
    }
}