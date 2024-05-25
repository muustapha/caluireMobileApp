using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;

namespace CaluireMobile._0.Models.Services
{
    public class ClientsService : IClientsService
    {
        private readonly CaluireMobileContext _context;

        public ClientsService(CaluireMobileContext context)
        {
            _context = context;
        }
        public void Save()
    {
        _context.SaveChanges();
    }

        public void AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients
                           .Include(c => c.RendezVous)
                           .Include(c => c.Socketios)
                           .ToList();
        }

        public Client GetClientById(int id)
        {
            var clientFromDb = _context.Clients
                                       .Include(c => c.RendezVous)
                                       .Include(c => c.Socketios)
                                       .FirstOrDefault(c => c.IdClient == id);

            if (clientFromDb == null)
            {
                throw new KeyNotFoundException($"Client with id {id} was not found.");
            }

            return clientFromDb;
        }
        public void UpdateClient(int id, Client client)
        {
            var existingClient = _context.Clients.Find(id);
            if (existingClient == null)
            {
                throw new ArgumentNullException(nameof(existingClient));
            }

            _context.Entry(existingClient).CurrentValues.SetValues(client);
            _context.SaveChanges();
        }

        public Client GetClientByAdresseMail(string adresseMail)
        {
            var client = _context.Clients
                                 .FirstOrDefault(c => c.AdresseMail == adresseMail);

            if (client == null)
            {
                throw new KeyNotFoundException($"Client with email {adresseMail} was not found.");
            }

            return client;
        }


        
    }
    
}