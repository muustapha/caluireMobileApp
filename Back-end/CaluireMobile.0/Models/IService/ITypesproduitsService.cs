using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface ITypesproduitsService
    {
        public void AddTypesproduits(Typesproduit Typesproduits);
        public void DeleteTypesproduits(int id);
        public IEnumerable<Typesproduit> GetAllTypesproduits();
        public Typesproduit GetTypesproduitsById(int id);
        public void UpdateTypesproduits(Typesproduit Typesproduits);
    }
}
