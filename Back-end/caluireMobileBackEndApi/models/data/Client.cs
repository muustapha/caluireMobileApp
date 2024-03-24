using System;
using System.Collections.Generic;

namespace caluireMobile.models.Data;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Nom { get; set; }

    public string? Prénom { get; set; }

    public string? AdresseMail { get; set; }

    public string? MotDepasse { get; set; }

    public bool? Abonnee { get; set; }

    public string? Adresse { get; set; }

    public string? Telephone { get; set; }
}
