using Entities.Helpers;
using Entities.Models;

namespace AccountOwnerServer.Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    Task<PagedList<Owner>> GetAll(OwnerParameters parameters);
    Task<Owner?> GetById(int ownerId);
    Task<Owner?> GetWithDetails(int ownerId);
    void CreateItem(Owner owner);
    void UpdateItem(Owner owner);
    void DeleteItem(Owner owner);
}