using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class Client
{ 
    public Client()
    {
        RendezVous = new HashSet<RendezVou>();
        Tchat = new HashSet<Tchat>();
        }
    public int IdClient { get; set; }

    public string? Nom { get; set; }

    public string? Prénom { get; set; }

    public string? AdresseMail { get; set; }

    public string? MotDepasse { get; set; }

    public bool? Abonnee { get; set; }

    public string? Adresse { get; set; }

    public string? Telephone { get; set; }

    public virtual ICollection<RendezVou> RendezVous { get; set; }
    public virtual ICollection<Tchat> Tchat { get; set; }
}
