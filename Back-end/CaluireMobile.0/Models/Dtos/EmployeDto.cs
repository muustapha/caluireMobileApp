using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class EmployeDtoIn
    {
        public EmployeDtoIn()
        {
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string Telephone { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class EmployeDtoOut
    {
        public EmployeDtoOut()
        {
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string Telephone { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class EmployeDtoAvecPriseEnCharges
    {
        public EmployeDtoAvecPriseEnCharges()
        {
            PriseEnCharges = new HashSet<PriseEnChargeDto>();
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<PriseEnChargeDto> PriseEnCharges { get; set; }
    }
}