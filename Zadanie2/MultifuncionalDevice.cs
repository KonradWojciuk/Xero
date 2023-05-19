using CopierLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    public class MultifuncionalDevice : Copier, IFax
    {
        public int FaxSendFaxCounter { get; private set; } = 0;
        public int FaxRecivedCounter { get; private set; } = 0;
        public void SendFax(string destination, in IDocument document)
        {
            if (GetState() == IDevice.State.off)
                return;

            string format = document.GetFormatType().ToString().ToLower();

            Console.WriteLine($"{DateTime.Now} Sent to: {destination} File: {document.GetFileName()}.{format}");
            FaxSendFaxCounter++;
        }
        public void ReceiveFax(DateTime date, string sender, in IDocument document)
        {
            if (GetState() == IDevice.State.off)
                return;

            string format = document.GetFormatType().ToString().ToLower();

            Console.WriteLine($"{date} Received from: {sender} File: {document.GetFileName()}.{format}");
            FaxRecivedCounter++;
        }
    }
}
