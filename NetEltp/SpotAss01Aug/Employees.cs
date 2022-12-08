using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotAss01Aug
{
    public class Employees
    {
       public Decimal EmpNo { set; get; }    
       public String EmpName { set; get; }=String.Empty;
       public String Designation { set; get; } = String.Empty;
       public Decimal Salary { set; get; }
       public Decimal DeptNo { set; get; }

    }
    public class EmployeeCollection : List<Employees>
    {
        public EmployeeCollection()
        {
            Add(new Employees() { EmpNo = 101, EmpName = "YashodaNandan", Designation = "ASE", Salary = 53000 ,DeptNo =1001});
            Add(new Employees() { EmpNo = 102, EmpName = "DevkiNandan", Designation = "SE", Salary = 33000, DeptNo = 1003});
            Add(new Employees() { EmpNo = 103, EmpName = "RadheShyam", Designation = "SE", Salary = 63000, DeptNo = 1002 });
            Add(new Employees() { EmpNo = 104, EmpName = "Gopal", Designation = "HR", Salary = 13000, DeptNo = 1005 });
            Add(new Employees() { EmpNo = 105, EmpName = "Govind", Designation = "JSE", Salary = 93000, DeptNo = 1002 });
            Add(new Employees() { EmpNo = 106, EmpName = "Mohan", Designation = "ASE", Salary = 63000, DeptNo = 1003 });
            Add(new Employees() { EmpNo = 107, EmpName = "Madhav", Designation = "HR", Salary = 23000, DeptNo = 1001 });
            Add(new Employees() { EmpNo = 108, EmpName = "Milind", Designation = "AC", Salary = 53000, DeptNo = 1004 });
            Add(new Employees() { EmpNo = 109, EmpName = "Vasudev", Designation = "HR", Salary = 63000 , DeptNo = 1004});
            Add(new Employees() { EmpNo = 110, EmpName = "Shridhar", Designation = "ASE", Salary = 83000, DeptNo = 1001 });
            Add(new Employees() { EmpNo = 111, EmpName = "Pawan", Designation = "Manager", Salary = 133000, DeptNo = 1001});
            Add(new Employees() { EmpNo = 112, EmpName = "Barath", Designation = "CTO", Salary = 53000, DeptNo = 1002 });
            Add(new Employees() { EmpNo = 113, EmpName = "Mohan", Designation = "CEO", Salary = 43000, DeptNo = 1001 });
            Add(new Employees() { EmpNo = 114, EmpName = "Sandya", Designation = "DOT", Salary = 62400, DeptNo = 1004 });
            Add(new Employees() { EmpNo = 115, EmpName = "RamRaj", Designation = "DOT", Salary = 33000, DeptNo = 1003 });
            Add(new Employees() { EmpNo = 116, EmpName = "Srinu", Designation = "AC", Salary =20000, DeptNo = 1005 });
            Add(new Employees() { EmpNo = 117, EmpName = "Amar", Designation = "ASE", Salary = 42000, DeptNo = 1001 });
            Add(new Employees() { EmpNo = 118, EmpName = "Banu", Designation = "SE", Salary = 53000, DeptNo = 1003 });
            Add(new Employees() { EmpNo = 119, EmpName = "Bhargav", Designation = "SDE", Salary = 22000, DeptNo = 1005 });
            Add(new Employees() { EmpNo = 120, EmpName = "Lasya", Designation = "SDE", Salary = 93000, DeptNo=1001 });

        }
    }
    public class Department
    {
        public Decimal DeptNo { set; get; }
        public String DeptName { set; get; } = String.Empty;
        public Decimal Capacity { set; get; }
        public String Location { set; get; } = String.Empty;
    }
    public class DepartmentCollection : List<Department>
    {   
        public DepartmentCollection()
        {
            Add(new Department() { DeptNo = 1001, DeptName = "IT", Capacity = 10, Location = "Pune" });
            Add(new Department() { DeptNo = 1002, DeptName = "SYS", Capacity = 15, Location = "Bengalore" });
            Add(new Department() { DeptNo = 1003, DeptName = "CTD", Capacity = 5, Location = "Mumbai" });
            Add(new Department() { DeptNo = 1004, DeptName = "ACCTS", Capacity = 12, Location = "Delhi" });
            Add(new Department() { DeptNo = 1005, DeptName = "HRD", Capacity = 20, Location = "Chennai" });

        }
    }
}
