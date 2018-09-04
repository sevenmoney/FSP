using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using FSP.Core.Collections.Extensions;
using FSP.Core.Domain.Entities;
using FSP.Core.Domain.Repositories;
using FSP.Datas.EfCore.ContextProvider;
using Microsoft.EntityFrameworkCore;

namespace FSP.Datas.EfCore.Repositories
{
    public class EfRepositoryBase<TDbContext,TEntity,TPrimaryKey>:FspRepositoryBase<TEntity,TPrimaryKey>,IRepositoryWithDbcontext 
        where TDbContext : DbContext
        where TEntity:class ,IEntity<TPrimaryKey>
    {
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        
        public EfRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider) {
            _dbContextProvider = dbContextProvider;
        }

        public virtual TDbContext Context => _dbContextProvider.GetDbContext();
        public virtual DbSet<TEntity> Table => Context.Set<TEntity>();

        public override IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors) {
            var query = Table.AsQueryable();

            if (!propertySelectors.IsNullOrEmpty()) {
                foreach (var propertySelector in propertySelectors) {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }

        public override IQueryable<TEntity> GetAll() {
            return GetAllIncluding();
        }

        public override TEntity Insert(TEntity entity) {
            return Table.Add(entity).Entity;
        }

        public override TEntity Update(TEntity entity) {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override void Delete(TEntity entity) {
            Table.Remove(entity);
        }

        public override void Delete(TPrimaryKey id) {
            throw new System.NotImplementedException();
        }

        public DbContext GetDbContext() {
            throw new System.NotImplementedException();
        }
    }
}