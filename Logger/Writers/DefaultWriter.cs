using System;

namespace Logging.Writers
{
    public class DefaultWriter : Writer
    {
        public DefaultWriter(LogLevel logLevel) : base(logLevel)
        {
        }

        public override void Debug<S>(S message)
        {
            Console.WriteLine("|D|" + message);
        }

        public override void Warning<S>(S message)
        {
            Console.WriteLine("|W|" + message);
        }

        public override void Error<S>(S message)
        {
            Console.WriteLine("|E|" + message);
        }
    }
}