using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates3
{
    public class DelegateExample
    {
        public delegate void Sender(int i);
        public event Sender? sender = null;
        public void hugeProcess()
        {
            for(int i = 0; i < 10000; i++)
            {
                Thread.Sleep(5000);
                sender(i);
            }
        }
    }
}
