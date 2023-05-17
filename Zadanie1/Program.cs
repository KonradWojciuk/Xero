using CopierLibrary;

namespace Zadanie1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Copier copier = new Copier();
            copier.PowerOn();
            copier.PowerOn();
            copier.PowerOn();

            IDocument doc1 = new PDFDocument("test");
            IDocument doc2 = new TextDocument("test");
            IDocument doc3 = new ImageDocument("test");


            copier.Print(doc1);
            copier.Print(doc2);
            copier.Print(doc3);
            copier.Print(doc1);

            copier.PowerOff();
            copier.Print(doc1);
            copier.PowerOff();
            copier.PowerOff();
            copier.Print(doc2);

            copier.PowerOn();
            copier.Scan(out doc1, IDocument.FormatType.PDF);
            copier.Scan(out doc2, IDocument.FormatType.TXT);
            copier.Scan(out doc3, IDocument.FormatType.JPG);

            copier.PowerOff();
            copier.Scan(out doc1, IDocument.FormatType.PDF);
            copier.Scan(out doc2, IDocument.FormatType.TXT);
            copier.PowerOff();
            copier.Scan(out doc3, IDocument.FormatType.JPG);
            copier.PowerOn();
            copier.Scan(out doc3, IDocument.FormatType.JPG);

            copier.ScanAndPrint();
            copier.ScanAndPrint();
            copier.ScanAndPrint();
            copier.ScanAndPrint();

            copier.PowerOff();
            copier.ScanAndPrint();
            copier.ScanAndPrint();
            copier.PowerOff();
            copier.ScanAndPrint();
            copier.PowerOn();
            copier.ScanAndPrint();

            Console.WriteLine("Liczba włęczeń drukarki: " + copier.Counter);
            Console.WriteLine("Liczba skanów: " + copier.ScanCounter);
            Console.WriteLine("Liczba druków: " + copier.PrintCounter);
        }
    }
}