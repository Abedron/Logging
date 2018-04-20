using System;

namespace Logging.Writers
{
    public class Writer: IDisposable
    {
        public LogLevel LogLevel { get { return logLevel; } set { logLevel = value; } }
        protected LogLevel logLevel;

        public Writer(LogLevel logLevel)
        {
            this.logLevel = logLevel;
        }

        public virtual void Debug<S>(S message)
        {
        }

        public virtual void Warning<S>(S message)
        {
        }

        public virtual void Error<S>(S message)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
