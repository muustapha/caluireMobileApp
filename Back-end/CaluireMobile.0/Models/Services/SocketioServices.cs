using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;

namespace CaluireMobile._0.Models.Services
{
    public class SocketioServices : ISocketioServices
    {
        private readonly ICaluireMobileContext _context;

        public SocketioServices(ICaluireMobileContext context)
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

        public Socketio GetSocketioById(int id)
        {
            var socketioFromDb = _context.Socketios
                                          .Include(s => s.Client)
                                          .Include(s => s.Employe)
                                          .FirstOrDefault(s => s.IdSocketio == id);

            if (socketioFromDb == null)
            {
                throw new KeyNotFoundException($"Socketio with id {id} was not found.");
            }

            return socketioFromDb;
        }
        public void UpdateSocketio(Socketio Socketio)
        {
            _context.Socketios.Update(Socketio);
            _context.SaveChanges();
        }
    }
}