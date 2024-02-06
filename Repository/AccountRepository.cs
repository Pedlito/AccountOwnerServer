using AccountOwnerServer.Contracts;
using Entities;
using Entities.Models;

namespace AccountOwnerServer.Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
        
    }

    public IEnumerable<Account> AccountsByOwner(int ownerCode)
    {
        return FindByCondition(t => t.OwnerCode.Equals(ownerCode))
            .OrderBy(t => t.OwnerCode)
            .ToList();
    }
}