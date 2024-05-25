using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface IEmployesService
    {
        public void AddEmploye(Employe employe);
        public void DeleteEmploye(int id);
        public IEnumerable<Employe> GetAllEmployes();
        public Employe GetEmployeById(int id);
        public void UpdateEmploye(int id, Employe employe);

    }
}
