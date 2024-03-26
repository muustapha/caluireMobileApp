using caluireMobile.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace caluireMobile.Models.Services
{
    public class EmployesService
    {
        private readonly CaluiremobileContext _context;

        public EmployesService(CaluiremobileContext context)
        {
            _context = context;
        }

        public void AddEmploye(Employe employe)
        {
            if (employe == null)
            {
                throw new ArgumentNullException(nameof(employe));
            }

            _context.Employes.Add(employe);
            _context.SaveChanges();
        }

        public void DeleteEmploye(int id)
        {
            var employe = _context.Employes.Find(id);
            if (employe == null)
            {
                throw new ArgumentNullException(nameof(employe));
            }

            _context.Employes.Remove(employe);
            _context.SaveChanges();
        }

        public IEnumerable<Employe> GetAllEmployes()
        {
            return _context.Employes
                           .Include("tchat")
                           .Include("operation")
                           .ToList();
        }

        public Employe GetEmployebyId(int id)
        {
            return _context.Employes
                           .Include("tchat")
                           .Include("operation")
                           .FirstOrDefault(e => e.IdEmploye == id);
        }

        public void UpdateEmploye(Employe employe)
        {
            _context.Employes.Update(employe);
            _context.SaveChanges();
        }
    }
}
