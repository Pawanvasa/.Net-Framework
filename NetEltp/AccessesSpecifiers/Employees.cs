namespace AccessesSpecifiers
{
    public class Employees
    {
        public int empNo;
        public String empName = String.Empty;
        public String designation = String.Empty;
        public int salary;
        public int deptNo;
    }

    public class Department
    {
        public int deptNo;
        public String deptName = String.Empty;
        public int capacity;
        public String location = String.Empty;
    }

    public class EmployeeCollection
    {
        public Dictionary<int, Employees> employeesDictionary = new Dictionary<int, Employees>()
        {
            { 1, new Employees() { empNo = 101, empName = "RamDev", designation = "ASE", salary = 53000, deptNo = 1001 } },
            { 2, new Employees() { empNo = 102, empName = "GopalRao", designation = "SE", salary = 33000, deptNo = 1003 } },
            { 3, new Employees() { empNo = 103, empName = "RadheShyam", designation = "SE", salary = 63000, deptNo = 1002 } },
            { 4, new Employees() { empNo = 104, empName = "Gopalam", designation = "HR", salary = 13000, deptNo = 1005 } },
            { 5, new Employees() { empNo = 105, empName = "Govind", designation = "JSE", salary = 93000, deptNo = 1002 } },
            { 6, new Employees() { empNo = 106, empName = "Mohan", designation = "ASE", salary = 63000, deptNo = 1003 } },
            { 7, new Employees() { empNo = 107, empName = "Madhav", designation = "HR", salary = 23000, deptNo = 1005 } }
        };

        /*public EmployeeCollection()
          {
              Add(1, new Employees() { empNo = 101, empName = "RamDev", designation = "ASE", salary = 53000, deptNo = 1001 });
              Add(2, new Employees() { empNo = 102, empName = "GopalRao", designation = "SE", salary = 33000, deptNo = 1003 });
              Add(3, new Employees() { empNo = 103, empName = "RadheShyam", designation = "SE", salary = 63000, deptNo = 1002 });
              Add(4, new Employees() { empNo = 104, empName = "Gopalam", designation = "HR", salary = 13000, deptNo = 1005 });
              Add(5, new Employees() { empNo = 105, empName = "Govind", designation = "JSE", salary = 93000, deptNo = 1002 });
              Add(6, new Employees() { empNo = 106, empName = "Mohan", designation = "ASE", salary = 63000, deptNo = 1003 });
              Add(7, new Employees() { empNo = 107, empName = "Madhav", designation = "HR", salary = 23000, deptNo = 1005 });

          }*/
    }

    public class DepartmentCollection
    {
        /* public DepartmentCollection()
         {
             Add(1, new Department() { deptNo = 1001, deptName = "IT", capacity = 10, location = "Pune" });
             Add(2, new Department() { deptNo = 1002, deptName = "SYS", capacity = 15, location = "Bengalore" });
             Add(3, new Department() { deptNo = 1003, deptName = "DBA", capacity = 5, location = "Mumbai" });
             Add(4, new Department() { deptNo = 1004, deptName = "QA", capacity = 12, location = "Delhi" });
             Add(5, new Department() { deptNo = 1005, deptName = "HR", capacity = 20, location = "Chennai" });

         }*/
        public Dictionary<int, Department> departmentDictionary = new Dictionary<int, Department>()
       {
           { 1, new Department() { deptNo = 1001, deptName = "IT", capacity = 10, location = "Pune" } },
           { 2, new Department() { deptNo = 1002, deptName = "SYS", capacity = 15, location = "Bengalore" } },
           { 3, new Department() { deptNo = 1003, deptName = "DBA", capacity = 5, location = "Mumbai" } },
           { 4, new Department() { deptNo = 1004, deptName = "QA", capacity = 12, location = "Delhi" } },
           { 5, new Department() { deptNo = 1005, deptName = "HR", capacity = 20, location = "Chennai" } }
        };
    }
}