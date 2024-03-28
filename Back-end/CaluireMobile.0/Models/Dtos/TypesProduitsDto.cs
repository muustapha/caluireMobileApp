using System;
using System.Collections.Generic;
#nullable disable

namespace caluireMobile.Models.Dtos
{ 
    public class TypesproduitDtoIn

{  
     public int IdTypesProduit { get; set; }


    public string NomTypes { get; set; }

}

public class TypesproduitDtoOut
{


    public string NomTypes { get; set; }
    // Ajoutez d'autres propriétés selon vos besoins
}

public class TypesproduitDtoAvecProduits
{
    public TypesproduitDtoAvecProduits()
    {
        Produits = new HashSet<ProduitDtoOut>();
    }

    public string NomTypes { get; set; }
    public virtual ICollection<ProduitDtoOut> Produits { get; set; }
}
}