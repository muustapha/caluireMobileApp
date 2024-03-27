using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class RendezVouDtoIn
    {
        public RendezVouDtoIn()
        {
        }

        public int IdClient { get; set; }
        public int IdOperation { get; set; }
        public string Description { get; set; }
        public DateTime DateHeureRdv { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class RendezVouDtoOut
    {
        public RendezVouDtoOut()
        {
        }

        public int IdClient { get; set; }
        public int IdOperation { get; set; }
        public string Description { get; set; }
        public DateTime DateHeureRdv { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class RendezVouDtoAvecClientEtOperation
    {
        public RendezVouDtoAvecClientEtOperation()
        {
        }

        public int IdClient { get; set; }
        public int IdOperation { get; set; }
        public string Description { get; set; }
        public DateTime DateHeureRdv { get; set; }
        public ClientDto Client { get; set; }
        public OperationDto Operation { get; set; }
    }
}