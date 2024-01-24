using AccountOwnerServer.Contracts;
using Entities;

namespace AccountOwnerServer.Repository;

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _repoContext;
        private IOwnerRepository? _owner;
        private IAccountRepository? _account;
        public IOwnerRepository Owner {
            get {
                _owner ??= new OwnerRepository(_repoContext);
                return _owner;
            }
        }
        public IAccountRepository Account {
            get {
                _account ??= new AccountRepository(_repoContext);
                return _account;
            }
        }
        public RepositoryWrapper(AppDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }