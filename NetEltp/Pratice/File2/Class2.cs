using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.File2
{
    partial class Class2 : ITestinf
    {
        public void Message()
        {
            Console.WriteLine("This is class 2");
        }
        void ITestinf.greeting()
        {
            throw new NotImplementedException();
        }
    }

    interface ITestinf
    {
        void greeting();
    }
}
