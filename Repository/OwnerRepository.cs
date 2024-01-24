using AccountOwnerServer.Contracts;
using Entities;
using Entities.Models;

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
}