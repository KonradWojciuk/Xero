using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CopierLibrary;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public new int Counter { get; private set; } = 0;
        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;
        public Copier() { }
        public new void PowerOn()
        {
            if (state == IDevice.State.on)
                return;
            base.PowerOn();
            Counter++;
        }
        public new void PowerOff()
        {
            if (state == IDevice.State.off)
                return;
            base.PowerOff();
        }
        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.off)
                return;

            string format = document.GetFormatType().ToString().ToLower();

            Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}.{format}");
            PrintCounter++;
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
        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.off)
                return;

            IDocument document = new ImageDocument($"ImageScan{ScanCounter}");
            string format = document.GetFormatType().ToString().ToLower();

            Console.WriteLine($"{DateTime.Now} Scan: {document.GetFileName()}.{format}");
            Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");

            ScanCounter++;
            PrintCounter++;
        }
    }
}
