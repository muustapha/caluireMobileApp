using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface IClientsService
    {
        public void Save();
        public void AddClient(Client client);
        public void DeleteClient(int id);
        public IEnumerable<Client> GetAllClients();
        public Client GetClientById(int id);
        public void UpdateClient(int id, Client client);
        public Client GetClientByAdresseMail(string adresseMail);

    }
}
