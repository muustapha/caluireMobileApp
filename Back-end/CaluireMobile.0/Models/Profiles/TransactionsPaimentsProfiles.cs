using AutoMapper;
using CaluireMobile._0.Models.Datas;
using caluireMobile.Models.Dtos;

namespace CaluireMobile._0.Models.Profiles
{
    public class TransactionsPaimentsProfile : Profile
    {
        public TransactionsPaimentsProfile()
        {
            // Map from Transactionspaiment to TransactionspaimentDtoIn and vice versa
            CreateMap<Transactionspaiment, TransactionspaimentDtoIn>();
            CreateMap<TransactionspaimentDtoIn, Transactionspaiment>();

            // Map from Transactionspaiment to TransactionspaimentDtoOut and vice versa
            CreateMap<Transactionspaiment, TransactionspaimentDtoOut>();
            CreateMap<TransactionspaimentDtoOut, Transactionspaiment>();

            // Map from Transactionspaiment to TransactionspaimentDtoAvecOperation and vice versa
            CreateMap<Transactionspaiment, TransactionspaimentDtoAvecOperation>();
            CreateMap<TransactionspaimentDtoAvecOperation, Transactionspaiment>();
        }
    }
}