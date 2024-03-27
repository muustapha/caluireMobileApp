using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class TransactionspaimentDtoIn
    {
        public TransactionspaimentDtoIn()
        {
        }

        public decimal Montant { get; set; }
        public DateTime DateTransaction { get; set; }
        public string Status { get; set; }
        public string MethodePayement { get; set; }
        public int IdOperation { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class TransactionspaimentDtoOut
    {
        public TransactionspaimentDtoOut()
        {
        }

        public decimal Montant { get; set; }
        public DateTime DateTransaction { get; set; }
        public string Status { get; set; }
        public string MethodePayement { get; set; }
        public int IdOperation { get; set; }
        
    }

    public class TransactionspaimentDtoAvecOperation
    {
        public TransactionspaimentDtoAvecOperation()
        {
        }

        public decimal Montant { get; set; }
        public DateTime DateTransaction { get; set; }
        public string Status { get; set; }
        public string MethodePayement { get; set; }
        public int IdOperation { get; set; }
        public OperationDto Operation { get; set; }
    }
}