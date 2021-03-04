using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpreadJsDemoApi
{
   
    public class EFHelper
    {
        private readonly SpreadContext _db;
        public EFHelper(SpreadContext context)
        {
            _db = context;
        }
        public virtual IQueryable<TEntity> Quyery<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>();
        }


        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="pre"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Quyery<TEntity>(Expression<Func<TEntity, bool>> pre) where TEntity : class
        {

            return _db.Set<TEntity>().Where(pre);
        }


        /// <summary>
        /// 根据ID查询单个实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="pre"></param>
        /// <returns></returns>
        public virtual TEntity QuyeryByID<TEntity>(int id) where TEntity : class, BaseEntity
        {
            return _db.Set<TEntity>().Where(a => a.Id.Equals(id)).First();
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public virtual void Add<TEntity>(TEntity entity) where TEntity : class, BaseEntity
        {
            _db.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="listEntity"></param>
        public virtual void Add<TEntity>(List<TEntity> listEntity) where TEntity : class, BaseEntity
        {
            _db.Set<TEntity>().AddRange(listEntity);
        }


        /// <summary>
        /// 根据传入条件删除数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="pre"></param>
        public virtual void Delete<TEntity>(Expression<Func<TEntity, bool>> pre) where TEntity : class
        {
            var dele = this.Quyery(pre).FirstOrDefault();
            if (dele != null)
                this.Delete(dele);
        }
        /// <summary>
        /// 根据实体标记删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _db.Set<TEntity>().Remove(entity);
        }
        /// <summary>
        /// 批量标记删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="listEntity"></param>
        public virtual void Delete<TEntity>(List<TEntity> listEntity) where TEntity : class, BaseEntity
        {
            _db.Set<TEntity>().RemoveRange(listEntity);
        }



        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        public virtual void SaveChanges()
        {
            _db.SaveChanges();
            _db.Dispose();
        }
    }
}
