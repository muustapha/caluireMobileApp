using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class Produit
{
    public int IdProduit { get; set; }

    public string? NomProduit { get; set; }

    public string? Marque { get; set; }

    public decimal? Prix { get; set; }

    public int? Stock { get; set; }

    public string? FlagClientEmploye { get; set; }

    public string? Photographie { get; set; }

    public int IdTypesproduit { get; set; }
    public int IdOperation { get; set; }

    public virtual Typesproduit Typesproduit { get; set; }

    public virtual Operation Operation { get; set; }
}
