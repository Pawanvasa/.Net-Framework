using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DbConnect
{
    public class EShoppingCodiContext
    {
        /// <summary>
        /// The class that will be used to Return an INstance of SQLConnection
        /// class so that, the DB Connection will be stablished
        /// </summary>
        internal class EShopingCodiContext
        {
            private readonly string connStr;
            public EShopingCodiContext()
            {
                connStr = StaticConstants.ConnectionString;
            }
            // Retun an Instance of SqlCOnnection Class
            public IDbConnection CreateConnection()
                => new SqlConnection(connStr);
        }
    }
}
