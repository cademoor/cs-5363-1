using NLog;

namespace Ttu.Domain
{
    public abstract class AbstractLogger
    {

        public const string ID_SEPARATOR = "::";

        #region Constructors

        protected AbstractLogger(string loggerId)
        {
            LoggerId = loggerId;
        }

        #endregion

        #region Properties

        protected string LoggerId { get; set; }

        private Logger Logger { get; set; }

        #endregion

        #region Public Methods (IO)

        public void Debug(object message)
        {
            if (GetLogger().IsDebugEnabled)
            {
                GetLogger().Debug(message);
            }
        }

        public void Error(object message)
        {
            if (GetLogger().IsErrorEnabled)
            {
                GetLogger().Error(message);
            }
        }

        public void Fatal(object message)
        {
            if (GetLogger().IsFatalEnabled)
            {
                GetLogger().Fatal(message);
            }
        }

        public void Info(object message)
        {
            if (GetLogger().IsInfoEnabled)
            {
                GetLogger().Info(message);
            }
        }

        public void Trace(object message)
        {
            if (GetLogger().IsTraceEnabled)
            {
                GetLogger().Trace(message);
            }
        }

        public void Warn(object message)
        {
            if (GetLogger().IsWarnEnabled)
            {
                GetLogger().Warn(message);
            }
        }

        #endregion

        #region Public Methods (Query)

        public bool IsDebugEnabled()
        {
            return GetLogger().IsDebugEnabled;
        }

        public bool IsErrorEnabled()
        {
            return GetLogger().IsErrorEnabled;
        }

        public bool IsFatalEnabled()
        {
            return GetLogger().IsFatalEnabled;
        }

        public bool IsInfoEnabled()
        {
            return GetLogger().IsInfoEnabled;
        }

        public bool IsTraceEnabled()
        {
            return GetLogger().IsTraceEnabled;
        }

        public bool IsWarnEnabled()
        {
            return GetLogger().IsWarnEnabled;
        }

        #endregion

        #region Abstract Methods

        protected abstract Logger CreateLogger();

        #endregion

        #region Helper Methods

        private Logger GetLogger()
        {
            // lazy-initialization
            if (Logger == null)
            {
                Logger = CreateLogger();
            }

            return Logger;
        }

        #endregion

    }
}
