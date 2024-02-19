using System.Globalization;
using System.Reflection;
using System.Text;
using AccountOwnerServer.Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using System.Linq.Dynamic.Core;

namespace AccountOwnerServer.Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    private IQueryHelper<Account> _sortHelper;

    public AccountRepository(AppDbContext context, IQueryHelper<Account> sortHelper) : base(context)
    {
        this._sortHelper = sortHelper;
    }

    public PagedList<Account> GetAll(AccountParameters parameters)
    {
        var query = FindAll();
        query = _sortHelper.ApplyFilters(query, parameters);
        query = _sortHelper.ApplySort(query, parameters.OrderBy);
        return PagedList<Account>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);
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

    public IEnumerable<Account> AccountsByOwner(int ownerCode)
    {
        return FindByCondition(t => t.OwnerCode.Equals(ownerCode))
            .OrderBy(t => t.OwnerCode)
            .ToList();
    }
}