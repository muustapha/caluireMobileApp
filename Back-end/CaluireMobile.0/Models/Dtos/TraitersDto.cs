using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class TraiterDtoIn
    {
        public TraiterDtoIn()
        {
        }

        public int IdOperation { get; set; }
        public int IdProduit { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class TraiterDtoOut
    {
        public TraiterDtoOut()
        {
        }

        public int IdOperation { get; set; }
        public int IdProduit { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class TraiterDtoAvecOperationEtProduit
    {
        public TraiterDtoAvecOperationEtProduit()
        {
        }

        public int IdOperation { get; set; }
        public int IdProduit { get; set; }
        public OperationDto Operation { get; set; }
        public ProduitDto Produit { get; set; }
    }
}