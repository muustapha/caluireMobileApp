using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class EmployeDtoIn
    {
        public int IdEmploye { get; set; }

        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public DateTime? DateEmbauche { get; set; }
        public string? Telephone { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class EmployeDtoOut
    {
     
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public DateTime? DateEmbauche { get; set; }
        public string? Telephone { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class EmployeDtoAvecPriseEnCharges
    {
        public EmployeDtoAvecPriseEnCharges()
        {
            PriseEnCharges = new HashSet<PriseEnChargeDtoOut>();
        }

        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public DateTime? DateEmbauche { get; set; }
        public string? Telephone { get; set; }

        public virtual ICollection<PriseEnChargeDtoOut> PriseEnCharges { get; set; }
    }


    public class EmployeDtoAvecSocketios
    {
        public EmployeDtoAvecSocketios()
        {
            Socketios = new HashSet<SocketioDtoAvecClientEtEmploye>();
        }

        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public DateTime? DateEmbauche { get; set; }
        public string? Telephone { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
        public virtual ICollection<SocketioDtoAvecClientEtEmploye> Socketios { get; set; }
    }
    
    public class EmployeDtoAvecPriseEnChargesEtSocketios
    {
        public EmployeDtoAvecPriseEnChargesEtSocketios()
        {
            PriseEnCharges = new HashSet<PriseEnChargeDtoOut>();
            Socketios = new HashSet<SocketioDtoAvecClientEtEmploye>();
        }

        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public DateTime? DateEmbauche { get; set; }
        public string? Telephone { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
        public virtual ICollection<PriseEnChargeDtoOut> PriseEnCharges { get; set; }
        public virtual ICollection<SocketioDtoAvecClientEtEmploye> Socketios { get; set; }
    }
}