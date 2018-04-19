using System;
using System.Collections.Generic;

namespace Logging.Writers
{
    public class Logger : ILogger
    {
        private bool enabled = true;
        public bool Enabled { get { return enabled;} set { enabled = value; } }
        private readonly DefaultWriter _defaultDefaultWriter;
        public DefaultWriter DefaultWriter { get { return _defaultDefaultWriter; } }

        private Dictionary<Type, Writer> writers = new Dictionary<Type, Writer>();

        public Logger()
        {
            _defaultDefaultWriter = new DefaultWriter(LogLevel.Debug | LogLevel.Warning | LogLevel.Error);
            AddWriter(_defaultDefaultWriter);
        }

        public void AddWriter<T>(T writer) where T : Writer
        {
            if (writers.ContainsKey(typeof(T)))
                throw new InvalidOperationException("You are trying to Add a existing writer \"" + writer.GetType() + "\"!");
            
            writers.Add(typeof(T), writer);
        }

        public void RemoveWriter<T>(T writer) where T : Writer
        {
            if (writers.ContainsKey(typeof(T)))
            {
                writer.Dispose();
                writers.Remove(typeof(T));
            }
        }

        public void RemoveAllWriters()
        {
            foreach (var writer in writers.Values)
                writer.Dispose();
            
            writers.Clear();
        }

        public void Debug<S>(S message)
        {
            if(!enabled)
                return;
            
            foreach (var writer in writers.Values)
            {
                if ((writer.LogLevel & LogLevel.Debug) == LogLevel.Debug)
                    writer.Debug(message);
            }
        }

        public void Debug<S, E>(S message, E channel)
        {
            if(!enabled)
                return;

            foreach (var writer in writers.Values)
            {
                if ((writer.LogLevel & LogLevel.Debug) == LogLevel.Debug)
                    writer.Debug("[" + channel + "] " + message);
            }
        }

        public void Warning<S>(S message)
        {
            if(!enabled)
                return;

            foreach (var writer in writers.Values)
            {
                if ((writer.LogLevel & LogLevel.Warning) == LogLevel.Warning)
                    writer.Warning(message);
            }
        }

        public void Warning<S, E>(S message, E channel)
        {
            if(!enabled)
                return;

            foreach (var writer in writers.Values)
            {
                if ((writer.LogLevel & LogLevel.Warning) == LogLevel.Warning)
                    writer.Debug("[" + channel + "] " + message);
            }
        }

        public void Error<S>(S message)
        {
            if(!enabled)
                return;

            foreach (var writer in writers.Values)
            {
                if ((writer.LogLevel & LogLevel.Error) == LogLevel.Error)
                    writer.Error(message);
            }
        }

        public void Error<S, E>(S message, E channel)
        {
            if(!enabled)
                return;

            foreach (var writer in writers.Values)
            {
                if ((writer.LogLevel & LogLevel.Error) == LogLevel.Error)
                    writer.Error("[" + channel + "] " + message);
            }
        }
    }
}