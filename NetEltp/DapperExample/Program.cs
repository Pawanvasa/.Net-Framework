using DapperExample.DataAccessServices;
using DapperExample.Model;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("using Dapper");
try
{
    DepartmentDataAccessService deptServ = new DepartmentDataAccessService();
    EmployeeDataAccess empServ = new EmployeeDataAccess();
    var resultDpt = await deptServ.GetAsync();
    var resultEmo = await empServ.GetAsyncEmp();



    var res1 = from emp in resultEmo
               join dpt in resultDpt on emp.DeptNo equals dpt.DeptNo
                group emp by emp.EmpName into deptgroup
                select new{
                    DeptName = deptgroup.Key,
                    Salary = deptgroup.Sum(e => e.Salary)
                };

    Console.WriteLine($"Department Data");
    foreach (var item in resultDpt)
    {
        Console.WriteLine($"{item.DeptNo} {item.DeptName} {item.Location} {item.Capacity}");
    }
    // Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(resultDpt));
    Console.WriteLine();
    Console.WriteLine($"Employee Data");
    foreach (var item in resultEmo)
    {
        Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Designation} {item.Salary}");
    }

    foreach(var item in res1)
    {
        Console.WriteLine($"{item.DeptName} {item.Salary}");
    }
    //Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(resultEmo));

    //var dept = new Department()
    //{
    //    DeptNo = 9001,
    //    DeptName = "Test 12356",
    //    Location = "MUmbai",
    //    Capacity = 988
    //};

    //var resp1 = await deptServ.CreateAsync(dept);

    //var resp1 = await deptServ.UpdateAsync(dept.DeptNo,dept);

    //var resp1 = await deptServ.DeleteAsync(dept.DeptNo);


}
catch (Exception ex)
{
    Console.WriteLine($"Error {ex.Message}");
}
Console.ReadLine();