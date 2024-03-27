using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class OperationsServices
    {
        private readonly CaluireMobileContext _context;

        public OperationsServices(CaluireMobileContext context)
        {
            _context = context;
        }

        public void AddOperation(Operation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            _context.Operations.Add(operation);
            _context.SaveChanges();
        }

        public void DeleteOperation(int id)
        {
            var operation = _context.Operations.Find(id);
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            _context.Operations.Remove(operation);
            _context.SaveChanges();
        }

        public IEnumerable<Operation> GetAllOperations()
        {
            return _context.Operations
                           .Include(o => o.PriseEnCharges)
                           .Include(o => o.RendezVous)
                           .Include(o => o.Traiter)
                           .Include(o => o.Transactionspaiments)
                           .ToList();
        }

        public Operation GetOperationbyId(int id)
        {
            return _context.Operations
                            .Include(o => o.PriseEnCharges)
                           .Include(o => o.RendezVous)
                           .Include(o => o.Traiter)
                           .Include(o => o.Transactionspaiments)
                           .FirstOrDefault(o => o.IdOperation == id);
        }

        public void UpdateOperation(Operation operation)
        {
            _context.Operations.Update(operation);
            _context.SaveChanges();
        }
    }
}