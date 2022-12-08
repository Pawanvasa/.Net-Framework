using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates02
{
    public class MyClass
    {
        public delegate void returnStatus(int i);
        public void longRun(returnStatus obj)
        {
            for (int i = 0; i < 10000; i++)
            {
                //Some Code
                obj(i);
            }
        }
    }
}
