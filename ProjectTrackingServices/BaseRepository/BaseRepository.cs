using AutoMapper;
using ProjectTrackingServices.BaseRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectTrackingServices
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>  where TEntity: class 
    {
        protected readonly DbContext db;
        protected DbSet<TEntity> context;


        public BaseRepository(DbContext dbContext)
        {
            db = dbContext;
            context = db.Set<TEntity>();
        }

        //Get entity by its id
        public virtual TEntity GetById(TKey id)
        {
            return context.Find(id);
        }

        //Get all entities
        public virtual IEnumerable<TEntity> GetAll()
        {
            return context.ToList();
        }

        //Find only where the constraint is accomplished
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Where(predicate);
        }

        //Add single entity to database table
        public TEntity Add(TEntity entity)
        {
            context.Attach(entity);
            return context.Add(entity);
        }

        //Add entity in bulk to database table
        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                context.Attach(entity);
            }
            return context.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            context.Attach(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach ( var entity in entities)
            {
                context.Attach(entity);
            }
        }

        public virtual void Remove(TKey id)
        {
            TEntity entityToRemove = context.Find(id);
            if(entityToRemove != null)
            {
                context.Remove(entityToRemove);
            }
        }

        public virtual void RemoveRange(IEnumerable<TKey> ids)
        {
            foreach (var id in ids)
            {
                TEntity entityToRemove = context.Find(id);
                if(entityToRemove != null)
                {
                    context.Remove(entityToRemove);
                }
            }
        }



    }
}