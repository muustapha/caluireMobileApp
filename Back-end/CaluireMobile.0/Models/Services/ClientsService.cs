using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaluireMobile._0.Models.Services
{
    public class ClientsService : IClientsService
    {
        private readonly ICaluireMobileContext _context;

        public ClientsService(ICaluireMobileContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveClientAsync(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Add(client);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task AddClientAsync(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new KeyNotFoundException($"Client with id {id} was not found.");
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients
                                 .Include(c => c.RendezVous)
                                 .Include(c => c.Socketios)
                                 .ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            var clientFromDb = await _context.Clients
                                             .Include(c => c.RendezVous)
                                             .Include(c => c.Socketios)
                                             .FirstOrDefaultAsync(c => c.IdClient == id);

            if (clientFromDb == null)
            {
                throw new KeyNotFoundException($"Client with id {id} was not found.");
            }

            return clientFromDb;
        }

        public async Task UpdateClientAsync(int id, Client client)
        {
            var existingClient = await _context.Clients.FindAsync(id);
            if (existingClient == null)
            {
                throw new KeyNotFoundException($"Client with id {id} was not found.");
            }

            _context.Entry(existingClient).CurrentValues.SetValues(client);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetClientByAdresseMailAsync(string adresseMail)
        {
            var client = await _context.Clients
                                       .FirstOrDefaultAsync(c => c.AdresseMail == adresseMail);

            if (client == null)
            {
                throw new KeyNotFoundException($"Client with email {adresseMail} was not found.");
            }

            return client;
        }
    }
}
