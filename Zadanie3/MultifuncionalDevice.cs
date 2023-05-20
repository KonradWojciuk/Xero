using CopierLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MultifuncionalDevice : Copier
    {
        protected Fax Fax = new Fax();
        public int SendFaxCounter => Fax.SendFaxCounter;
        public int RecivedFaxCounter => Fax.RecivedFaxCounter;
        public MultifuncionalDevice() { }
        public new void PowerOn()
        {
            if (state == IDevice.State.on)
                return;

            base.PowerOn();
            Fax.PowerOn();

            Counter++;
        }
        public new void PowerOff()
        {
            if (state == IDevice.State.off)
                return;

            base.PowerOff();
            Fax.PowerOff();
        }
        public void SendFax(string destination, in IDocument document)
        {
            if (Fax.GetState() == IDevice.State.off)
                return;

            Fax.SendFax(destination, document);
        }
        public void ReceiveFax(DateTime date, string sender, in IDocument document)
        {
            if (Fax.GetState() == IDevice.State.off)
                return;

            Fax.ReceiveFax(date, sender, document);
        }
    }
}
