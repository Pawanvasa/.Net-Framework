using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample
{
    public class MailServices
    {
        public void OnVideoEncoded(object source, EventArgs eventArgs)
        {
            Console.WriteLine("Mail Sevice : Sending an email....");
            Thread.Sleep(2000);
        }
    }
}
