using System;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Datas;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Nom { get; set; }

    public string? Prénom { get; set; }

    public string? AdresseMail { get; set; }

    public string? Login { get; set; }

    public string? MotDePasse { get; set; }

    public string? Adresse { get; set; }

    public string? Telephone { get; set; }

    public virtual ICollection<RendezVou> RendezVous { get; set; } = new List<RendezVou>();

    public virtual ICollection<Socketio> Socketios { get; set; } = new List<Socketio>();
}
