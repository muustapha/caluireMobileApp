using CaluireMobile._0.Models.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CaluireMobile._0.Models.IService
{
    public interface ICaluireMobileContext
    {
        DbSet<Client> Clients { get; set; }

        DbSet<Employe> Employes { get; set; }

        DbSet<Operation> Operations { get; set; }

        DbSet<PriseEnCharge> PriseEnCharges { get; set; }

        DbSet<Produit> Produits { get; set; }

        DbSet<RendezVou> RendezVous { get; set; }

        DbSet<Socketio> Socketios { get; set; }

        DbSet<Traduction> Traductions { get; set; }

        DbSet<Traiter> Traiters { get; set; }

        DbSet<Transactionspaiment> Transactionspaiments { get; set; }

        DbSet<Typesproduit> Typesproduits { get; set; }
        int SaveChanges();
       EntityEntry<T> Entry<T>(T entity) where T : class;

    }
}
