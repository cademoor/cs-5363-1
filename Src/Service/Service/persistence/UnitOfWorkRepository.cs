using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ttu.Domain;

namespace Ttu.Service
{
    public class UnitOfWorkRepository<T> : IUnitOfWorkRepository<T> where T : class
    {

        # region Constructors

        public UnitOfWorkRepository(SessionDecorator session)
        {
            Session = session;
        }

        # endregion

        # region Properties

        private SessionDecorator Session { get; set; }

        # endregion

        # region Public Methods

        public void Add(T newEntity)
        {
            // guard clause - nothing to do
            if (newEntity == null)
            {
                return;
            }

            try
            {
                Session.Save(newEntity);
            }
            catch (HibernateException ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem saving object", ex);
            }
        }

        public void AddAll(T[] newEntities)
        {
            // guard clause - nothing to do
            if (newEntities.Length == 0)
            {
                return;
            }

            try
            {
                foreach (T newEntity in newEntities)
                {
                    Add(newEntity);
                }
            }
            catch (HibernateException ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem saving objects", ex);
            }
        }

        public bool Contains(T entity)
        {
            return Session.Contains(entity);
        }

        public ICriteria CreateCriteria()
        {
            return Session.CreateCriteria<T>();
        }

        public ICriteria CreateCriteria(string alias)
        {
            return Session.CreateCriteria<T>(alias);
        }

        public T[] FindAll()
        {
            try
            {
                IQueryOver<T> queryOver = Session.QueryOver<T>();
                IList<T> result = queryOver.List<T>();
                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem querying objects", ex);
            }
        }

        public T[] FindBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryOver<T, T> queryOver = Session.QueryOver<T>();
                queryOver = queryOver.Where(predicate);
                IList<T> result = queryOver.List<T>();
                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem querying objects", ex);
            }
        }

        public T[] FindByChildrenCollection<TChild>(Expression<Func<T, IEnumerable<TChild>>> collection, Expression<Func<TChild, bool>> predicate)
        {
            try
            {
                IList<T> result = Session.QueryOver<T>().JoinQueryOver<TChild>(collection).Where(predicate).List<T>();
                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem querying objects", ex);
            }
        }

        public T FindByRecordId(int recordId)
        {
            try
            {
                T result = Session.Get<T>(recordId);
                return result;
            }
            catch (Exception ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem querying object", ex);
            }
        }

        public T FindByUnique(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryOver<T, T> queryOver = Session.QueryOver<T>();
                T result = queryOver.Where(predicate).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem querying object", ex);
            }
        }

        public T FindSingleOrDefault()
        {
            try
            {
                IQueryable<T> queryable = GetQueryable();
                return queryable.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem querying object", ex);
            }
        }

        public IQueryable<T> GetQueryable()
        {
            return Session.Query<T>();
        }

        public bool IsObjectAlreadyPersistent(T entity)
        {
            try
            {
                return Session.GetIdentifier(entity) != null;
            }
            catch (HibernateException ex)
            {
                UnitOfWork.LogAndWrapException("Problem checking object persistence", ex);
                return false;
            }
        }

        public void Remove(T entity)
        {
            try
            {
                Session.Delete(entity);
            }
            catch (HibernateException ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem deleting object", ex);
            }
        }

        public void RemoveAll(T[] entities)
        {
            // guard clause
            if (entities.Length == 0)
            {
                return;
            }

            try
            {
                foreach (T entity in entities)
                {
                    Remove(entity);
                }
            }
            catch (HibernateException ex)
            {
                throw UnitOfWork.LogAndWrapException("Problem deleting objects", ex);
            }
        }

        # endregion

    }
}
