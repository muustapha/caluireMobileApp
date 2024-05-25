using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface IPriseEnChargesService
    {
        public void AddPriseEnCharge(PriseEnCharge priseEnCharge);
        public void DeletePriseEnCharge(int id);
        public IEnumerable<PriseEnCharge> GetAllPriseEnCharges();
        public PriseEnCharge GetPriseEnChargeById(int id);
        public void UpdatePriseEnCharge(int id, PriseEnCharge priseEnCharge);

    }
}
