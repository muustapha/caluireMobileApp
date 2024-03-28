using System;
using System.Collections.Generic;
#nullable disable


namespace caluireMobile.Models.Dtos
{
    public class TraiterDtoIn
    {

        public int IdTraiter { get; set; }
        public int IdOperation { get; set; }
        public int IdProduit { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class TraiterDtoOut
    {
     
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
        public virtual OperationDtoOut Operation { get; set; }
        public virtual ProduitDtoOut Produit { get; set; }
    }
}