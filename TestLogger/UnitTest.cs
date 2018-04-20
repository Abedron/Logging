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
            
            Log.Debug("Hi", LogEnumTest.D);
            Assert.Equal("[D] Hi\r\n", writer.ToString());
        }
        
        [Fact]
        public void TestWarning()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            
            Log.Warning("Hi", LogEnumTest.W);
            Assert.Equal("[W] Hi\r\n", writer.ToString());
        }
        
        [Fact]
        public void TestError()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            
            Log.Error("Hi", LogEnumTest.E);
            Assert.Equal("[E] Hi\r\n", writer.ToString());
        }

        [Fact]
        public void TestDefaultWriter()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            
            Log.Logger.RemoveWriter(Log.Logger.DefaultWriter);
            Log.Debug("Hi", LogEnumTest.D);
            Assert.Equal("", writer.ToString());
            
            Log.Logger.AddWriter(Log.Logger.DefaultWriter);
            Log.Debug("Hi", LogEnumTest.D);
            Assert.Equal("[D] Hi\r\n", writer.ToString());            
        }

        enum LogEnumTest
        {
            None,
            D,
            W,
            E
        }
    }
}