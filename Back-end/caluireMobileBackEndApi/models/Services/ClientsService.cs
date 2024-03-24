using System;
using System.Collections.Generic;
using System.Linq;
using caluireMobile.Models.Data;

namespace caluireMobile.Models.Services
{
    public class ClientsService
    {
        private readonly CaluiremobileContext _context;

        public ClientsService(CaluiremobileContext context)
        {
            _context = context;
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
            return _context.Clients.ToList();
        }

        public Client GetClientbyId(int id)
        {
            return _context.Clients.Find(id);
        }

        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }
    }
}