using System.Diagnostics;

EmployeeList employeeList = new EmployeeList();
employeeList.AddStaff();

/*var Timer1 = Stopwatch.StartNew();
var allEmployees2 = GlobalCollection.gobalList;
for (int i = 0; i < allEmployees2.Count; i++)
{
    Thread t = new Thread(() =>
    {

        allEmployees2[i] = CalculateTax(allEmployees2[i]);
        Console.WriteLine($"Sequential Tax of {allEmployees2[i].StaffId} {allEmployees2[i].StaffName} is = {allEmployees2[i].Tax}");
        insertAllStaffIntoFile(allEmployees2[i]);
        generateSalarySlips(allEmployees2[i]);
    });
    t.Start();
    t.Join();
}
Console.WriteLine($"Normal Timing {Timer1.Elapsed.TotalSeconds}");
Console.ReadLine();*/

var parallelTimer2 = Stopwatch.StartNew();
var allEmployees = GlobalCollection.gobalList;
Parallel.For(0, allEmployees.Count, (i) =>
{
    allEmployees[i] = CalculateTax(allEmployees[i]);
    Console.WriteLine($"Tax of {allEmployees[i].StaffId} {allEmployees[i].StaffName} is = {allEmployees[i].Tax}");
    insertAllStaffIntoFile(allEmployees[i]);
    generateSalarySlips(allEmployees[i]);
});
Console.WriteLine($"Parallel Timing {parallelTimer2.Elapsed.TotalSeconds}");
Console.ReadLine();




static Staff CalculateTax(Staff staff)
{
    staff.Tax = (int)((Decimal)staff.Salary * (Decimal)0.1);
    return staff;
}

Mutex mutex = new Mutex();
mutex.WaitOne();
static void insertAllStaffIntoFile(Staff staff)
{
    string filePath = @"C:\Users\Coditas\Documents\Coditas\Files\All.txt";
    Console.WriteLine($"----------------Record-{staff.StaffId}----------------");
    Console.WriteLine($" StaffId = {staff.StaffId} \n StaffName = {staff.StaffName} \n Department = {staff.Department} \n Location = {staff.Location} \n salary = {staff.Salary} \n tax = {staff.Tax}");
    Console.WriteLine($"----------------------------------------");
    WriteFile(filePath, $"----------------Record-{staff.StaffId}----------------");
    WriteFile(filePath, $" StaffId = {staff.StaffId} \n StaffName = {staff.StaffName} \n Department = {staff.Department} \n Location = {staff.Location} \n salary = {staff.Salary} \n tax = {staff.Tax}");
    WriteFile(filePath, $"----------------------------------------");
}
mutex.ReleaseMutex();


mutex.WaitOne();

static void generateSalarySlips(Staff staff)
{
    string filename = $@"C:\Users\Coditas\Documents\Coditas\Files\SalarySlip{staff.StaffId}.txt";
    salarySlip(filename, staff);
}
mutex.ReleaseMutex();


static void salarySlip(string filename, Staff staff)
{

    WriteFile(filename, $"Name : {staff.StaffName}    StaffId : {staff.StaffId}    StaffType: {staff.Department}"
      + "\n======================================================================================="
      + "\n                           INCOME DETAILS                            "
      + "\n======================================================================================="
      + $"\nBasicPay : {staff.Salary}"
      + "\n======================================================================================="
      + $"\nTax Paid By Employee : {staff.Tax}"
      + "\n======================================================================================="
      + $"\nGross Income of Employee :{staff.Salary} "
      + "\n=======================================================================================");
}

mutex.WaitOne();
static void WriteFile(string fileName, string contents)
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
mutex.ReleaseMutex();

Console.ReadLine();