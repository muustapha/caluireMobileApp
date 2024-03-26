using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class Typesproduit
{
    public Typesproduit()
    {
        Produits = new HashSet<Produit>();
    }
    public int IdTypesProduit { get; set; }

    public string? NomTypes { get; set; }

    public virtual ICollection<Produit> Produits { get; set; }
}
