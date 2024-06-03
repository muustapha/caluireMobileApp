using CaluireMobile._0.Models.Datas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaluireMobile._0.Models.IService
{
    public interface IClientsService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> GetClientByAdresseMailAsync(string adresseMail);
        Task AddClientAsync(Client client); // Ajoutez cette ligne
        Task UpdateClientAsync(int id, Client client);
        Task DeleteClientAsync(int id); // Ajoutez cette ligne
    }
}
