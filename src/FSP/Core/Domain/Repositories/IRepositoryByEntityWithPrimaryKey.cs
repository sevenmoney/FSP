using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FSP.Core.Domain.Entities;

namespace FSP.Core.Domain.Repositories
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">实体主键类型</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : class, IEntity<TPrimaryKey>
    {
        #region 查询

        /// <summary>
        /// 查找所有 返回IQueryable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 根据条件查询 返回返回IQueryable
        /// 1个或者多个
        /// </summary>
        /// <param name="propertySelectors">1个或者多个 lamd表达式</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        /// <summary>
        /// 查询所有 返回List
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAllList();

        /// <summary>
        /// 异步查询
        /// 查询所有 返回List
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllListAsync();

        /// <summary>
        /// 根据条件查询 返回List
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 异步查询
        /// 根据条件查询 返回List
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        TEntity GetEntity(TPrimaryKey id);

        Task<TEntity> GetEntityAsync(TPrimaryKey id);

        TEntity GetSingleEntity(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetSingleEntityAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(TPrimaryKey id);

        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region 新增

        TEntity Insert(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity);

        TPrimaryKey InsertAndGetId(TEntity entity);

        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        #endregion

        #region 更新

        TEntity Update(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        #endregion

        #region 删除

        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);

        void Delete(TPrimaryKey id);

        Task DeleteAsync(TPrimaryKey id);

        void Delete(Expression<Func<TEntity,bool>> predicate);

        Task DeleteAsync(Expression<Func<TEntity,bool>> predicate);

        #endregion
    }
}
