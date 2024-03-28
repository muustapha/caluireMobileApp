using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.Profiles
{
    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            // Map from Client to ClientDtoIn and vice versa
            CreateMap<Client, ClientDtoIn>();
            CreateMap<ClientDtoIn, Client>();

            // Map from Client to ClientDtoOut and vice versa
            CreateMap<Client, ClientDtoOut>();
            CreateMap<ClientDtoOut, Client>();

            // Map from Client to ClientDtoAvecrendezVous and vice versa
            CreateMap<Client, ClientDtoAvecrendezVous>();
            CreateMap<ClientDtoAvecrendezVous, Client>();

            // Map from Client to ClientDtoAvecSocketios and vice versa
            CreateMap<Client, ClientDtoAvecSocketios>();
            CreateMap<ClientDtoAvecSocketios, Client>();

            // Map from Client to ClientDtoAvecrendezVousEtSocketios and vice versa
            CreateMap<Client, ClientDtoAvecrendezVousEtSocketios>();
            CreateMap<ClientDtoAvecrendezVousEtSocketios, Client>();
        }
    }
}