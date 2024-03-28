using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile.Models.Dtos;

namespace CaluireMobile._0.Models.Profiles
{
    public class PriseEnChargesProfile : Profile
    {
        public PriseEnChargesProfile()
        {
            // Map from PriseEnCharge to PriseEnChargeDtoIn and vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoIn>();
            CreateMap<PriseEnChargeDtoIn, PriseEnCharge>();

            // Map from PriseEnCharge to PriseEnChargeDtoOut and vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoOut>();
            CreateMap<PriseEnChargeDtoOut, PriseEnCharge>();

            // Map from PriseEnCharge to PriseEnChargeDtoAvecEmploye and vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoAvecEmploye>();
            CreateMap<PriseEnChargeDtoAvecEmploye, PriseEnCharge>();

            // Map from PriseEnCharge to PriseEnChargeDtoAvecOperation and vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoAvecOperation>();
            CreateMap<PriseEnChargeDtoAvecOperation, PriseEnCharge>();

            // Map from PriseEnCharge to PriseEnChargeDtoAvecEmployeEtOperation and vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoAvecEmployeEtOperation>();
            CreateMap<PriseEnChargeDtoAvecEmployeEtOperation, PriseEnCharge>();
        }
    }
}