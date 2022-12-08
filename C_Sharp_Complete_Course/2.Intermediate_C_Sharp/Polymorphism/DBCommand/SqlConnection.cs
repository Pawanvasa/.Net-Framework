using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString) : base(connectionString)
        {
            //Console.WriteLine("Invoked Sql Connection Class");
        }
        public override void close()
        {
            Console.WriteLine("Sql Connection Closed\n");
        }

        public override void open()
        {
            Console.WriteLine("Sql Connection Opened\n");
        }
    }
}
