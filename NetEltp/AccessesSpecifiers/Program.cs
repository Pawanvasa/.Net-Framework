//1. Print Salary Per Department with EMpName
using AccessesSpecifiers;
EmployeeCollection employees =new EmployeeCollection();
DepartmentCollection departments = new DepartmentCollection();

var joinTables = employees.employeesDictionary.Join(
    departments.departmentDictionary,
    emp => emp.Value.deptNo,
    dpt => dpt.Value.deptNo,
    (emp1, dpt2) => new { dpt2.Value.deptName, emp1.Value.empName, emp1.Value.salary }).
    OrderByDescending(emp => emp.salary).
    Select(y => new
    {
        Deptname = y.deptName,
        Salary = y.salary,
        EmpName = y.empName,
    });
 

Console.WriteLine("Salary Per Department With Department Name and Emp Name ");
foreach (var item in joinTables)
{
    Console.WriteLine($"DeptName = {item.Deptname} | EmpName = {item.EmpName} | Salary =  {item.Salary}");
}
Console.ReadLine();


//lambda Expression
//(args)=expression
//int a = c+d;

//int sum(){
//return a+b;
//}
