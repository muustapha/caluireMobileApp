using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile.Models.Dtos;

namespace CaluireMobile._0.Models.Profiles
{
    public class TypesProduitsProfile : Profile
    {
        public TypesProduitsProfile()
        {
            // Map from Typesproduit to TypesproduitDtoIn and vice versa
            CreateMap<Typesproduit, TypesproduitDtoIn>();
            CreateMap<TypesproduitDtoIn, Typesproduit>();

            // Map from Typesproduit to TypesproduitDtoOut and vice versa
            CreateMap<Typesproduit, TypesproduitDtoOut>();
            CreateMap<TypesproduitDtoOut, Typesproduit>();

            // Map from Typesproduit to TypesproduitDtoAvecProduits and vice versa
            CreateMap<Typesproduit, TypesproduitDtoAvecProduits>();
            CreateMap<TypesproduitDtoAvecProduits, Typesproduit>();
        }
    }
}