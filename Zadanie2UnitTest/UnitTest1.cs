using CopierLibrary;
using Zadanie1;
using Zadanie2;

namespace Zadanie2UnitTest
{
    public class ConsoleRedirectionToStringWriter : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleRedirectionToStringWriter()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }

    [TestClass]
    public class UnitTestZadanie2MultifuncionalDevice
    {
        [TestMethod]
        public void MultifuncionalDevice_SendFax_DeviceOn()
        {
            MultifuncionalDevice multifuncional = new MultifuncionalDevice();
            multifuncional.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();

            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifuncional.SendFax("525524321@e-fax.com.pl", in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Sent to"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifuncionalDevice_SendFax_DeviceOff()
        {
            MultifuncionalDevice multifuncional = new MultifuncionalDevice();
            multifuncional.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();

            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifuncional.SendFax("525524321@e-fax.com.pl", in doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Sent to"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifuncionalDevice_ReceiveFax_DeviceOn()
        {
            MultifuncionalDevice multifuncional = new MultifuncionalDevice();
            multifuncional.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();

            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifuncional.ReceiveFax(DateTime.Now, "525524321@e-fax.com.pl", in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Received from"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifuncionalDevice_ReceiveFax_DeviceOff()
        {
            MultifuncionalDevice multifuncional = new MultifuncionalDevice();
            multifuncional.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();

            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifuncional.ReceiveFax(DateTime.Now, "525524321@e-fax.com.pl", in doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Received from"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}