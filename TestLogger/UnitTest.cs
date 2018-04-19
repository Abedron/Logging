using System;
using System.IO;
using System.Text;
using Logging.Writers;
using Xunit;

namespace TestLogger
{
    public class UnitTest
    {
        [Fact]
        public void TestDebug()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            
            Log.Debug("Hi");
            Assert.Equal(writer.ToString(), "|D|Hi\r\n");
        }
        
        [Fact]
        public void TestWarning()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            
            Log.Warning("Hi");
            Assert.Equal(writer.ToString(), "|W|Hi\r\n");
        }
        
        [Fact]
        public void TestError()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            
            Log.Error("Hi");
            Assert.Equal(writer.ToString(), "|E|Hi\r\n");
        }

        [Fact]
        public void TestDefaultWriter()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            
            Log.Logger.RemoveWriter(Log.Logger.DefaultWriter);
            Log.Debug("Hi");
            Assert.Equal(writer.ToString(), "");
            
            Log.Logger.AddWriter(Log.Logger.DefaultWriter);
            Log.Debug("Hi");
            Assert.Equal(writer.ToString(), "|D|Hi\r\n");            
        }
    }
}