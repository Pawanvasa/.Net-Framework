using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    public abstract class DbConnection
    {
        private string ConnectionString;
        private TimeSpan TimeOut { set; get; }
        public DbConnection(string connectionString)
        {
            ConnectionString = connectionString;
            try
            {
                if (ConnectionString == null || ConnectionString == "")
                {
                    throw new Exception("Invalid Connection String");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public abstract void open();
        public abstract void close();
    }
}
