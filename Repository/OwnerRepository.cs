using AccountOwnerServer.Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(AppDbContext context) : base(context)
    {
    }

    public PagedList<Owner> GetAll(OwnerParameters parameters)
    {
        var query = FindByCondition(t => t.DateOfBirth.Year >= parameters.MinYearBirth && t.DateOfBirth.Year <= parameters.MaxYearBirth)
            .OrderBy(t => t.Code);
            
        return PagedList<Owner>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);
    }

    public Owner? GetById(int id)
    {
        return FindByCondition(owner => owner.Code.Equals(id)).FirstOrDefault();
    }

    public Owner? GetWithDetails(int id)
    {
        return FindByCondition(owner => owner.Code.Equals(id)).Include(t => t.Accounts).FirstOrDefault();
    }

    public void CreateItem(Owner item)
    {
        item.IsEnable = true;
        item.CreateDate = DateTime.Now;
        Create(item);
    }

    public void UpdateItem(Owner item)
    {
        item.UpdateDate = DateTime.Now;
        item.UpdateUser = 5;
        Update(item);
    }

    public void DeleteItem(Owner item)
    {
        item.IsEnable = false;
        item.DeleteDate = DateTime.Now;
        item.UpdateUser = 6;
        Update(item);
    }
}