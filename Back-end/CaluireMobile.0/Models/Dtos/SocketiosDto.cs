using System;
using System.Collections.Generic;
#nullable disable

namespace caluireMobile.Models.Dtos
{
    public class SocketioDtoIn
    {

        public int Socketio { get; set; }
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


        public int IdClient { get; set; }
        public int IdEmploye { get; set; }
        public string NomUtilisateur { get; set; }
        public virtual ClientDtoOut Client { get; set; }
        public virtual EmployeDtoOut Employe { get; set; }
    }

    public class SocketioDtoAvecClient
    {
        public SocketioDtoAvecClient()
        {
            Client = new ClientDtoOut();
        }

        public int IdClient { get; set; }
        public int IdEmploye { get; set; }
        public string NomUtilisateur { get; set; }
        public virtual ClientDtoOut Client { get; set; }
    }
    public class SocketioDtoAvecEmploye
    {
        public SocketioDtoAvecEmploye()
        {
            Employe = new EmployeDtoOut();
        }

        public int IdClient { get; set; }
        public int IdEmploye { get; set; }
        public string NomUtilisateur { get; set; }
        public virtual EmployeDtoOut Employe { get; set; }
    }
}