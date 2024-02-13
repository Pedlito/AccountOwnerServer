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

        private ISortHelper<Owner> _ownerSortHelper;


        public IOwnerRepository Owner {
            get {
                _owner ??= new OwnerRepository(_repoContext, _ownerSortHelper);
                return _owner;
            }
        }
        public IAccountRepository Account {
            get {
                _account ??= new AccountRepository(_repoContext);
                return _account;
            }
        }
        public RepositoryWrapper(AppDbContext repositoryContext, ISortHelper<Owner> ownerSortHelper)
        {
            _repoContext = repositoryContext;
            _ownerSortHelper = ownerSortHelper;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }