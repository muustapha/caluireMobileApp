using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaluireMobile._0.Models.Services
{
    public class SocketioServices
    {
        private readonly CaluireMobileContext _context;

        public SocketioServices(CaluireMobileContext context)
        {
            _context = context;
        }

        public void AddSocketio(Socketio Socketio)
        {
            if (Socketio == null)
            {
                throw new ArgumentNullException(nameof(Socketio));
            }

            _context.Socketios.Add(Socketio);
            _context.SaveChanges();
        }

        public void DeleteSocketio(int id)
        {
            var Socketio = _context.Socketios.Find(id);
            if (Socketio == null)
            {
                throw new ArgumentNullException(nameof(Socketio));
            }

            _context.Socketios.Remove(Socketio);
            _context.SaveChanges();
        }

        public IEnumerable<Socketio> GetAllSocketio()
        {
            return _context.Socketios
            .Include(s => s.Client)
            .Include(s => s.Employe)            
            .ToList();
        }

        public Socketio GetSocketiobyId(int id)
        {
            return _context.Socketios
             .Include(s => s.Client)
            .Include(s => s.Employe)
           .FirstOrDefault(r => r.IdSocketio == id);
        }

        public void UpdateSocketio(Socketio Socketio)
        {
            _context.Socketios.Update(Socketio);
            _context.SaveChanges();
        }
    }
}