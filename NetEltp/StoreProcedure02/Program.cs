using System.Data.SqlClient;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Store Procedures!");
SqlConnection con = null;
SqlCommand Cmd = null;

try
{
    con = new SqlConnection("Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");
    con.Open();
    Cmd = con.CreateCommand();
    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
    Cmd.CommandText = "sp_insertEmpByDeptNo";

    SqlParameter pEmpNo = new SqlParameter();
    pEmpNo.ParameterName = "@EmpNo";
    pEmpNo.DbType = System.Data.DbType.Int32;
    pEmpNo.Direction = System.Data.ParameterDirection.Input; // Default is Input
    pEmpNo.Value = 865;
    Cmd.Parameters.Add(pEmpNo);

    SqlParameter pEmpName = new SqlParameter();
    pEmpName.ParameterName = "@EmpName";
    pEmpName.DbType = System.Data.DbType.String;
    pEmpName.Size = 100;
    pEmpName.Direction = System.Data.ParameterDirection.Input; // Default is Input
    pEmpName.Value = "Mohan";
    Cmd.Parameters.Add(pEmpName);

    SqlParameter pDesignation = new SqlParameter();
    pDesignation.ParameterName = "@Designation";
    pDesignation.DbType = System.Data.DbType.String;
    pDesignation.Size = 100;
    pDesignation.Direction = System.Data.ParameterDirection.Input; // Default is Input
    pDesignation.Value = "Manager";
    Cmd.Parameters.Add(pDesignation);

    SqlParameter pSalary = new SqlParameter();
    pSalary.ParameterName = "@Salary";
    pSalary.DbType = System.Data.DbType.Int32;
    pSalary.Direction = System.Data.ParameterDirection.Input; // Default is Input
    pSalary.Value = 6073;
    Cmd.Parameters.Add(pSalary);

    SqlParameter pDeptNo = new SqlParameter();
    pDeptNo.ParameterName = "@DeptNo";
    pDeptNo.DbType = System.Data.DbType.Int32;
    pDeptNo.Direction = System.Data.ParameterDirection.Input; // Default is Input
    pDeptNo.Value = 40;
    Cmd.Parameters.Add(pDeptNo);

    int result = Cmd.ExecuteNonQuery();
    if (result > 0)
        Console.WriteLine("Record Added");
    else
        Console.WriteLine("Failed");
}
catch (Exception)
{
    throw;
}