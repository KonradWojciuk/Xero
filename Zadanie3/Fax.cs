using CopierLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Fax : IFax
    {
        public int Counter { get; set; } = 0;
        public int SendFaxCounter { get; private set; } = 0;
        public int RecivedFaxCounter { get; private set; } = 0;
        public IDevice.State GetState() => state;

        public IDevice.State state = IDevice.State.off;
        public Fax() { }
        public void PowerOn()
        {
            if (state == IDevice.State.on)
                return;

            state = IDevice.State.on;
            Console.WriteLine("Fax is on ...");
            Counter++;
        }
        public void PowerOff()
        {
            if (state == IDevice.State.off)
                return;

            state = IDevice.State.off;
            Console.WriteLine("... Fax is off !");
        }
        public void SendFax(string destination, in IDocument document)
        {
            if (GetState() == IDevice.State.off)
                return;

            string format = document.GetFormatType().ToString().ToLower();

            Console.WriteLine($"{DateTime.Now} Sent to: {destination} File: {document.GetFileName()}.{format}");
            SendFaxCounter++;
        }
        public void ReceiveFax(DateTime date, string sender, in IDocument document)
        {
            if (GetState() == IDevice.State.off)
                return;

            string format = document.GetFormatType().ToString().ToLower();

            Console.WriteLine($"{date} Received from: {sender} File: {document.GetFileName()}.{format}");
            RecivedFaxCounter++;
        }
    }
}
