namespace Logging.Writers
{
    public interface ILogger
    {
        bool Enabled { get; set; }
        
        DefaultWriter DefaultWriter { get; }
        
        void AddWriter<T>(T writer)where T : Writer;
        void RemoveWriter<T>(T writer)where T : Writer;
        void RemoveAllWriters();
    }
}
