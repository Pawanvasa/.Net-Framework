using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate
{
    public class DelegateExample
    {
        delegate void delegateImplementation(int number1,int number2);
        public static void add(int n1,int n2)
        {
            Console.WriteLine(n1+n2);
        }
        public static void mul(int n1,int n2)
        {
            Console.WriteLine(n1*n2);
        }

        static void main(string[] args)
        {
            delegateImplementation delegateImplementation = new delegateImplementation(add);
            delegateImplementation(1034, 45);
            delegateImplementation += mul;
            delegateImplementation(41, 4);
        }
    }
}
