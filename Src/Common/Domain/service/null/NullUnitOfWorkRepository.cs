using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ttu.Domain
{
    public class NullUnitOfWorkRepository<T> : IUnitOfWorkRepository<T> where T : class
    {

        public static NullUnitOfWorkRepository<T> Singleton = new NullUnitOfWorkRepository<T>();

        #region Public Methods

        public void Add(T newEntity)
        {
            // do nothing
        }

        public void AddAll(T[] newEntities)
        {
            // do nothing
        }

        public bool Contains(T entity)
        {
            return false;
        }

        public void Evict(T newEntity)
        {
            // do nothing
        }

        public T[] FindAll()
        {
            return new T[0];
        }

        public T[] FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return new T[0];
        }

        public T[] FindByCaseInSensitive(Expression<Func<T, object>> predicate, string compare)
        {
            return new T[0]; 
        }

        public T[] FindByChildrenCollection<TChild>(Expression<Func<T, IEnumerable<TChild>>> collection, Expression<Func<TChild, bool>> predicate)
        {
            return new T[0];
        }

        public T FindByRecordId(int recordId)
        {
            return null as T;
        }

        public T FindByUnique(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return null as T;
        }

        public T FindSingleOrDefault()
        {
            return null as T;
        }

        public IQueryable<T> GetQueryable()
        {
            return null;
        }

        public bool IsObjectAlreadyPersistent(T entity)
        {
            return false;
        }

        public void Remove(T entity)
        {
            // do nothing
        }

        public void RemoveAll(T[] entities)
        {
            // do nothing
        }

        #endregion

    }
}
