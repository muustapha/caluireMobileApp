using CaluireMobile._0.Models.Datas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaluireMobile._0.Models.IService
{
    public interface IProduitsService
    {
        Task AddProduitAsync(Produit produit);
        Task DeleteProduitAsync(int id);
        Task<IEnumerable<Produit>> GetAllProduitsAsync();
        Task<Produit> GetProduitByIdAsync(int id);
        Task<IEnumerable<Produit>> GetProduitsByFlagAndTypeAsync(string flag, string typeProduit);
        Task UpdateProduitAsync(Produit produit);
    }
}
