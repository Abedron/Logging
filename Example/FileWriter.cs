using System.IO;
using System.Text;
using System.Timers;

namespace Logging.Writers
{
    public class FileWriter : Writer
    {
        private StringBuilder stringBuilder;
        private Timer timer;
        private bool recorded;
        private string path;

        public FileWriter(LogLevel logLevel) : base(logLevel)
        {
            path = Directory.GetCurrentDirectory() + "/log.txt";
            
            stringBuilder = new StringBuilder(100);
            
            timer = new Timer(1000);
            timer.Start();
            timer.Elapsed += TimerHandler;
        }

        public override void Debug<S>(S message)
        {
            stringBuilder.Append("Debug: " + message + "\n");
            recorded = true;
        }

        public override void Warning<S>(S message)
        {
            stringBuilder.Append("Warning: " + message + "\n");
            recorded = true;
        }

        public override void Error<S>(S message)
        {
            stringBuilder.Append("Error: " + message + "\n");
            recorded = true;
        }

        private void TimerHandler(object sender, ElapsedEventArgs e)
        {
            if (recorded)
            {
                File.AppendAllText(path, stringBuilder.ToString());
                stringBuilder.Clear();
                recorded = false;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            stringBuilder.Clear();
            timer.Dispose();
        }
    }
}