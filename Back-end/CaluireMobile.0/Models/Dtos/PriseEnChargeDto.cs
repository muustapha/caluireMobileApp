using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class PriseEnChargeDtoIn
    {
        public PriseEnChargeDtoIn()
        {
        }

        public int IdEmploye { get; set; }
        public int IdOperation { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class PriseEnChargeDtoOut
    {
        public PriseEnChargeDtoOut()
        {
        }

        public int IdEmploye { get; set; }
        public int IdOperation { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class PriseEnChargeDtoAvecEmployeEtOperation
    {
        public PriseEnChargeDtoAvecEmployeEtOperation()
        {
        }

        public int IdEmploye { get; set; }
        public int IdOperation { get; set; }
        public EmployeDto Employe { get; set; }
        public OperationDto Operation { get; set; }
    }
}