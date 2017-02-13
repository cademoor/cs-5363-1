using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using Ttu.Domain;

namespace Ttu.Service
{
    public class SessionDecorator
    {

        # region Constructors

        public SessionDecorator(ISession session, string sessionId)
        {
            SessionId = sessionId;
            StatefulComponent = session;
        }

        # endregion

        # region Properties

        public string SessionId { get; private set; }
        public ISession StatefulComponent { get; private set; }

        # endregion

        # region Public Methods - ISessionDecorator

        public void Clear()
        {
            if (StatefulComponent.IsOpen)
            {
                GetLogger().Trace(string.Format("Clearing session: {0}", GetHashCode()));
                StatefulComponent.Clear();
            }
            else
            {
                GetLogger().Trace(string.Format("Cannot clear session: {0} (already closed)", GetHashCode()));
            }
        }

        public void ClearAndReleaseSafely()
        {
            ClearSafely();
            ReleaseSafely();
        }

        public void Close()
        {
            if (StatefulComponent.IsOpen)
            {
                StatefulComponent.Close();
            }
        }

        public bool Contains(object entity)
        {
            return StatefulComponent.Contains(entity);
        }

        public ICriteria CreateCriteria<T>() where T : class
        {
            return StatefulComponent.CreateCriteria<T>();
        }

        public ICriteria CreateCriteria<T>(string alias) where T : class
        {
            return StatefulComponent.CreateCriteria<T>(alias);
        }

        public void Delete(object obj)
        {
            StatefulComponent.Delete(obj);
        }

        public void Flush()
        {
            StatefulTransaction(StatefulComponent.Flush);
        }

        public T Get<T>(object id)
        {
            return StatefulComponent.Get<T>(id);
        }

        public object GetIdentifier(object obj)
        {
            return StatefulComponent.GetIdentifier(obj);
        }

        public bool IsOpen()
        {
            return StatefulComponent.IsOpen;
        }

        public IQueryable<T> Query<T>()
        {
            return StatefulComponent.Query<T>();
        }

        public IQueryOver<T, T> QueryOver<T>() where T : class
        {
            return StatefulComponent.QueryOver<T>();
        }

        public void Release()
        {
            Close();
        }

        public object Save(object obj)
        {
            return StatefulComponent.Save(obj);
        }

        public void Update(object obj)
        {
            StatefulComponent.Update(obj);
        }

        # endregion

        # region Helper Methods

        private void ClearSafely()
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                string prefix = string.Format("Problem clearing stateful session {0}", GetHashCode());
                UnitOfWork.LogAndWrapException(prefix, ex);
            }
        }

        private IApplicationLogger GetLogger()
        {
            return ApplicationLogger.GetLogger(GetType());
        }

        private void ReleaseSafely()
        {
            try
            {
                Release();
            }
            catch (Exception ex)
            {
                string prefix = string.Format("Problem releasing stateful session {0}", GetHashCode());
                UnitOfWork.LogAndWrapException(prefix, ex);
            }
        }

        private void RollbackSafely()
        {
            // guard clause - null check
            if (StatefulComponent.Transaction == null)
            {
                return;
            }

            try
            {
                StatefulComponent.Transaction.Rollback();
            }
            catch (Exception ex)
            {
                UnitOfWork.LogAndWrapException("Rollback session problem", ex);
            }
        }

        private void StatefulTransaction(Action action)
        {
            try
            {
                StatefulComponent.BeginTransaction();
                action();
                StatefulComponent.Transaction.Commit();
            }
            catch (StaleObjectStateException ex)
            {
                string prefix = string.Format("StaleObjectStateException was thrown by flush of session {0} (re-thrown as HibernateException)", GetHashCode());
                UnitOfWork.LogAndWrapException(prefix, ex);
                RollbackSafely();
                StatefulComponent.Clear();
                throw new HibernateException(ex.Message, ex);
            }
            catch (HibernateException ex)
            {
                string prefix = string.Format("HibernateException was thrown by flush of session {0}", GetHashCode());
                UnitOfWork.LogAndWrapException(prefix, ex);
                RollbackSafely();
                StatefulComponent.Clear();
                throw;
            }
            catch (Exception ex)
            {
                string prefix = string.Format("Exception was thrown by flush of session {0}", GetHashCode());
                UnitOfWork.LogAndWrapException(prefix, ex);
                RollbackSafely();
                StatefulComponent.Clear();
                throw;
            }
        }

        # endregion

    }
}
