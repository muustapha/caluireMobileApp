using caluireMobile.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caluireMobile.Models.Services
{
    public class TchatsServices
    {
        private readonly CaluiremobileContext _context;

        public TchatsServices(CaluiremobileContext context)
        {
            _context = context;
        }

        public void AddTchat(Tchat tchat)
        {
            if (tchat == null)
            {
                throw new ArgumentNullException(nameof(tchat));
            }

            _context.Tchats.Add(tchat);
            _context.SaveChanges();
        }

        public void DeleteTchat(int id)
        {
            var tchat = _context.Tchats.Find(id);
            if (tchat == null)
            {
                throw new ArgumentNullException(nameof(tchat));
            }

            _context.Tchats.Remove(tchat);
            _context.SaveChanges();
        }

        public IEnumerable<Tchat> GetAllTchats()
        {
            return _context.Tchats.ToList();
        }

        public Tchat GetTchatbyId(int id)
        {
            return _context.Tchats.Find(id);
        }

        public void UpdateTchat(Tchat tchat)
        {
            _context.Tchats.Update(tchat);
            _context.SaveChanges();
        }
    }
}