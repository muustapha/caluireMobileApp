using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class ClientsService
    {
        private readonly CaluireMobileContext _context;

        public ClientsService(CaluireMobileContext context)
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
            return _context.Clients
                           .Include(c => c.RendezVous)
                           .Include(c => c.Socketios)
                           .ToList();
        }

        public Client GetClientbyId(int id)
        {
            return _context.Clients
                           .Include(c => c.RendezVous)
                           .Include(c => c.Socketios)
                           .FirstOrDefault(c => c.IdClient == id);
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
    }
}