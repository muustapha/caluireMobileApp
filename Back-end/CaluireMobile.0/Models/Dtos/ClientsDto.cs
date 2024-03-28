namespace caluireMobile._0.Models.Dtos
{
    public class ClientDtoIn
    {
        public int IdClient { get; set; }

        public string? Nom { get; set; }

        public string? Prénom { get; set; }

        public string? AdresseMail { get; set; }

        public string? Login { get; set; }

        public string? MotDePasse { get; set; }

        public string? Adresse { get; set; }

        public string? Telephone { get; set; }

    }

    public class ClientDtoOut
    {


        public string? Nom { get; set; }

        public string? Prénom { get; set; }

        public string? AdresseMail { get; set; }

        public string? Login { get; set; }

        public string? MotDePasse { get; set; }

        public string? Adresse { get; set; }

        public string? Telephone { get; set; }

    }

    public class ClientDtoAvecrendezVous
    {
        public ClientDtoAvecrendezVous()
        {
            RendezVous = new HashSet<RendezVouDtoAvecClientEtOperation>();
        }

        public string? Nom { get; set; }

        public string? Prénom { get; set; }

        public string? AdresseMail { get; set; }

        public string? Login { get; set; }

        public string? MotDePasse { get; set; }

        public string? Adresse { get; set; }

        public string? Telephone { get; set; }


        public virtual ICollection<RendezVouDtoAvecClientEtOperation> RendezVous { get; set; }
    }


    public class ClientDtoAvecSocketios
    {





        public ClientDtoAvecSocketios()
        {
            Socketios = new HashSet<SocketioDtoAvecClientEtEmploye>();
        }

        public string? Nom { get; set; }

        public string? Prénom { get; set; }

        public string? AdresseMail { get; set; }

        public string? Login { get; set; }

        public string? MotDePasse { get; set; }

        public string? Adresse { get; set; }

        public string? Telephone { get; set; }

        public virtual ICollection<SocketioDtoAvecClientEtEmploye> Socketios { get; set; }
    }



    public class ClientDtoAvecrendezVousEtSocketios
    {
        public ClientDtoAvecrendezVousEtSocketios()
        {
            RendezVous = new HashSet<RendezVouDtoAvecClientEtOperation>();
            Socketios = new HashSet<SocketioDtoAvecClientEtEmploye>();
        }

        public string? Nom { get; set; }

        public string? Prénom { get; set; }

        public string? AdresseMail { get; set; }

        public string? Login { get; set; }

        public string? MotDePasse { get; set; }

        public string? Adresse { get; set; }

        public string? Telephone { get; set; }

        public virtual ICollection<RendezVouDtoAvecClientEtOperation> RendezVous { get; set; }
        public virtual ICollection<SocketioDtoAvecClientEtEmploye> Socketios { get; set; }
    }
}