using NLog;
using NLog.Targets;
using System;
using System.IO;

namespace Ttu.Domain
{
    public class ApplicationLogger : AbstractLogger, IApplicationLogger
    {

        # region Utility

        public static IApplicationLogger GetLogger(string loggerId)
        {
            return GetApplicationLoggerRepository().FindOrCreateApplicationLogger(loggerId);
        }

        public static IApplicationLogger GetLogger(Type type)
        {
            return GetApplicationLoggerRepository().FindOrCreateApplicationLogger(type);
        }

        private static ApplicationLoggerRepository GetApplicationLoggerRepository()
        {
            return ApplicationLoggerRepository.Singleton;
        }

        # endregion

        # region Constructors

        public ApplicationLogger(string loggerId)
            : base(loggerId)
        {
        }

        # endregion

        # region Public Methods

        public string GetLogPath()
        {
            // guard clause - no NLog.config on file system
            if (LogManager.Configuration == null)
            {
                return string.Empty;
            }

            // guard clause - no target configured in NLog.config
            FileTarget fileTarget = LogManager.Configuration.FindTargetByName("file") as FileTarget;
            if (fileTarget == null)
            {
                return string.Empty;
            }

            Layout layout = new Layout(fileTarget.FileName);
            LogEventInfo logEventInfo = new LogEventInfo();
            logEventInfo.TimeStamp = DateTime.Now;
            string rawPath = layout.GetFormattedMessage(logEventInfo);
            return Path.GetFullPath(rawPath);
        }

        # endregion

        # region Overridden Methods

        protected override Logger CreateLogger()
        {
            return LogManager.GetLogger(LoggerId);
        }

        # endregion

    }
}
