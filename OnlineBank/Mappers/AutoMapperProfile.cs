﻿using AutoMapper;
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

           CreateMap<FundTransferDTO, FundTransfer>()
                .ForMember(dest => dest.DestinationAccountTypeId, src => src.MapFrom(u => dataService.UsersDataObject.GetAsyncByAccountNumber(u.destinationAccountNumber).Result.AccountTypeId));
            CreateMap<FundTransfer, Transaction>()
                .ForMember(des => des.AccountNumber, src => src.MapFrom(u => u.SourceAccountNumber))
                .ForMember(des => des.AccountTypeId, src => src.MapFrom(u => dataService.UsersDataObject.GetAsyncByAccountNumber(u.SourceAccountNumber).Result.AccountTypeId))
                .ForMember(des => des.TransactionType, src => src.MapFrom(u => "IMPS"))
                .ForMember(des => des.TransactionDate, src => src.MapFrom(u => DateTime.Now))
                .ForMember(des => des.Amount, src => src.MapFrom(u => u.TransferAmount));

            CreateMap<User, AccountNumberDTO>();




            CreateMap<AtmPinDTO, AtmDetails>();
            CreateMap<ChangePinDTO, AtmDetails>();

        }

            
        }

    }

