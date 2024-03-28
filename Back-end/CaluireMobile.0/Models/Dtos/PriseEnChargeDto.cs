using System;
using System.Collections.Generic;

#nullable disable

namespace caluireMobile.Models.Dtos
{
    public class PriseEnChargeDtoIn
    {
        public int IdPriseEnCharge { get; set; }

        public int IdEmploye { get; set; }

        public int IdOperation { get; set; }

        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class PriseEnChargeDtoOut
    {
     

        public int IdEmploye { get; set; }
        public int IdOperation { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }
public class PriseEnChargeDtoAvecEmploye
    {
        public virtual EmployeDtoOut Employe { get; set; }
    }
    public class PriseEnChargeDtoAvecOperation
    {
        public virtual OperationDtoOut Operation { get; set; }
    }
    public class PriseEnChargeDtoAvecEmployeEtOperation
    {
        public virtual EmployeDtoOut Employe { get; set; }
        public virtual OperationDtoOut Operation { get; set; }
    }
}