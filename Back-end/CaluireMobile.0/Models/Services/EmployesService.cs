using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class EmployesService
    {
        private readonly CaluireMobileContext _context;

        public EmployesService(CaluireMobileContext context)
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
                           .Include(e => e.Socketios)
                           .Include(e => e.PriseEnCharges)
                           .ToList();
        }

        public Employe GetEmployeById(int id)
        {
            var employeFromDb = _context.Employes
                                        .Include(e => e.Socketios)
                                        .Include(e => e.PriseEnCharges)
                                        .FirstOrDefault(e => e.IdEmploye == id);

            if (employeFromDb == null)
            {
                throw new KeyNotFoundException($"Employe with id {id} was not found.");
            }

            return employeFromDb;
        }
        public void UpdateEmploye(int id, Employe employe)
        {
            var existingEmploye = _context.Employes.Find(id);
            if (existingEmploye == null)
            {
                throw new KeyNotFoundException($"Employe with id {id} was not found.");
            }

            _context.Entry(existingEmploye).CurrentValues.SetValues(employe);
            _context.SaveChanges();
        }
    }
}
