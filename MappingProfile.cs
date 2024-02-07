using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Owner mapping
        CreateMap<Owner, OwnerDto>();
        CreateMap<Owner, OwnerAccountsDto>();
        CreateMap<OwnerPostDto, Owner>();
        CreateMap<Account, AccountDto>();
        CreateMap<OwnerPutDto, Owner>();

        // Account mapping
        CreateMap<Account, AccountDto>();
        CreateMap<AccountPostDto, Account>();
        CreateMap<AccountPutDto, Account>();
    }
}