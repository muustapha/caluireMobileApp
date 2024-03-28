namespace CaluireMobile._0.Models.Datas;

public partial class Traiter
{
    public int IdTraiter { get; set; }

    public int IdOperation { get; set; }

    public int IdProduit { get; set; }

    public virtual Operation Operation { get; set; } = null!;

    public virtual Produit Produit { get; set; } = null!;
}
