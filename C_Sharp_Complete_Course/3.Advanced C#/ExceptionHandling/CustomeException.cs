using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class CustomeException : Exception
    {
        public CustomeException(string message,Exception innerException) : base(message,innerException)
        {

        }
    }
}
