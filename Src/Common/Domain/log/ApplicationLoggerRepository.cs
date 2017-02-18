using System;

namespace Ttu.Domain
{
    public class ApplicationLoggerRepository : IThreadSafeMapValueFactory<IApplicationLogger>
    {

        public static ApplicationLoggerRepository Singleton = new ApplicationLoggerRepository();

        #region Constants

        private const string DEFAULT_LOGGER_ID = "Ttu.Domain.Default";

        #endregion

        #region Constructors

        public ApplicationLoggerRepository()
        {
            LoggerMap = new ThreadSafeMap<string, IApplicationLogger>();
        }

        #endregion

        #region Properties

        private static ThreadSafeMap<string, IApplicationLogger> LoggerMap { get; set; }

        #endregion

        #region Public Methods - ApplicationLoggerRepository

        public IApplicationLogger FindOrCreateApplicationLogger(string loggerId)
        {
            return LoggerMap.FindOrCreate(loggerId, this, loggerId);
        }

        public IApplicationLogger FindOrCreateApplicationLogger(Type type)
        {
            return FindOrCreateApplicationLogger(type.FullName);
        }

        public void SetLoggerForType(Type type, IApplicationLogger logger)
        {
            LoggerMap[type.FullName] = logger;
        }

        #endregion

        #region Public Methods - IThreadSafeMapValueFactory

        public IApplicationLogger CreateMapValue(object newValueArg)
        {
            // guard clause
            if (newValueArg == null)
            {
                return new ApplicationLogger(DEFAULT_LOGGER_ID);
            }

            string loggerId = newValueArg.ToString();
            return new ApplicationLogger(loggerId);
        }

        #endregion

    }
}
