using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice
{
    public interface ITesting
    {
        public void print(string message);
        public void run();
        public void implemetedFunction()
        {
            Console.WriteLine("Implemeted Function");
        }
    }
}
