using System;

namespace Ttu.Domain
{
    public abstract class AbstractApplicationLogger
    {

        #region Constructors

        protected AbstractApplicationLogger()
        {
            Logger = null;
        }

        #endregion

        #region Properties

        private IApplicationLogger Logger { get; set; }

        #endregion

        #region Public Methods

        protected virtual void LogDebug(string message, params object[] replacements)
        {
            GetLogger().Debug(string.Format(message, replacements));
        }

        protected virtual void LogError(string message, params object[] replacements)
        {
            GetLogger().Error(string.Format(message, replacements));
        }

        protected virtual void LogError(Exception ex)
        {
            GetLogger().Error("--");
            GetLogger().Error(ex.Message);
            GetLogger().Error(ex.StackTrace);
            GetLogger().Error("--");
        }

        protected virtual void LogInfo(string message, params object[] replacements)
        {
            GetLogger().Info(string.Format(message, replacements));
        }

        #endregion

        #region Helper Methods

        private IApplicationLogger GetLogger()
        {
            // lazy initialization
            if (Logger == null)
            {
                Logger = ApplicationLogger.GetLogger(GetType());
            }

            return Logger;
        }

        #endregion

    }
}
