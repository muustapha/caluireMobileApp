using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class PriseEnCharge
{

    public int IdPriseEnCharge { get; set; }
    public int IdEmploye { get; set; }

    public int IdOperation { get; set; }

public virtual Employe Employe { get; set; }

public virtual Operation Operation { get; set; }

}
