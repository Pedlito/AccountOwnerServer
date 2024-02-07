using AccountOwnerServer.Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(AppDbContext context) : base(context)
    {
    }

    public IEnumerable<Owner> GetAll()
    {
        return FindAll()
            .OrderBy(ow => ow.Name)
            .ToList();
    }

    public Owner? GetById(int id)
    {
        return FindByCondition(owner =>owner.Code.Equals(id)).FirstOrDefault();
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