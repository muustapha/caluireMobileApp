using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile.Models.Dtos;

namespace CaluireMobile._0.Models.Profiles
{
    public class TraitersProfile : Profile
    {
        public TraitersProfile()
        {
            // Map from Traiter to TraiterDtoIn and vice versa
            CreateMap<Traiter, TraiterDtoIn>();
            CreateMap<TraiterDtoIn, Traiter>();

            // Map from Traiter to TraiterDtoOut and vice versa
            CreateMap<Traiter, TraiterDtoOut>();
            CreateMap<TraiterDtoOut, Traiter>();

            // Map from Traiter to TraiterDtoAvecOperationEtProduit and vice versa
            CreateMap<Traiter, TraiterDtoAvecOperationEtProduit>();
            CreateMap<TraiterDtoAvecOperationEtProduit, Traiter>();

            // Map from Traiter to TraiterDtoAvecOperation and vice versa
            CreateMap<Traiter, TraiterDtoAvecOperation>();
            CreateMap<TraiterDtoAvecOperation, Traiter>();

            // Map from Traiter to TraiterDtoAvecProduit and vice versa
            CreateMap<Traiter, TraiterDtoAvecProduit>();
            CreateMap<TraiterDtoAvecProduit, Traiter>();
        }
    }
}