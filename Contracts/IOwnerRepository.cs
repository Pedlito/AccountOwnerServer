using Entities.Models;

namespace AccountOwnerServer.Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    IEnumerable<Owner> GetAll();
    Owner? GetById(int ownerId);
    Owner? GetWithDetails(int ownerId);
    void CreateItem(Owner owner);
    void UpdateItem(Owner owner);
    void DeleteItem(Owner owner);
}