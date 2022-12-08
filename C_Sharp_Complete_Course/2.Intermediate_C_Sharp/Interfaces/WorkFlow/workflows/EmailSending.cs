using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.workflows
{
    public class EmailSending : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("video started processing....");
        }
    }
}
