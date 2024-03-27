using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class OperationDtoIn
    {
        public OperationDtoIn()
        {
        }

        public string FlagOperation { get; set; }
        public DateTime DateDemande { get; set; }
        public DateTime DateRecuperation { get; set; }
        public DateTime DateRetour { get; set; }
        public DateTime DateReparation { get; set; }
        public DateTime DateVentes { get; set; }
        public string AdressePickup { get; set; }
        public string Status { get; set; }
        public bool ServiceExpress { get; set; }
        public decimal Montant { get; set; }
        public int Quantite { get; set; }
        public string Description { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class OperationDtoOut
    {
        public OperationDtoOut()
        {
        }

        public string FlagOperation { get; set; }
        public DateTime DateDemande { get; set; }
        public DateTime DateRecuperation { get; set; }
        public DateTime DateRetour { get; set; }
        public DateTime DateReparation { get; set; }
        public DateTime DateVentes { get; set; }
        public string AdressePickup { get; set; }
        public string Status { get; set; }
        public bool ServiceExpress { get; set; }
        public decimal Montant { get; set; }
        public int Quantite { get; set; }
        public string Description { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class OperationDtoAvecPriseEnCharges
    {
        public OperationDtoAvecPriseEnCharges()
        {
            PriseEnCharges = new HashSet<PriseEnChargeDto>();
        }

        public string FlagOperation { get; set; }
        public DateTime DateDemande { get; set; }
        public DateTime DateRecuperation { get; set; }
        public DateTime DateRetour { get; set; }
        public DateTime DateReparation { get; set; }
        public DateTime DateVentes { get; set; }
        public string AdressePickup { get; set; }
        public string Status { get; set; }
        public bool ServiceExpress { get; set; }
        public decimal Montant { get; set; }
        public int Quantite { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PriseEnChargeDto> PriseEnCharges { get; set; }
    }
}