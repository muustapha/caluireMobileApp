#nullable disable

namespace caluireMobile._0.Models.Dtos
{
    public class TransactionspaimentDtoIn
    {
        public TransactionspaimentDtoIn()
        {
        }
        public int IdTransaction { get; set; }
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

    }

    public class TransactionspaimentDtoAvecOperation
    {


        public decimal Montant { get; set; }
        public DateTime DateTransaction { get; set; }
        public string Status { get; set; }
        public string MethodePayement { get; set; }
        public int IdOperation { get; set; }
        public virtual OperationDtoOut Operation { get; set; }
    }
}