using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math;
namespace Maths
{
    public static class ExtensionClass
    {
        public static int substract(this MathOperations obj, int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
