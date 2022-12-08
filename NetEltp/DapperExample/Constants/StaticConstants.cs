using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Constants
{
    public class StaticConstants
    {
        public static string ConnectionString = "Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=eShoppingCodi;Integrated Security=SSPI;Encrypt=false";
        public static string SelectQuery = "Select * from Department";
        public static string SelectQueryEmp = "Select * from Employee";
        public static string InsertQuery = "Insert into Department Values(@DeptNo,@DeptName,@Location,@Capacity)";
        public static string UpdateQuery = "Update Department Set DeptName=@DeptName, Location=@Location,Capacity=@Capacity Where DeptNo=@DeptNo";
        public static string DeleteQuery = "Delete From Department Where DeptNo=@DeptNo";
    }
}
