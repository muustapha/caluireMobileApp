using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.Profiles
{
    public class EmployesProfile : Profile
    {
        public EmployesProfile()
        {
            // Map from Employe to EmployeDtoIn and vice versa
            CreateMap<Employe, EmployeDtoIn>();
            CreateMap<EmployeDtoIn, Employe>();

            // Map from Employe to EmployeDtoOut and vice versa
            CreateMap<Employe, EmployeDtoOut>();
            CreateMap<EmployeDtoOut, Employe>();

            // Map from Employe to EmployeDtoAvecRendezVous and vice versa
            CreateMap<Employe, EmployeDtoAvecPriseEnCharges>();
            CreateMap<EmployeDtoAvecPriseEnCharges, Employe>();

            // Map from Employe to EmployeDtoAvecSocketios and vice versa
            CreateMap<Employe, EmployeDtoAvecSocketios>();
            CreateMap<EmployeDtoAvecSocketios, Employe>();

            // Map from Employe to EmployeDtoAvecRendezVousEtSocketios and vice versa
            CreateMap<Employe, EmployeDtoAvecPriseEnChargesEtSocketios>();
            CreateMap<EmployeDtoAvecPriseEnChargesEtSocketios, Employe>();
        }
    }
}