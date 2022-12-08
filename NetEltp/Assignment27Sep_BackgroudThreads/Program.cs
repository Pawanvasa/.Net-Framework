using BackGround_Threads;

Console.WriteLine("Conditional Search");

EmployeesInfo employees = new EmployeesInfo();
DepartmentInfo departmentInfo = new DepartmentInfo();
Console.WriteLine("Enter Department");
string department = Console.ReadLine();


var backGroundWorkerThread = new Thread(() =>
{
    departmentCheck(department!);
});
backGroundWorkerThread.IsBackground = true;
backGroundWorkerThread.Start();
Console.ReadLine();


static bool departmentCheck(string dptm)
{
    DepartmentInfo departmentInfo = new DepartmentInfo();
    EmployeesInfo employeesInfo = new EmployeesInfo();
    var deptInfo = departmentInfo.departmentInfo;
    bool check = false;
    foreach (var dtp in deptInfo)
    {
        if (dtp.Value.deptName == dptm)
        {
            check = true;
            var result = (from emp in employeesInfo.employeeInfo
                          join dpt in departmentInfo.departmentInfo on emp.Value.deptNo equals dpt.Value.deptNo
                          group emp by dpt.Value.deptName into groupof
                          select new
                          {
                              DeptName = groupof.Key,
                              temp = groupof
                          });

            foreach (var emp in result)
            {
                if (emp.DeptName == dptm)
                {
                    foreach (var emp2 in emp.temp)
                    {
                        Console.WriteLine($"EmployeeName = {emp2.Value.empName}  | salary = {emp2.Value.salary} | Designation = {emp2.Value.designation}");
                    }
                }
            }
            break;
        }
    }
    if (!check)
    {
        Console.WriteLine("No Match Record Found");
    }

    return check;
}

