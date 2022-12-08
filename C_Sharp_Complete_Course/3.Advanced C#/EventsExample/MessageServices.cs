using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExample
{
    public class MessageServices
    {
        public void OnVideoEncoded(Object source, EventArgs eventArgs)
        {
            Console.WriteLine("Message Service : Text Message is sending.....");
        }
    }
}
