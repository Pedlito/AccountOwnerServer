using AccountOwnerServer.Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    private IQueryHelper<Account> _queryHelper;

    public AccountRepository(AppDbContext context, IQueryHelper<Account> queryHelper) : base(context)
    {
        this._queryHelper = queryHelper;
    }

    public Task<PagedList<Account>> GetAll(AccountParameters parameters)
    {
        var query = FindAll();
        query = _queryHelper.ApplyFilters(query, parameters);
        query = _queryHelper.ApplySort(query, parameters.OrderBy);
        return PagedList<Account>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<Account?> GetById(int id)
    {
        return await FindByCondition(t => t.Code.Equals(id)).FirstOrDefaultAsync();
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

    public IEnumerable<Account> AccountsByOwner(int ownerCode)
    {
        return FindByCondition(t => t.OwnerCode.Equals(ownerCode))
            .OrderBy(t => t.OwnerCode)
            .ToList();
    }
}