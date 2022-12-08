using EF_Db_First.DBAccess;
using EF_Db_First.Models;
using System.Text.Json;
using static System.Console;

WriteLine("EF Core DB First");
try
{
    //EmployeeDataAccess empds = new EmployeeDataAccess();

    //Console.WriteLine($"USing Traditional DbCOntext = {JsonSerializer.Serialize( await empds.GetDataAsync())}");
    //Console.WriteLine();
    //Console.WriteLine($"USing LINQ = {JsonSerializer.Serialize( await empds.GetDataLINQAsync())}");
    //Console.WriteLine();
    //Console.WriteLine($"Using Orderby {JsonSerializer.Serialize( await empds.GetDataLINQOrderByAsync())}");


    //Console.WriteLine($"Using Sync {JsonSerializer.Serialize(JsonSerializer.Serialize(empds.GetDataLINQSync()))}");

    DepartentDataAccess deprds = new DepartentDataAccess();

    var res = await deprds.GetAsync();
    Print(res);
    WriteLine();
    //var deptSIngle = await deprds.GetAsync(202);
    //Console.WriteLine(deptSIngle.DeptName);
    WriteLine();
    var d = new Department()
    {
        DeptNo = 203,
        DeptName = "djsb",
        Location = "hbfv",
        Capacity = 874
    };

    var e = new Employee()
    {
        EmpNo=865,
        EmpName="Deepna",
        Designation="QA",
        Salary=48272
    };
    //await deprds.CreateAsync(d);
      await deprds.UpdateAsync(d, e);
    //await deprds.DeleteAsync(d.DeptNo);
    WriteLine();
    res = await deprds.GetAsync();
    Print(res);
}
catch (Exception ex)
{
    WriteLine($"Error Occurred {ex.Message}");
}

ReadLine();

static void Print(IEnumerable<Department> dept)
{
    WriteLine(JsonSerializer.Serialize(dept));
}
