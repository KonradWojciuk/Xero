using CopierLibrary;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        public int Counter { get; set; }
        public int ScanCounter { get; set; } = 0;
        public IDevice.State GetState() => state;

        protected IDevice.State state = IDevice.State.off;
        public Scanner() { }
        public void PowerOn()
        {
            if (state == IDevice.State.on)
                return;

            state = IDevice.State.on;
            Console.WriteLine("Scanner is on ...");
            Counter++;
        }
        public void PowerOff()
        {
            if (state == IDevice.State.off)
                return;

            state = IDevice.State.off;
            Console.WriteLine("... Scanner is off !");
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = default)
        {
            IDocument? scanDocument;

            if (GetState() == IDevice.State.off)
            {
                document = default;
                return;
            }

            switch (formatType)
            {
                case IDocument.FormatType.TXT:
                    scanDocument = new TextDocument($"TextScan{ScanCounter}");
                    break;
                case IDocument.FormatType.PDF:
                    scanDocument = new PDFDocument($"PDFScan{ScanCounter}");
                    break;
                case IDocument.FormatType.JPG:
                    scanDocument = new ImageDocument($"ImageScan{ScanCounter}");
                    break;
                default:
                    scanDocument = default;
                    break;

            }

            string format = scanDocument.GetFormatType().ToString().ToLower();

            Console.WriteLine($"{DateTime.Now} Scan: {scanDocument.GetFileName()}.{format}");
            document = scanDocument;
            ScanCounter++;
        }
    }
}
