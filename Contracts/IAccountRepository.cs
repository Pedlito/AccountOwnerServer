using Entities.Helpers;
using Entities.Models;

namespace AccountOwnerServer.Contracts;

public interface IAccountRepository : IRepositoryBase<Account>
{
    PagedList<Account> GetAll(AccountParameters parameters);
    Account? GetById(int id);
    void CreateItem(Account item);
    void UpdateItem(Account item);
    void DeleteItem(Account item);

    IEnumerable<Account> AccountsByOwner(int id);

}