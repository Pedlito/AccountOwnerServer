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
        CreateMap<OwnerPostAccountsDto, Owner>().ForMember(t => t.Accounts, opt => opt.Ignore());
        CreateMap<Account, AccountDto>();
        CreateMap<OwnerPutDto, Owner>();

        // Account mapping
        CreateMap<Account, AccountDto>();
        CreateMap<AccountPostDto, Account>();
        CreateMap<AccountPutDto, Account>();
        CreateMap<OwnerAccountPostDto, Account>();
    }
}