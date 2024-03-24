using caluireMobile.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class OperationsServices
    {
        private readonly CaluiremobileContext _context;

        public OperationsServices(CaluiremobileContext context)
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
            return _context.Operations.ToList();
        }

        public Operation GetOperationbyId(int id)
        {
            return _context.Operations.Find(id);
        }

        public void UpdateOperation(Operation operation)
        {
            _context.Operations.Update(operation);
            _context.SaveChanges();
        }
    }
}