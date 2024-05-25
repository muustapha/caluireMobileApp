using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface ITraitersService
    {
        public void AddTraiter(Traiter traiter);
        public void DeleteTraiter(int id);
        public IEnumerable<Traiter> GetAllTraiters();
        public Traiter GetTraiterById(int id);
        public void UpdateTraiter(Traiter traiter);
    }
}
