using System;
using System.Collections.Generic;
using CaluireMobile._0.Models.Datas;

namespace caluireMobile.Models.Dtos
{
    public class OperationDtoIn
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


        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class OperationDtoOut
    {
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
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class OperationDtoAvecPriseEnCharges
    {
        public OperationDtoAvecPriseEnCharges()
        {
            PriseEnCharges = new HashSet<PriseEnChargeDtoOut>();
        }

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

        public virtual ICollection<PriseEnChargeDtoOut> PriseEnCharges { get; set; }
    }

    public class OperationDtoAvecRendezVous
    {
        public OperationDtoAvecRendezVous()
        {
            RendezVous = new HashSet<RendezVouDtoOut>();
        }

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


        public virtual ICollection<RendezVouDtoOut> RendezVous { get; set; }
    }

    public class OperationDtoAvecTraiter
    {
        public OperationDtoAvecTraiter()
        {
            Traiter = new HashSet<TraiterDtoOut>();
        }
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



        public virtual ICollection<TraiterDtoOut> Traiter { get; set; }
    }
public class OperationDtoAvecTransactionspaiment
    {
        public OperationDtoAvecTransactionspaiment()
        {
            Transactionspaiments = new HashSet<TransactionspaimentDtoOut>();
        }
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

        public virtual ICollection<TransactionspaimentDtoOut> Transactionspaiments { get; set; }
    }

   public class OperationDtoAvecPriseEnChargesEtRendezvousEtTraiterEtTransactionspaiment
{
  public OperationDtoAvecPriseEnChargesEtRendezvousEtTraiterEtTransactionspaiment()
  {
    PriseEnCharges = new HashSet<PriseEnChargeDtoOut>();
    RendezVous = new HashSet<RendezVouDtoOut>();
    Traiter = new HashSet<TraiterDtoOut>();
    Transactionspaiments = new HashSet<TransactionspaimentDtoOut>();
  }

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

    public virtual ICollection<PriseEnChargeDtoOut> PriseEnCharges { get; set; } 

    public virtual ICollection<RendezVouDtoOut> RendezVous { get; set; } 
    public virtual ICollection<TraiterDtoOut> Traiter { get; set; } 
    public virtual ICollection<TransactionspaimentDtoOut> Transactionspaiments { get; set; } 
}


}
