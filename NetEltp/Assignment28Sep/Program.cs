using Assignment28Sep_Task;
using System.Diagnostics;

EmployeeList employeeList = new();
employeeList.AddStaff();


/*var parallelTimer2 = Stopwatch.StartNew();
Tax tax=new Tax();
var allEmployess = GlobalCollection.gobalList;
for (int index = 0; index < allEmployess.Count; index++)
{
    Task t1 = Task.Factory.StartNew(() =>
    {
        allEmployess[index] = tax.CalculateTax(allEmployess[index]).Result;
        tax.RightAllDataAsync(allEmployess[index]);
    });
    t1.Wait();
    Task t2 = Task.Factory.StartNew(() =>
    {
        tax.generateSalarySlips(allEmployess[index]);
    });
    t2.Wait();
}*/


var TimeTaken = Stopwatch.StartNew();
Tax tax = new();
var allEmployess = GlobalCollection.gobalList;
foreach (var employee in allEmployess)
{
    /*Task t1 = tax.CalculateTax(employee);
    await t1;
    tax.RightAllDataAsync(employee);
    tax.generateSalarySlips(employee);*/

    Task t = Task.Factory.StartNew(() =>
    {
        var staff = tax.CalculateTax(employee);
        employee.Tax = staff.Tax;
    });
    Task t1 = Task.Factory.StartNew(() => {
        tax.RightAllDataAsync(employee);
    });
    Task t2 = Task.Factory.StartNew(() => {
        tax.generateSalarySlips(employee);
    });
    Task.WaitAll(t,t1,t2);
}
Console.WriteLine($"Time Taken {TimeTaken.Elapsed.TotalSeconds}");
Console.ReadLine();