using AccountOwnerServer.Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    private IQueryHelper<User> _queryHelper;

    public UserRepository(AppDbContext context, IQueryHelper<User> queryHelper) : base(context)
    {
        this._queryHelper = queryHelper;
    }

    public async Task<PagedList<User>> GetAll(UserParameters parameters)
    {
        var query = FindAll();
        query = _queryHelper.ApplyFilters(query, parameters);
        query = _queryHelper.ApplySort(query, parameters.OrderBy);
        return await PagedList<User>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<User?> GetById(int id)
    {
        return await FindByCondition(t => t.Code.Equals(id)).FirstOrDefaultAsync();
    }

    public void CreateItem(User item)
    {
        item.CreateDate = DateTime.Now;
        item.CreateUser = 1;
        item.IsEnable = true;
        Create(item);
    }

    public void UpdateItem(User item)
    {
        item.UpdateDate = DateTime.Now;
        item.UpdateUser = 3;
        Update(item);
    }

    public void DeleteItem(User item)
    {
        item.DeleteDate = DateTime.Now;
        item.IsEnable = false;
        item.UpdateUser = 2;
        Update(item);
    }
}