using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;

namespace CaluireMobile._0.Models.Services
{
    public class PriseEnChargesService : IPriseEnChargesService
    {
        private readonly ICaluireMobileContext _context;

        public PriseEnChargesService(ICaluireMobileContext context)
        {
            _context = context;
        }

        public void AddPriseEnCharge(PriseEnCharge priseEnCharge)
        {
            if (priseEnCharge == null)
            {
                throw new ArgumentNullException(nameof(priseEnCharge));
            }

            _context.PriseEnCharges.Add(priseEnCharge);
            _context.SaveChanges();
        }

        public void DeletePriseEnCharge(int id)
        {
            var priseEnCharge = _context.PriseEnCharges.Find(id);
            if (priseEnCharge == null)
            {
                throw new ArgumentNullException(nameof(priseEnCharge));
            }

            _context.PriseEnCharges.Remove(priseEnCharge);
            _context.SaveChanges();
        }

        public IEnumerable<PriseEnCharge> GetAllPriseEnCharges()
        {
            return _context.PriseEnCharges
                           .Include(p => p.Employe)
                           .Include(p => p.Operation)
                           .ToList();
        }

        public PriseEnCharge GetPriseEnChargeById(int id)
        {
            var priseEnCharge = _context.PriseEnCharges
                                        .Include(p => p.Employe)
                                        .Include(p => p.Operation)
                                        .FirstOrDefault(p => p.IdPriseEnCharge == id);

            if (priseEnCharge == null)
            {
                throw new KeyNotFoundException($"PriseEnCharge with id {id} was not found.");
            }

            return priseEnCharge;
        }
        public void UpdatePriseEnCharge(int id, PriseEnCharge priseEnCharge)
        {
            var existingPriseEnCharge = _context.PriseEnCharges.Find(id);
            if (existingPriseEnCharge == null)
            {
                throw new KeyNotFoundException($"PriseEnCharge with id {id} was not found.");
            }

            _context.Entry(existingPriseEnCharge).CurrentValues.SetValues(priseEnCharge);
            _context.SaveChanges();
        }
    }
}