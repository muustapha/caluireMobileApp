namespace CaluireMobile._0.Models.Datas;

public partial class RendezVou
{
    public int IdRendezVous { get; set; }

    public int IdClient { get; set; }

    public int IdOperation { get; set; }

    public string? Description { get; set; }

    public DateTime? DateHeureRdv { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Operation Operation { get; set; } = null!;
}
