using CopierLibrary;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        public int Counter { get; set; } = 0;
        public int PrintCounter { get; set; } = 0;
        public IDevice.State GetState() => state;

        public IDevice.State state = IDevice.State.off;
        public Printer() { }
        public void PowerOn()
        {
            if (state == IDevice.State.on)
                return;

            state = IDevice.State.on;
            Console.WriteLine("Printer is on ...");
            Counter++;
        }
        public void PowerOff()
        {
            if (state == IDevice.State.off)
                return;

            state = IDevice.State.off;
            Console.WriteLine("... Printer is off !");
        }
        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.off)
                return;

            string format = document.GetFormatType().ToString().ToLower();

            Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}.{format}");
            PrintCounter++;
        }
    }
}
