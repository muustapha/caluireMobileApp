using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class TransactionspaimentService
    {
        private readonly CaluireMobileContext _context;

        public TransactionspaimentService(CaluireMobileContext context)
        {
            _context = context;
        }

        public void AddTransaction(Transactionspaiment transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _context.Transactionspaiments.Add(transaction);
            _context.SaveChanges();
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _context.Transactionspaiments.Find(id);
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _context.Transactionspaiments.Remove(transaction);
            _context.SaveChanges();
        }

        public IEnumerable<Transactionspaiment> GetAllTransactions()
        {
            return _context.Transactionspaiments
            .Include(t => t.Operation)            
            .ToList();
        }

        public Transactionspaiment GetTransactionbyId(int id)
        {
            return _context.Transactionspaiments
                        .Include(t => t.Operation)
                        .FirstOrDefault(t => t.IdTransactionPaiment == id);

        }

        public void UpdateTransaction(Transactionspaiment transaction)
        {
            _context.Transactionspaiments.Update(transaction);
            _context.SaveChanges();
        }
    }
}