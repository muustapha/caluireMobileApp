using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data
{
    public partial class Employe
    {
        public Employe()
        {
            priseEnCharge = new HashSet<PriseEnCharge>();
            tchat = new HashSet<Tchat>();
        }

        public int IdEmploye { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public string? Adresse { get; set; }

        public string? Mail { get; set; }

        public DateTime? DateEmbauche { get; set; }

        public string? Telephone { get; set; }

        public virtual ICollection<PriseEnCharge> priseEnCharge { get; set; }
    
         public virtual ICollection<Tchat> tchat { get; set; }
    }
}