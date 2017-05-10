using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ttu.Domain
{
    public interface IUnitOfWorkRepository<T> where T : class
    {

        void Add(T newEntity);
        void AddAll(T[] newEntities);

        bool Contains(T entity);

        T[] FindAll();
        T[] FindBy(Expression<Func<T, bool>> predicate);
        T[] FindByCaseInSensitive(Expression<Func<T, object>> predicate, string compare);
        T[] FindByChildrenCollection<TChild>(Expression<Func<T, IEnumerable<TChild>>> collection, Expression<Func<TChild, bool>> predicate);
        T FindByRecordId(int recordId);
        T FindByUnique(Expression<Func<T, bool>> predicate);
        T FindSingleOrDefault();

        IQueryable<T> GetQueryable();

        bool IsObjectAlreadyPersistent(T entity);

        void Remove(T entity);
        void RemoveAll(T[] entities);

    }
}
