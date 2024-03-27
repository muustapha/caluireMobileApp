using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class ProduitDtoIn
    {
        public ProduitDtoIn()
        {
        }

        public string FlagProduit { get; set; }
        public string NomProduit { get; set; }
        public string Marque { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public string Photographie { get; set; }
        public string Description { get; set; }
        public int IdTypesProduit { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class ProduitDtoOut
    {
        public ProduitDtoOut()
        {
        }

        public string FlagProduit { get; set; }
        public string NomProduit { get; set; }
        public string Marque { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public string Photographie { get; set; }
        public string Description { get; set; }
        public int IdTypesProduit { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class ProduitDtoAvecTypesProduit
    {
        public ProduitDtoAvecTypesProduit()
        {
            Traiters = new HashSet<TraiterDto>();
        }

        public string FlagProduit { get; set; }
        public string NomProduit { get; set; }
        public string Marque { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public string Photographie { get; set; }
        public string Description { get; set; }
        public int IdTypesProduit { get; set; }
        public TypesProduitDto TypesProduit { get; set; }

        public virtual ICollection<TraiterDto> Traiters { get; set; }
    }
}