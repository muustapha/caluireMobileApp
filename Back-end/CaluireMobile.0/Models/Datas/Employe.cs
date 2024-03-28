namespace CaluireMobile._0.Models.Datas;

public partial class Employe
{
    public int IdEmploye { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Adresse { get; set; }

    public string? Mail { get; set; }

    public DateTime? DateEmbauche { get; set; }

    public string? Telephone { get; set; }

    public virtual ICollection<PriseEnCharge> PriseEnCharges { get; set; } = new List<PriseEnCharge>();

    public virtual ICollection<Socketio> Socketios { get; set; } = new List<Socketio>();
}
