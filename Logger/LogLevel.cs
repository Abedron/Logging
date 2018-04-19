using System;

namespace Logging.Writers
{
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Debug = 1,
        Warning = 2,
        Error = 4
    }
}
