using Entities.Helpers;
using Entities.Models;

namespace AccountOwnerServer.Contracts;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<PagedList<User>> GetAll(UserParameters parameters);
    Task<User?> GetById(int id);
    void CreateItem(User item);
    void UpdateItem(User item);
    void DeleteItem(User item);
}