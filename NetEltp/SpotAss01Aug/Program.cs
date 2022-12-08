using SpotAss01Aug;
Console.WriteLine("Using LINQ");

EmployeeCollection employees = new EmployeeCollection();
DepartmentCollection departments = new DepartmentCollection();

//1. Print Maximum Salary Per Department with EmpNo and EmpName
Console.WriteLine();
var joinTables = employees.Join(
    departments,
    emp => emp.DeptNo,
    emp1 =>  emp1.DeptNo,
    (emp, emp1) => new { emp1.DeptName, emp.EmpName,emp.Salary,emp.EmpNo}).
    OrderByDescending(emp1=>emp1.Salary)
    .GroupBy(emp=>emp.DeptName );

var finalres = joinTables.Select(y => new
{
    Deptname = y.Key,
    Salary = y.Max(e => e.Salary),
    EmpName = y.Select(e => e.EmpName).First(),
    EmpNo = y.Select(e => e.EmpNo).First()
});

Console.WriteLine("Maximum Salary Per Department With EmpId and EmpName using Declarative");
foreach (var item in finalres)
{
    Console.WriteLine($"DeptName = {item.Deptname} | EmpName = {item.EmpName} | EmpNo = {item.EmpNo} | Max Salary =  {item.Salary}");
}
Console.WriteLine();

var maxSalary = (from emp in employees
                 join sal in departments on emp.DeptNo equals sal.DeptNo
                 orderby emp.Salary descending
                 group emp by sal.DeptName into deptgroup
                 select new
                 {
                     Deptname = deptgroup.Key,
                     Salary = deptgroup.Max(e => e.Salary),
                     EmpName = deptgroup.Select(e => e.EmpName).First(),
                     EmpNo = deptgroup.Select(e => e.EmpNo).First()

                 });

Console.WriteLine("Maximum Salary Per Department With EmpId and EmpName using Imperative");
foreach (var item in maxSalary)
{
    Console.WriteLine($"DeptName = {item.Deptname} | EmpName = {item.EmpName} | EmpNo = {item.EmpNo} | Max Salary = {item.Salary}");
}


//2. Print Sum of Salary Group by DeptName
Console.WriteLine();
Console.WriteLine("Sum of Salary Group by DeptName");
var sumOfSalaryBydeptname = (from emp in employees
                             join sum in departments on emp.DeptNo equals sum.DeptNo
                           group emp by sum.DeptName into deptgroup
                           select new
                           {
                               DeptName = deptgroup.Key,
                               Salary = deptgroup.Sum(e => e.Salary)
                           }).ToList(); 
foreach (var item in sumOfSalaryBydeptname)
{
    Console.WriteLine($"DeptName = {item.DeptName} and Sum Of Salary = {item.Salary}");
}


//3. Print Employee Details Per DeptName
Console.WriteLine();
Console.WriteLine("Print Employee Details Per Department");
var empByDept = (from emp in employees
                 join dpt in departments on emp.DeptNo equals dpt.DeptNo 
                 group emp by dpt.DeptName into groupof
                 select new
                 {
                  DeptName=groupof.Key,
                  temp=groupof
                 });

foreach (var item in empByDept)
{
    Console.WriteLine(item.DeptName);
    foreach(var item2 in item.temp)
    {
        Console.WriteLine($"EmpName = {item2.EmpName} | EmpNum = {item2.EmpNo} | Designation = {item2.Designation} | Salary = {item2.Salary} | DptNum = {item2.DeptNo}");
    }
}

//4. Print Count of Employees working per Location
var countOfEmployess = (from emp in departments
                        join dpt in employees on emp.DeptNo equals dpt.DeptNo
                        group emp by dpt.DeptNo into groupof
                        select new
                        {
                            deptnum=groupof.Key,
                            temp=groupof
                        });


Console.WriteLine();
Console.WriteLine("Count of Employees working per Location");
foreach (var item in countOfEmployess)
{
    foreach(var it in item.temp)
    {
        Console.WriteLine($"Employees Working in {it.Location} is = {item.temp.Count()}");
        break;
    }
    
}


//5. Print EMployees details working Per Location
var empDetails = from emp in employees
                 join dpt in departments on emp.DeptNo equals dpt.DeptNo
                 group emp by emp.DeptNo into groupof
                 select new
                 {
                     deptnum = groupof.Key,
                     temp=groupof
                 };
Console.WriteLine();
Console.WriteLine("Details of Employees working per Location");
foreach (var item in empDetails)
{
    Console.WriteLine();
    if(item.deptnum==1001)
        Console.WriteLine("Pune");
    if(item.deptnum == 1002)
        Console.WriteLine("Bengalore");
    if (item.deptnum == 1003)
        Console.WriteLine("Mumbai");
    if (item.deptnum == 1004)
        Console.WriteLine("Delhi");
    if (item.deptnum == 1005)
        Console.WriteLine("Chennai");

    foreach (var it in item.temp)
    {
        Console.WriteLine($"EmpNum = {it.EmpNo} | EmpName = {it.EmpName} | Salary = {it.Salary} | Designation = {it.Designation}");
        
    }

}



Console.ReadLine();
