using AccountOwnerServer.Contracts;
using Entities;
using Entities.Helpers;
using Entities.Models;

namespace AccountOwnerServer.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private AppDbContext _repoContext;
    private IOwnerRepository? _owner;
    private IAccountRepository? _account;
    private IUserRepository? _user;

    private IQueryHelper<Owner> _ownerQueryHelper;
    private IQueryHelper<Account> _accountQueryHelper;
    private IQueryHelper<User> _userQueryHelper;


    public IOwnerRepository Owner
    {
        get
        {
            _owner ??= new OwnerRepository(_repoContext, _ownerQueryHelper);
            return _owner;
        }
    }
    public IAccountRepository Account
    {
        get
        {
            _account ??= new AccountRepository(_repoContext, _accountQueryHelper);
            return _account;
        }
    }

    public IUserRepository User
    {
        get
        {
            _user = new UserRepository(_repoContext, _userQueryHelper);
            return _user;
        }
    }

    public RepositoryWrapper(
        AppDbContext repositoryContext,
        IQueryHelper<Owner> ownerQueryHelper,
        IQueryHelper<Account> accountQueryHelper,
        IQueryHelper<User> userQueryHelper
        )
    {
        _repoContext = repositoryContext;
        _ownerQueryHelper = ownerQueryHelper;
        _accountQueryHelper = accountQueryHelper;
        _userQueryHelper = userQueryHelper;
    }

    public async Task SaveAsync()
    {
        await _repoContext.SaveChangesAsync();
    }
}