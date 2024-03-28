#nullable disable

using caluireMobile._0.Models.Dtos;

namespace caluireMobile._0.Models.Dtos
{
    public class ProduitDtoIn
    {
        public int IdProduit { get; set; }

        public string FlagProduit { get; set; }

        public string NomProduit { get; set; }

        public string Marque { get; set; }

        public decimal Prix { get; set; }

        public int Stock { get; set; }

        public string Photographie { get; set; }

        public string Description { get; set; } = null!;

        public int IdTypesProduit { get; set; }


    }

    // Ajoutez d'autres propriétés selon vos besoins
}

public class ProduitDtoOut
{
   

    public string FlagProduit { get; set; }

        public string NomProduit { get; set; }

        public string Marque { get; set; }

        public decimal Prix { get; set; }

        public int Stock { get; set; }

        public string Photographie { get; set; }

        public string Description { get; set; } = null!;

        
    // Ajoutez d'autres propriétés selon vos besoins
}

public class ProduitDtoAvecTypesProduit
{

    public string FlagProduit { get; set; }
    public string NomProduit { get; set; }
    public string Marque { get; set; }
    public decimal Prix { get; set; }
    public int Stock { get; set; }
    public string Photographie { get; set; }
    public string Description { get; set; }
    public int IdTypesProduit { get; set; }
   
    public virtual TypesproduitDtoOut Typesproduit { get; set; }

}



public class ProduitDtoAvecTraiter
{
    public ProduitDtoAvecTraiter()
    {
        Traiter = new HashSet<TraiterDtoOut>();
    }

    public string FlagProduit { get; set; }
    public string NomProduit { get; set; }
    public string Marque { get; set; }
    public decimal Prix { get; set; }
    public int Stock { get; set; }
    public string Photographie { get; set; }
    public string Description { get; set; }
    public int IdTypesProduit { get; set; }
   
    public virtual ICollection<TraiterDtoOut> Traiter { get; set; }
}

public class ProduitDtoAvecTypesProduitEtTraiter
{
    public ProduitDtoAvecTypesProduitEtTraiter()
    {
        Typesproduit = new TypesproduitDtoOut();
    }

    public string FlagProduit { get; set; }
    public string NomProduit { get; set; }
    public string Marque { get; set; }
    public decimal Prix { get; set; }
    public int Stock { get; set; }
    public string Photographie { get; set; }
    public string Description { get; set; }
    public int IdTypesProduit { get; set; }
   
    public virtual TypesproduitDtoOut Typesproduit { get; set; }
    public virtual ICollection<TraiterDtoOut> Traiter { get; set; }


}