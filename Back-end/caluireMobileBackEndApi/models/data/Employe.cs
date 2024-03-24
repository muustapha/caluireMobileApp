using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class Employe
{
    public int IdEmploye { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Adresse { get; set; }

    public string? Mail { get; set; }

    public DateTime? DateEmbauche { get; set; }

    public string? Telephone { get; set; }
}
