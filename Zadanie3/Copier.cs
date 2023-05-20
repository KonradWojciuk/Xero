using CopierLibrary;

namespace Zadanie3
{
    public class Copier : BaseDevice
    {
        protected Printer Printer = new Printer();
        protected Scanner Scanner = new Scanner();
        public new int Counter { get; set; }
        public int PrintCounter => Printer.PrintCounter;
        public int ScanCounter => Scanner.ScanCounter;
        public Copier() { }
        public new void PowerOn()
        {
            if (state == IDevice.State.on)
                return;

            base.PowerOn();
            Printer.PowerOn();
            Scanner.PowerOn();

            Counter++;
        }
        public new void PowerOff()
        {
            if (state == IDevice.State.off)
                return;

            base.PowerOff();
            Printer.PowerOff();
            Scanner.PowerOff();
        }
        public void Print(in IDocument document)
        {
            if (Printer.GetState() == IDevice.State.off)
                return;

            Printer.Print(document);
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = default)
        {
            if (Scanner.GetState() == IDevice.State.off)
            {
                document = null;
                return;
            }

            Scanner.Scan(out document, formatType);
        }
        public void ScanAndPrint()
        {
            if (Printer.GetState() == IDevice.State.off || Scanner.GetState() == IDevice.State.off)
                return;

            Scanner.Scan(out IDocument document, IDocument.FormatType.JPG);
            Printer.Print(document);
        }
    }
}
