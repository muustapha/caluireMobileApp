using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.Profiles
{
    public class SocketiosProfile : Profile
    {
        public SocketiosProfile()
        {
            // Map from Socketio to SocketioDtoIn and vice versa
            CreateMap<Socketio, SocketioDtoIn>();
            CreateMap<SocketioDtoIn, Socketio>();

            // Map from Socketio to SocketioDtoOut and vice versa
            CreateMap<Socketio, SocketioDtoOut>();
            CreateMap<SocketioDtoOut, Socketio>();

            // Map from Socketio to SocketioDtoAvecClient and vice versa
            CreateMap<Socketio, SocketioDtoAvecClient>();
            CreateMap<SocketioDtoAvecClient, Socketio>();

            // Map from Socketio to SocketioDtoAvecEmploye and vice versa
            CreateMap<Socketio, SocketioDtoAvecEmploye>();
            CreateMap<SocketioDtoAvecEmploye, Socketio>();

            // Map from Socketio to SocketioDtoAvecClientEtEmploye and vice versa
            CreateMap<Socketio, SocketioDtoAvecClientEtEmploye>();
            CreateMap<SocketioDtoAvecClientEtEmploye, Socketio>();
        }
    }
}