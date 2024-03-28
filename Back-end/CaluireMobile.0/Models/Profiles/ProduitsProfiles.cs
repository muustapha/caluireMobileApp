using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.Profiles
{
    public class ProduitsProfile : Profile
    {
        public ProduitsProfile()
        {
            // Map from Produit to ProduitDtoIn and vice versa
            CreateMap<Produit, ProduitDtoIn>();
            CreateMap<ProduitDtoIn, Produit>();

            // Map from Produit to ProduitDtoOut and vice versa
            CreateMap<Produit, ProduitDtoOut>();
            CreateMap<ProduitDtoOut, Produit>();

            // Map from Produit to ProduitDtoAvecTypesProduit and vice versa
            CreateMap<Produit, ProduitDtoAvecTypesProduit>();
            CreateMap<ProduitDtoAvecTypesProduit, Produit>();

            // Map from Produit to ProduitDtoAvecTraiters and vice versa
            CreateMap<Produit, ProduitDtoAvecTraiter>();
            CreateMap<ProduitDtoAvecTraiter, Produit>();

            // Map from Produit to ProduitDtoAvecTypesProduitEtTraiters and vice versa
            CreateMap<Produit, ProduitDtoAvecTypesProduitEtTraiter>();
            CreateMap<ProduitDtoAvecTypesProduitEtTraiter, Produit>();
        }
    }
}