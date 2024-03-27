using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class TypesproduitDtoIn
    {
        public TypesproduitDtoIn()
        {
        }

        public string NomTypes { get; set; }
      
    }

    public class TypesproduitDtoOut
    {
        public TypesproduitDtoOut()
        {
        }

        public string NomTypes { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class TypesproduitDtoAvecProduits
    {
        public TypesproduitDtoAvecProduits()
        {
            Produits = new HashSet<ProduitDto>();
        }

        public string NomTypes { get; set; }
        public virtual ICollection<ProduitDto> Produits { get; set; }
    }
}