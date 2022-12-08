using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void myDelegate(int num1, int num2);
    public class DelegateExample
    {
        public void Add(int num1, int num2)
        {
            Console.WriteLine($"{num1}+{num2}={num1 + num2}");
        }
        public void Mul(int num1, int num2)
        {
            Console.WriteLine($"{num1}*{num2}={num1 * num2}");
        }
        public void Sub(int num1, int num2)
        {
            Console.WriteLine($"{num1}-{num2}={num1 - num2}");
        }
    }
}
