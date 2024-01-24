using System.Linq.Expressions;
using AccountOwnerServer.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountOwnerServer.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext AppDbContext { get; set; } 
        public RepositoryBase(AppDbContext repositoryContext) 
        {
            AppDbContext = repositoryContext; 
        }
        public IQueryable<T> FindAll() => AppDbContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
            AppDbContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => AppDbContext.Set<T>().Add(entity);
        public void Update(T entity) => AppDbContext.Set<T>().Update(entity);
        public void Delete(T entity) => AppDbContext.Set<T>().Remove(entity);
    }