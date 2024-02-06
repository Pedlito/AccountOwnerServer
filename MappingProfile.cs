using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDto>();
        CreateMap<Owner, OwnerAccountsDto>();
        CreateMap<OwnerPostDto, Owner>();
        CreateMap<Account, AccountDto>();
        CreateMap<OwnerPutDto, Owner>();
    }
}