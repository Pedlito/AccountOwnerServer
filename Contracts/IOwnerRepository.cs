using Entities.Models;

namespace AccountOwnerServer.Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    IEnumerable<Owner> GetAllOwners();
    Owner? GetOwnerById(int ownerId);
    Owner? GetOwnerWithDetails(int ownerId);
    void CreateOwner(Owner owner);
    void UpdateOwner(Owner owner);
    void DeleteOwner(Owner owner);
}