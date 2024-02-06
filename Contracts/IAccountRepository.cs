using Entities.Models;

namespace AccountOwnerServer.Contracts;

public interface IAccountRepository : IRepositoryBase<Account>
{
    IEnumerable<Account> AccountsByOwner(int ownerId);
}