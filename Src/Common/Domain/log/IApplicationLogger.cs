namespace Ttu.Domain
{
    public interface IApplicationLogger
    {
        // http://www.nlog-project.org/netapi.html

        // behavior
        string GetLogPath();

        // io
        void Trace(object message);
        void Debug(object message);
        void Info(object message);
        void Warn(object message);
        void Error(object message);
        void Fatal(object message);

        // query
        bool IsDebugEnabled();
        bool IsErrorEnabled();
        bool IsFatalEnabled();
        bool IsInfoEnabled();
        bool IsTraceEnabled();
        bool IsWarnEnabled();

    }
}
