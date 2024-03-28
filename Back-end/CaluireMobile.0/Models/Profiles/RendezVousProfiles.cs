using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile.Models.Dtos;

namespace CaluireMobile._0.Models.Profiles
{
    public class RendezVousProfile : Profile
    {
        public RendezVousProfile()
        {
            // Map from RendezVou to RendezVouDtoIn and vice versa
            CreateMap<RendezVou, RendezVouDtoIn>();
            CreateMap<RendezVouDtoIn, RendezVou>();

            // Map from RendezVou to RendezVouDtoOut and vice versa
            CreateMap<RendezVou, RendezVouDtoOut>();
            CreateMap<RendezVouDtoOut, RendezVou>();

            // Map from RendezVou to RendezVouDtoAvecClient and vice versa
            CreateMap<RendezVou, RendezVouDtoAvecClient>();
            CreateMap<RendezVouDtoAvecClient, RendezVou>();

            // Map from RendezVou to RendezVouDtoAvecOperation and vice versa
            CreateMap<RendezVou, RendezVouDtoAvecOperation>();
            CreateMap<RendezVouDtoAvecOperation, RendezVou>();

            // Map from RendezVou to RendezVouDtoAvecClientEtOperation and vice versa
            CreateMap<RendezVou, RendezVouDtoAvecClientEtOperation>();
            CreateMap<RendezVouDtoAvecClientEtOperation, RendezVou>();
        }
    }
}