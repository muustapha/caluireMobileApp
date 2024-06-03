using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.Profiles
{
    public class PriseEnChargesProfile : Profile
    {
        public PriseEnChargesProfile()
        {
            // Cartographie de PriseEnCharge à PriseEnChargeDtoIn et vice versa            
            CreateMap<PriseEnChargeDtoIn, PriseEnCharge>();

            // Cartographie de PriseEnCharge à PriseEnChargeDtoOut et vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoOut>();
            CreateMap<PriseEnChargeDtoOut, PriseEnCharge>();

            // Cartographie de PriseEnCharge à PriseEnChargeDtoAvecEmploye et vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoAvecEmploye>();
            CreateMap<PriseEnChargeDtoAvecEmploye, PriseEnCharge>();

            // Cartographie de PriseEnCharge à PriseEnChargeDtoAvecOperation et vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoAvecOperation>();
            CreateMap<PriseEnChargeDtoAvecOperation, PriseEnCharge>();

            // Cartographie de PriseEnCharge à PriseEnChargeDtoAvecEmployeEtOperation et vice versa
            CreateMap<PriseEnCharge, PriseEnChargeDtoAvecEmployeEtOperation>();
            CreateMap<PriseEnChargeDtoAvecEmployeEtOperation, PriseEnCharge>();
        }
    }
}