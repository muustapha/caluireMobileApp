using System;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Datas;

public partial class Socketio
{
    public int IdSocketio { get; set; }

    public int IdClient { get; set; }

    public int IdEmploye { get; set; }

    public string? NomUtilisateur { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Employe Employe { get; set; } = null!;
}
