using System;
using Logging.Writers;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWriter fileWriter = new FileWriter(LogLevel.Debug | LogLevel.Error | LogLevel.Warning);
            Log.Logger.AddWriter(fileWriter);
            
            Log.Debug("Hello World!");
            
            Log.Warning("Hello Mars!");
            
            Log.Error("Hello Europe!");

            while (true)
            {
                string message = Console.ReadLine();
                Log.Error(message, "Info");
            }
        }
    }
}