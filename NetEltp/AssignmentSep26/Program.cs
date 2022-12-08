using Assignment26Sep;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Text.Json;

var parallelTimer = Stopwatch.StartNew();
var empList=  new EmployeeList();
Parallel.For(0, empList.Count, (i) =>
{
    empList[i] = ProcessTax.CalculateTax(empList[i]);
    Console.WriteLine($"Parallel Tax of {empList[i].EmpNo}  {empList[i].EmpName} is = {empList[i].TDS}");
    WriteFile(@"C:\Users\Coditas\Documents\Coditas\Files\All.txt", $"{empList[i].EmpName} {empList[i].EmpNo} {empList[i].Salary}");
});




static void WriteFile(string fileName,string contents)
{
    try
    {
        if (fileName == string.Empty)
        {
            throw new Exception("File Name Cannot be Empty");
        }
        using (StreamWriter sw = new StreamWriter(fileName, true))
        {
            sw.WriteLine(contents);
        }
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message); ;
    }

}
Console.WriteLine($"Parallel Timing {parallelTimer.Elapsed.TotalSeconds}");
Console.ReadLine();