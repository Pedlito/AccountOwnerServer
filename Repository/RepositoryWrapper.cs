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

        private IQueryHelper<Owner> _ownerSortHelper;
        private IQueryHelper<Account> _accountSortHelper;


        public IOwnerRepository Owner {
            get {
                _owner ??= new OwnerRepository(_repoContext, _ownerSortHelper);
                return _owner;
            }
        }
        public IAccountRepository Account {
            get {
                _account ??= new AccountRepository(_repoContext, _accountSortHelper);
                return _account;
            }
        }
        public RepositoryWrapper(AppDbContext repositoryContext, IQueryHelper<Owner> ownerSortHelper, IQueryHelper<Account> accountSortHelper)
        {
            _repoContext = repositoryContext;
            _ownerSortHelper = ownerSortHelper;
            _accountSortHelper = accountSortHelper;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }