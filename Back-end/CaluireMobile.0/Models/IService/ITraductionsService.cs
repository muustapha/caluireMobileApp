using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface ITraductionsService
    {
        public void AddTraduction(Traduction traduction);
        public void DeleteTraduction(int id);
        public IEnumerable<Traduction> GetAllTraductions();
        public Traduction GetTraductionById(int id);
        public void UpdateTraduction(Traduction traduction);
    }
}
