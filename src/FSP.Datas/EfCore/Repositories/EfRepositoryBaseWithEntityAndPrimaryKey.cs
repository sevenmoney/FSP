using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
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
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public override Task<TEntity> UpdateAsync(TEntity entity) {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        public override void Delete(TEntity entity) {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        public override void Delete(TPrimaryKey id) {
            var entity = GetFromChangeTrackerOrNull(id);
            if(entity != null) {
                Delete(entity);
                return;
            }

            entity = FirstOrDefault(id);
            if(entity != null) {
                Delete(entity);
                return;
            }
        }

        public DbContext GetDbContext() {
            return Context;
        }

        /// <summary>
        /// 实体不存在则附加到数据表中
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void AttachIfNot(TEntity entity) {
            var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if(entry != null) {
                return;
            }

            Table.Attach(entity);
        }

        /// <summary>
        /// 根据主键Id获取追踪列表中的实体
        /// 没有则返回null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id) {
            var entry = Context.ChangeTracker.Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity &&
                        EqualityComparer<TPrimaryKey>.Default.Equals(id, (ent.Entity as TEntity).Id)
                );

            return entry?.Entity as TEntity;
        }
    }
}