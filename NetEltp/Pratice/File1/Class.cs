using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pratice.File2;

namespace Pratice.File1
{
 

    partial class Class1 : ITestinf
    {
        public void Message()
        {
            Console.WriteLine("This is class one");
        }
        void ITestinf.greeting()
        {

        }
    }
}
