using AutoMapper;
using OnlineBank.API.HelperTools;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(IDataService dataService)
        {
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.AccountNumber, src => src.MapFrom(u => AccountNumberGenerator.GenerateRandomAccountNumber()));
            CreateMap<User, AccountBalanceReturnObject>();
            CreateMap<User, UserReturnObject>()
                .ForMember(dest => dest.AccountType, src => src.MapFrom(u => dataService.AccountsDataObject.GetAsync(u.AccountTypeId).Result.AccountType));
;        }
    }
}
