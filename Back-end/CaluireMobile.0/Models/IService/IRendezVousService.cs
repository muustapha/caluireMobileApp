using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface IRendezVousService
    {
        public void AddRendezVous(RendezVou rendezVous);
        public void DeleteRendezVous(int id);
        public IEnumerable<RendezVou> GetAllRendezVous();
        public RendezVou GetRendezVousById(int id);
        public void UpdateRendezVous(int id, RendezVou rendezVous);
        public void UpdateRendezVous(RendezVou rendezVous);
    }
}
