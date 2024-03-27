using System;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Datas;

public partial class PriseEnCharge
{
    public int IdPriseEnCharge { get; set; }

    public int IdEmploye { get; set; }

    public int IdOperation { get; set; }

    public virtual Employe Employe { get; set; } = null!;

    public virtual Operation Operation { get; set; } = null!;
}
