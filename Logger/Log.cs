using Logging;
using Logging.Writers;

public sealed class Log
{
    public static ILogger Logger { get { return logger; } }

    private static Logger logger;
    
    static Log()
    {
        logger = new Logger();
    }

    public static void Debug<T>(T message)
    {
        logger.Debug(message);
    }

    /// <summary>
    /// May be performance issue. Logging with channel is 5x slower
    /// </summary>
    public static void Debug<T, J>(T message, J channel)
    {
        logger.Debug(message, channel);
    }

    public static void Warning<T>(T message)
    {
        logger.Warning(message);
    }

    /// <summary>
    /// May be performance issue. Logging with channel is 5x slower
    /// </summary>
    public static void Warning<T, J>(T message, J channel)
    {
        logger.Warning(message, channel);
    }

    public static void Error<T>(T message)
    {
        logger.Error(message);
    }

    /// <summary>
    /// May be performance issue. Logging with channel is 5x slower
    /// </summary>
    public static void Error<T, J>(T message, J channel)
    {
        logger.Error(message, channel);
    }
}
