using caluireMobile.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class Transaction    {
        private readonly CaluiremobileContext _context;

        public Transaction(CaluiremobileContext context)
        {
            _context = context;
        }

        public void AddTransaction(Transactionpaiments transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _context.Transactionpaiments.Add(transaction);
            _context.SaveChanges();
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _context.Transactionpaiments.Find(id);
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _context.Transactionpaiments.Remove(transaction);
            _context.SaveChanges();
        }

        public IEnumerable<Transactionpaiments> GetAllTransactions()
        {
            return _context.Transactionpaiments.ToList();
        }

        public Transactionpaiments GetTransactionbyId(int id)
        {
            return _context.Transactionpaiments.Find(id);
        }

        public void UpdateTransaction(Transactionpaiments transaction)
        {
            _context.Transactionpaiments.Update(transaction);
            _context.SaveChanges();
        }
    }