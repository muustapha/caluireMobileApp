using caluireMobile.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class PriseEnChargesService
    {
        private readonly CaluiremobileContext _context;

        public PriseEnChargesService(CaluiremobileContext context)
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
            return _context.PriseEnCharges.ToList();
        }

        public PriseEnCharge GetPriseEnChargebyId(int id)
        {
            return _context.PriseEnCharges.Find(id);
        }

        public void UpdatePriseEnCharge(PriseEnCharge priseEnCharge)
        {
            _context.PriseEnCharges.Update(priseEnCharge);
            _context.SaveChanges();
        }
    }
}