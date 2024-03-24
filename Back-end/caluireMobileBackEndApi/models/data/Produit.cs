using System;
using System.Collections.Generic;

namespace caluireMobile.models.data;

public partial class Produit
{
    public int IdProduit { get; set; }

    public string? NomProduit { get; set; }

    public string? Marque { get; set; }

    public decimal? Prix { get; set; }

    public int? Stock { get; set; }

    public string? FlagClientEmploye { get; set; }

    public string? Photographie { get; set; }

    public int IdTypesProduit { get; set; }
}
