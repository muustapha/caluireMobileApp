using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface IProduitsService
    {
        public void AddProduit(Produit produit);
        public void DeleteProduit(int id);
        public IEnumerable<Produit> GetAllProduits();
        public Produit GetProduitById(int id);
        public IEnumerable<Produit> GetProduitsByFlagAndType(string flag, string typeProduit);
        public void UpdateProduit(Produit produit);
    }
}
