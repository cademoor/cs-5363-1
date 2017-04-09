using NHibernate.Exceptions;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using Ttu.Domain;

namespace Ttu.Service
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Utility

        public static PersistenceException LogAndWrapException(string customExceptionPrefix, Exception ex)
        {
            // guard clause - already handled appropriately
            PersistenceException persistenceException = ex as PersistenceException;
            if (persistenceException != null)
            {
                return persistenceException;
            }

            IApplicationLogger logger = GetLogger();
            persistenceException = CreatePersistenceException(customExceptionPrefix, ex);
            logger.Error(persistenceException.Message);
            LogExceptionMessage(persistenceException.InnerException, logger);
            return persistenceException;
        }

        public static void LogExceptionMessage(Exception exception, IApplicationLogger logger)
        {
            // guard clause - invalid exception
            if (exception == null)
            {
                return;
            }

            SqlException sqlException = exception as SqlException;
            if (sqlException == null)
            {
                string message = string.Format("APP Error: {0}", exception.Message);
                logger.Error(message);
                logger.Debug(exception);
            }
            else
            {
                string message = string.Format("SQL Error: Number {0} Class {1} - {2}", sqlException.Number, sqlException.Class, sqlException.Message);
                logger.Error(message);
                logger.Debug(sqlException);
            }
        }

        protected static PersistenceException CreatePersistenceException(string customExceptionPrefix, Exception originalException)
        {
            Exception mostAppropriateException = GetAppropriateException(originalException);

            string exceptionMessage = string.Format("{0} - {1}", customExceptionPrefix, mostAppropriateException.Message);
            return new PersistenceException(exceptionMessage, mostAppropriateException);
        }

        protected static Exception GetAppropriateException(Exception ex)
        {
            // guard clause - not a database exception
            DbException dbException = ADOExceptionHelper.ExtractDbException(ex);
            if (dbException == null)
            {
                return ex;
            }

            // guard clause - not an SQL exception
            SqlException sqlException = dbException as SqlException;
            if (sqlException == null)
            {
                return dbException;
            }

            return sqlException;
        }

        protected static IApplicationLogger GetLogger()
        {
            return ApplicationLogger.GetLogger(typeof(UnitOfWork));
        }

        #endregion

        #region Constructors

        public UnitOfWork(SessionDecorator session, IUser user)
        {
            Session = session;
            User = user;
        }

        #endregion

        #region Properties

        public string SessionId { get { return Session.SessionId; } }
        public IUser User { get; set; }

        public IUnitOfWorkRepository<IRecommendation> Recommendations { get { return CreateUowRepository<IRecommendation>(); } }
        public IUnitOfWorkRepository<IUser> Users { get { return CreateUowRepository<IUser>(); } }
        public IUnitOfWorkRepository<IVolunteerProfile> VolunteerProfiles { get { return CreateUowRepository<IVolunteerProfile>(); } }
        public IUnitOfWorkRepository<IVolunteerProfileReview> VolunteerProfileReviews { get { return CreateUowRepository<IVolunteerProfileReview>(); } }

        private SessionDecorator Session { get; set; }

        #endregion

        #region Public Methods

        public void Abort()
        {
            try
            {
                Session.Clear();
            }
            catch (Exception ex)
            {
                throw LogAndWrapException("Problem abandoning(clearing) changes", ex);
            }
        }

        public void Commit()
        {
            try
            {
                Session.Flush();
            }
            catch (Exception ex)
            {
                throw LogAndWrapException("Problem saving(committing/flushing) changes", ex);
            }
        }

        public void Release()
        {
            Session.ClearAndReleaseSafely();
        }

        public void Reset()
        {
            Abort();

            IUser persistentUser = Users.FindByRecordId(User.RecordId);
            if (persistentUser != null)
            {
                User = persistentUser;
            }
        }

        #endregion

        #region Helper Methods

        private IUnitOfWorkRepository<T> CreateUowRepository<T>() where T : class
        {
            return new UnitOfWorkRepository<T>(Session);
        }

        #endregion

    }
}
