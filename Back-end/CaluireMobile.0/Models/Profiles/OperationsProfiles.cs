using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile.Models.Dtos;

namespace CaluireMobile._0.Models.Profiles
{
    public class OperationsProfile : Profile
    {
        public OperationsProfile()
        {
            // Map from Operation to OperationDtoIn and vice versa
            CreateMap<Operation, OperationDtoIn>();
            CreateMap<OperationDtoIn, Operation>();

            // Map from Operation to OperationDtoOut and vice versa
            CreateMap<Operation, OperationDtoOut>();
            CreateMap<OperationDtoOut, Operation>();

            // Map from Operation to OperationDtoAvecPriseEnCharges and vice versa
            CreateMap<Operation, OperationDtoAvecPriseEnCharges>();
            CreateMap<OperationDtoAvecPriseEnCharges, Operation>();
        }
    }
}