namespace CaluireMobile._0.Models.Datas;

public partial class Typesproduit
{
    public int IdTypesProduit { get; set; }

    public string? NomTypes { get; set; }

    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
}
