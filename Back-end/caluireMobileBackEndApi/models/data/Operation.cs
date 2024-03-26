using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class Operation
{
    public Operation()
    {
        PriseEnCharge = new HashSet<PriseEnCharge>();

        RendezVous = new HashSet<RendezVou>();
    }
    public int IdOperation { get; set; }

    public DateTime? DateDemande { get; set; }

    public DateTime? DateRecuperation { get; set; }

    public DateTime? DateRetour { get; set; }

    public DateTime? DateVentes { get; set; }

    public DateTime? DateReparation { get; set; }

    public string? AdressePickup { get; set; }

    public string? Status { get; set; }

    public bool? ServiceExpress { get; set; }

    public decimal? Montant { get; set; }

    public int? Quantite { get; set; }

    public string? FlagReparationPickUpVente { get; set; }

    public virtual ICollection<PriseEnCharge> PriseEnCharge { get; set; }

    public virtual ICollection<RendezVou> RendezVous { get; set; }
}
