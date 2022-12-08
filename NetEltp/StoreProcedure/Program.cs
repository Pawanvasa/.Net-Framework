using System.Data.SqlClient;
Console.WriteLine("Using SP");
SqlConnection Conn = null;
SqlCommand Cmd = null;
try
{

	Conn = new SqlConnection("Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=eShoppingCodi;Integrated Security=SSPI");
	Conn.Open();
    Cmd = Conn.CreateCommand();
    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
    Cmd.CommandText = "sp_MultiTableInsert2";

    SqlParameter pDeptNo = new SqlParameter();
    pDeptNo.ParameterName = "@DeptNo";
    pDeptNo.DbType = System.Data.DbType.Int32;
    pDeptNo.Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pDeptNo.Value = 60;
    Cmd.Parameters.Add(pDeptNo);

    SqlParameter pDeptName = new SqlParameter();
    pDeptName.ParameterName = "@DeptName";
    pDeptName.DbType = System.Data.DbType.String;
    pDeptName.Size = 100;
    pDeptName.Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pDeptName.Value = "Manage";
    Cmd.Parameters.Add(pDeptName);

    SqlParameter pLocation = new SqlParameter();
    pLocation.ParameterName = "@Location";
    pLocation .DbType = System.Data.DbType.String;
    pLocation .Size = 100;
    pLocation .Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pLocation.Value = "Mumbai";
    Cmd.Parameters.Add(pLocation);

    SqlParameter pCapacity = new SqlParameter();
    pCapacity.ParameterName = "@Capacity";
    pCapacity.DbType = System.Data.DbType.Int32;
    pCapacity.Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pCapacity.Value = 100;
    Cmd.Parameters.Add(pCapacity);

    SqlParameter pEmpNo = new SqlParameter();
    pEmpNo .ParameterName = "@EmpNo";
    pEmpNo .DbType = System.Data.DbType.Int32;
    pEmpNo .Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pEmpNo.Value = 535;
    Cmd.Parameters.Add(pEmpNo);

    SqlParameter pEmpName = new SqlParameter();
    pEmpName.ParameterName = "@EmpName";
    pEmpName.DbType = System.Data.DbType.String;
    pEmpName .Size = 100;
    pEmpName.Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pEmpName.Value = "Pavan";
    Cmd.Parameters.Add(pEmpName);


    SqlParameter pDesignation = new SqlParameter();
    pDesignation.ParameterName = "@Designation";
    pDesignation.DbType = System.Data.DbType.String;
    pDesignation.Size = 100;
    pDesignation.Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pDesignation.Value = "Manager";
    Cmd.Parameters.Add(pDesignation);


    SqlParameter pSalary = new SqlParameter();
    pSalary.ParameterName = "@Salary";
    pSalary.DbType = System.Data.DbType.Int32;
    pSalary.Direction = System.Data.ParameterDirection.Input; // DEfault is Input
    pSalary.Value = 40000;
    Cmd.Parameters.Add(pSalary);

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