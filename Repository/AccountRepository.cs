using AccountOwnerServer.Contracts;
using Entities;
using Entities.Models;

namespace AccountOwnerServer.Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
        
    }

    public IEnumerable<Account> GetAll()
    {
        return FindAll().OrderBy(t => t.OwnerCode).ToList();
    }

    public Account? GetById(int id)
    {
        return FindByCondition(t => t.Code.Equals(id)).FirstOrDefault();
    }

    public void CreateItem(Account item)
    {
        item.CreateDate = DateTime.Now;
        item.CreateUser = 10;
        item.IsEnable = true;
        Create(item);
    }

    public void UpdateItem(Account item)
    {
        item.UpdateDate = DateTime.Now;
        item.UpdateUser = 1;
        Update(item);
    }

    public void DeleteItem(Account item)
    {
        item.IsEnable = false;
        item.DeleteDate = DateTime.Now;
        item.UpdateUser = 34;
        Update(item);
    }
}