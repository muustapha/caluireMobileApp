using System;
using System.Collections.Generic;
#nullable disable


namespace caluireMobile.Models.Dtos
{
    public class RendezVouDtoIn
    {

        public int IdRendzeVous { get; set; }
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

        
        public string Description { get; set; }
        public DateTime DateHeureRdv { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class RendezVouDtoAvecClientEtOperation
    {
        public RendezVouDtoAvecClientEtOperation()
        {
            Client = new ClientDtoOut();
            Operation = new OperationDtoOut();
        }

        public int IdClient { get; set; }
        public int IdOperation { get; set; }
        public string Description { get; set; }
        public DateTime DateHeureRdv { get; set; }
        public virtual ClientDtoOut Client { get; set; }
        public virtual OperationDtoOut Operation { get; set; }
    }

    public class RendezVouDtoAvecClient
    {
        public RendezVouDtoAvecClient()
        {
            Client = new ClientDtoOut();
        }

        public int IdClient { get; set; }
        public string Description { get; set; }
        public DateTime DateHeureRdv { get; set; }
        public virtual ClientDtoOut Client { get; set; }
    }

    public class RendezVouDtoAvecOperation
    {
        public RendezVouDtoAvecOperation()
        {
            Operation = new OperationDtoOut();
        }

        public int IdOperation { get; set; }
        public string Description { get; set; }
        public DateTime DateHeureRdv { get; set; }
        public virtual OperationDtoOut Operation { get; set; }
    }   
}