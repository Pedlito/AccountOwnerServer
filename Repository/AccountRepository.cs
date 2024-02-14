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
    private ISortHelper<Account> _sortHelper;

    public AccountRepository(AppDbContext context, ISortHelper<Account> sortHelper) : base(context)
    {
        this._sortHelper = sortHelper;
    }

    public PagedList<Account> GetAll(AccountParameters parameters)
    {
        var query = FindAll();

        ApplyParams(ref query, parameters);

        return PagedList<Account>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);
    }

    private void ApplyParams(ref IQueryable<Account> query, AccountParameters parameters)
    {
        var parametersProperties = typeof(AccountParameters).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var objectProperties = typeof(Account).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var whereString = new StringBuilder();
        foreach (PropertyInfo param in parametersProperties)
        {
            var objProperty = objectProperties.FirstOrDefault(obj => obj.Name.Equals(param.Name, StringComparison.InvariantCultureIgnoreCase));

            if (objProperty == null)
            {
                continue;
            }

            if (param.GetValue(parameters) == null)
            {
                continue;
            }

            if (whereString.Length > 1)
            {
                whereString.Append(" and ");
            }

            if (param.PropertyType == typeof(string))
            {
                whereString.Append($"{objProperty.Name}.ToLower().Contains(\"{param.GetValue(parameters)!.ToString()!.ToLowerInvariant()}\")");
            }
            else
            {
                whereString.Append($"{objProperty.Name} = {param.GetValue(parameters)}");

            }
        }

        if (whereString.Length > 0)
        {
            query = query.Where(whereString.ToString());
        }
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