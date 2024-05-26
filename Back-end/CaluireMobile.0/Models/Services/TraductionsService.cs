using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;

namespace CaluireMobile._0.Models.Services
{
    public class TraductionsService: ITraductionsService
    {
        private readonly ICaluireMobileContext _context;

        public TraductionsService(ICaluireMobileContext context)
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

        public Traduction GetTraductionById(int id)
        {
            var traductionFromDb = _context.Traductions.FirstOrDefault(t => t.IdTraduction == id);

            if (traductionFromDb == null)
            {
                throw new KeyNotFoundException($"Traduction with id {id} was not found.");
            }

            return traductionFromDb;
        }

        public void UpdateTraduction(Traduction traduction)
        {
            _context.Traductions.Update(traduction);
            _context.SaveChanges();
        }
    }
}