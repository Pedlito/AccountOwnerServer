using AccountOwnerServer.Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(AppDbContext context) : base(context)
    {
    }

    public IEnumerable<Owner> GetAllOwners()
    {
        return FindAll()
            .OrderBy(ow => ow.Name)
            .ToList();
    }

    public Owner? GetOwnerById(int ownerId)
    {
        return FindByCondition(owner =>owner.Code.Equals(ownerId)).FirstOrDefault();
    }

    public Owner? GetOwnerWithDetails(int ownerId)
    {
        return FindByCondition(owner => owner.Code.Equals(ownerId)).Include(t => t.Accounts).FirstOrDefault();
    }

    public void CreateOwner(Owner owner)
    {
        Create(owner);
    }

    public void UpdateOwner(Owner owner)
    {
        Update(owner);
    }
}