using AccountOwnerServer.Contracts;
using Entities;
using Entities.Models;

namespace AccountOwnerServer.Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
        
    }
}