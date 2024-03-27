using System;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Datas;

public partial class Produit
{
    public int IdProduit { get; set; }

    public string? FlagProduit { get; set; }

    public string? NomProduit { get; set; }

    public string? Marque { get; set; }

    public decimal? Prix { get; set; }

    public int? Stock { get; set; }

    public string? Photographie { get; set; }

    public string Description { get; set; } = null!;

    public int IdTypesProduit { get; set; }

    public virtual Typesproduit TypesProduit { get; set; } = null!;

    public virtual ICollection<Traiter> Traiters { get; set; } = new List<Traiter>();
}
