using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockUnitOfWorkRepository<T> : IUnitOfWorkRepository<T> where T : class
    {

        # region Constructors

        public MockUnitOfWorkRepository()
        {
            Items = new List<T>();
        }

        # endregion

        # region Properties

        public List<T> Items { get; set; }

        # endregion

        # region Public Methods

        public void Add(T newEntity)
        {
            Items.Add(newEntity);
        }

        public void AddAll(T[] newEntities)
        {
            foreach (T newEntity in newEntities)
            {
                Items.Add(newEntity);
            }
        }

        public bool Contains(T entity)
        {
            return true;
        }

        public void Evict(T newEntity)
        {
            // do nothing
        }

        public T[] FindAll()
        {
            return Items.ToArray();
        }

        public T[] FindBy(Expression<Func<T, bool>> predicate)
        {
            return Items.Where(predicate.Compile()).ToArray();
        }

        public T[] FindByChildrenCollection<TChild>(Expression<Func<T, IEnumerable<TChild>>> collection, Expression<Func<TChild, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T FindByRecordId(int recordId)
        {
            return Items.FirstOrDefault(item => (int)item.GetType().GetProperty("RecordId").GetValue(item, null) == recordId);
        }

        public T FindByUnique(Expression<Func<T, bool>> predicate)
        {
            return Items.SingleOrDefault(predicate.Compile());
        }

        public T FindSingleOrDefault()
        {
            return Items.SingleOrDefault();
        }

        public IQueryable<T> GetQueryable()
        {
            return Items.AsQueryable();
        }

        public bool IsObjectAlreadyPersistent(T entity)
        {
            return Items.IndexOf(entity) >= 0;
        }

        public void Remove(T entity)
        {
            Items.Remove(entity);
        }

        public void RemoveAll(T[] entities)
        {
            foreach (T entity in entities)
            {
                Items.Remove(entity);
            }
        }

        # endregion

    }
}
