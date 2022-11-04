using AutoMapper;
using OnlineBank.API.HelperTools;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.AccountNumber, src => src.MapFrom(u => AccountNumberGenerator.GenerateRandomAccountNumber()));
            CreateMap<AtmDetails, AccountBalanceReturnObject>();
        }
    }
}
