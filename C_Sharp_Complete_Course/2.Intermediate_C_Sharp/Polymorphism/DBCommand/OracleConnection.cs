using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    public class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString) : base(connectionString)
        {
            //Console.WriteLine("Invoked Oracle Connection Class");
        }
        public override void close()
        {
            Console.WriteLine("Oracle Connection Closed\n");
        }

        public override void open()
        {
            Console.WriteLine("Oracle Connection Opened");

        }
    }
}
