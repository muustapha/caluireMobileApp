using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class PriseEnCharge
{
    public int IdEmploye { get; set; }

    public int IdOperation { get; set; }

public virtual Employe EmployeNavigation { get; set; }

public virtual Operation OperationNavigation { get; set; }

}
