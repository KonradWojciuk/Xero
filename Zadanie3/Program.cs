using CopierLibrary;

namespace Zadanie3
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test klasy Photocopier
            Copier photocopier = new Copier();
            photocopier.PowerOn();

            IDocument doc1 = new PDFDocument("PDFTest");
            IDocument doc2 = new TextDocument("TextTest");
            IDocument doc3 = new ImageDocument("ImageTest");

            photocopier.Print(doc1);
            photocopier.Print(doc2);
            photocopier.PowerOff();
            photocopier.Print(doc3);
            photocopier.PowerOn();
            photocopier.Print(doc3);

            photocopier.Scan(out doc1, IDocument.FormatType.PDF);
            photocopier.PowerOff();
            photocopier.Scan(out doc2, IDocument.FormatType.TXT);
            photocopier.Scan(out doc3, IDocument.FormatType.JPG);
            photocopier.PowerOn();
            photocopier.Scan(out doc2, IDocument.FormatType.TXT);
            photocopier.Scan(out doc3, IDocument.FormatType.JPG);

            photocopier.ScanAndPrint();
            photocopier.ScanAndPrint();
            photocopier.ScanAndPrint();
            photocopier.ScanAndPrint();
            photocopier.PowerOff();
            photocopier.ScanAndPrint();
            photocopier.ScanAndPrint();
            photocopier.PowerOn();
            photocopier.ScanAndPrint();
            photocopier.ScanAndPrint();

            Console.WriteLine("Liczba włęczeń drukarki: " + photocopier.Counter);
            Console.WriteLine("Liczba skanów: " + photocopier.ScanCounter);
            Console.WriteLine("Liczba druków: " + photocopier.PrintCounter);

            // Test klasy MultifuncionalDevice
            MultifuncionalDevice multifuncionalDevice = new MultifuncionalDevice();

            multifuncionalDevice.PowerOn();
            multifuncionalDevice.PowerOn();
            multifuncionalDevice.PowerOn();
            multifuncionalDevice.PowerOff();
            multifuncionalDevice.PowerOn();

            multifuncionalDevice.Print(doc1);
            multifuncionalDevice.Print(doc2);

            multifuncionalDevice.PowerOff();
            multifuncionalDevice.Print(doc3);
            multifuncionalDevice.Print(doc2);
            multifuncionalDevice.PowerOn();
            multifuncionalDevice.Print(doc3);
            multifuncionalDevice.Print(doc2);

            multifuncionalDevice.Scan(out doc1, IDocument.FormatType.PDF);
            multifuncionalDevice.Scan(out doc2, IDocument.FormatType.TXT);
            multifuncionalDevice.PowerOff();
            multifuncionalDevice.Scan(out doc3, IDocument.FormatType.JPG);
            multifuncionalDevice.PowerOn();
            multifuncionalDevice.Scan(out doc3, IDocument.FormatType.JPG);

            multifuncionalDevice.ScanAndPrint();
            multifuncionalDevice.ScanAndPrint();
            multifuncionalDevice.ScanAndPrint();
            multifuncionalDevice.PowerOff();
            multifuncionalDevice.ScanAndPrint();
            multifuncionalDevice.ScanAndPrint();
            multifuncionalDevice.PowerOn();
            multifuncionalDevice.ScanAndPrint();
            multifuncionalDevice.ScanAndPrint();

            multifuncionalDevice.SendFax("525524321@e-fax.com.pl", doc1);
            multifuncionalDevice.SendFax("525524321@e-fax.com.pl", doc2);
            multifuncionalDevice.PowerOff();
            multifuncionalDevice.SendFax("525524321@e-fax.com.pl", doc3);
            multifuncionalDevice.PowerOn();
            multifuncionalDevice.SendFax("525524321@e-fax.com.pl", doc3);

            multifuncionalDevice.ReceiveFax(DateTime.Now, "525524321@e-fax.com.pl", doc1);
            multifuncionalDevice.ReceiveFax(DateTime.Now, "525524321@e-fax.com.pl", doc2);
            multifuncionalDevice.ReceiveFax(DateTime.Now, "525524321@e-fax.com.pl", doc3);

            Console.WriteLine("Liczba włęczeń drukarki: " + multifuncionalDevice.Counter);
            Console.WriteLine("Liczba skanów: " + multifuncionalDevice.ScanCounter);
            Console.WriteLine("Liczba druków: " + multifuncionalDevice.PrintCounter);
            Console.WriteLine("Liczba wysłanych faksów: " + multifuncionalDevice.SendFaxCounter);
            Console.WriteLine("Liczba przyjętych faksów: " + multifuncionalDevice.RecivedFaxCounter);
        }
    }
}