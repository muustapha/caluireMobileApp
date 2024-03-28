#nullable disable


namespace caluireMobile._0.Models.Dtos
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
public class TraiterDtoAvecOperation
    {
        public TraiterDtoAvecOperation()
        {
            Operation = new OperationDtoOut();
        }

        public int IdOperation { get; set; }
    
        public virtual OperationDtoOut Operation { get; set; }
    }
    public class TraiterDtoAvecProduit
    {
        public TraiterDtoAvecProduit()
        {
            Produit = new ProduitDtoOut();
        }

        public int IdProduit { get; set; }
    
        public virtual ProduitDtoOut Produit { get; set; }
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