using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FSP.Core.Domain.Entities;

namespace FSP.Core.Domain.Repositories
{
    public abstract class FspRepositoryBase<TEntity,TPrimaryKey>:IRepository<TEntity, TPrimaryKey> where TEntity:class ,IEntity<TPrimaryKey>
    {
        #region 查询

        public abstract IQueryable<TEntity> GetAll();

        public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors) {
            //todo??
            return GetAll();
        }

        public virtual List<TEntity> GetAllList() {
            return GetAll().ToList();
        }

        public virtual Task<List<TEntity>> GetAllListAsync() {
            return Task.FromResult(GetAllList());
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate) {
            return GetAll().Where(predicate).ToList();
        }

        public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate) {
            return Task.FromResult(GetAllList(predicate));
        }

        public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod) {
            return queryMethod(GetAll());
        }

        public virtual TEntity GetEntity(TPrimaryKey id) {
            return FirstOrDefault(id);
        }

        public virtual Task<TEntity> GetEntityAsync(TPrimaryKey id) {
            return Task.FromResult(GetEntity(id));
        }

        public virtual TEntity GetSingleEntity(Expression<Func<TEntity, bool>> predicate) {
            return FirstOrDefault(predicate);
        }

        public virtual Task<TEntity> GetSingleEntityAsync(Expression<Func<TEntity, bool>> predicate) {
            return Task.FromResult(GetSingleEntity(predicate));
        }

        public virtual TEntity FirstOrDefault(TPrimaryKey id) {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id) {
            return Task.FromResult(FirstOrDefault(id));
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) {
            return GetAll().FirstOrDefault(predicate);
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
            return Task.FromResult(FirstOrDefault(predicate));
        }

        #endregion

        #region 新增

        public abstract TEntity Insert(TEntity entity);

        public virtual Task<TEntity> InsertAsync(TEntity entity) {
            return Task.FromResult(Insert(entity));
        }

        public virtual TPrimaryKey InsertAndGetId(TEntity entity) {
            return Insert(entity).Id;
        }

        public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity) {
            return Task.FromResult(InsertAndGetId(entity));
        }

        #endregion

        #region 更新-修改

        public abstract TEntity Update(TEntity entity);

        public virtual Task<TEntity> UpdateAsync(TEntity entity) {
            return Task.FromResult(Update(entity));
        }

        #endregion

        #region 删除

        public abstract void Delete(TEntity entity);
        public virtual Task DeleteAsync(TEntity entity) {
            Delete(entity);
            return Task.FromResult(0);
        }

        public abstract void Delete(TPrimaryKey id);

        public virtual Task DeleteAsync(TPrimaryKey id) {
            Delete(id);
            return Task.FromResult(0);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate) {
            foreach (var entity in GetAll().Where(predicate).ToList()) {
                Delete(entity);
            }
        }

        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate) {
            Delete(predicate);
            return Task.FromResult(0);
        }

        #endregion

        /// <summary>
        /// 获取Entity主键Equals的lambda表达式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id) {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
            );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}