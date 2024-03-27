using System;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Datas;

public partial class Operation
{
    public int IdOperation { get; set; }

    public string? FlagOperation { get; set; }

    public DateTime? DateDemande { get; set; }

    public DateTime? DateRecuperation { get; set; }

    public DateTime? DateRetour { get; set; }

    public DateTime? DateReparation { get; set; }

    public DateTime? DateVentes { get; set; }

    public string? AdressePickup { get; set; }

    public string? Status { get; set; }

    public bool? ServiceExpress { get; set; }

    public decimal? Montant { get; set; }

    public int? Quantite { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<PriseEnCharge> PriseEnCharges { get; set; } = new List<PriseEnCharge>();

    public virtual ICollection<RendezVou> RendezVous { get; set; } = new List<RendezVou>();

    public virtual Traiter? Traiter { get; set; }

    public virtual ICollection<Transactionspaiment> Transactionspaiments { get; set; } = new List<Transactionspaiment>();
}
