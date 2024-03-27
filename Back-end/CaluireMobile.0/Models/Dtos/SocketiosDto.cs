using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Dtos
{
    public class SocketioDtoIn
    {
        public SocketioDtoIn()
        {
        }

        public int IdClient { get; set; }
        public int IdEmploye { get; set; }
        public string NomUtilisateur { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class SocketioDtoOut
    {
        public SocketioDtoOut()
        {
        }

        public int IdClient { get; set; }
        public int IdEmploye { get; set; }
        public string NomUtilisateur { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class SocketioDtoAvecClientEtEmploye
    {
        public SocketioDtoAvecClientEtEmploye()
        {
        }

        public int IdClient { get; set; }
        public int IdEmploye { get; set; }
        public string NomUtilisateur { get; set; }
        public ClientDto Client { get; set; }
        public EmployeDto Employe { get; set; }
    }
}