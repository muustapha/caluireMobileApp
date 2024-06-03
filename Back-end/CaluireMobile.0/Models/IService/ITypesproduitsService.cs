using CaluireMobile._0.Models.Datas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaluireMobile._0.Models.IService
{
    public interface ITypesproduitsService
    {
        Task AddTypesproduitAsync(Typesproduit typesproduit);
        Task DeleteTypesproduitsAsync(int id);
        Task<IEnumerable<Typesproduit>> GetAllTypesproduitsAsync();
        Task<Typesproduit> GetTypesproduitsByIdAsync(int id);
        Task UpdateTypesproduitsAsync(Typesproduit typesproduit);
    }
}
