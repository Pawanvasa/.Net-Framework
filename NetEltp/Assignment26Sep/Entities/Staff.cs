using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21.Entities
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int Salary { get; set; }
        public int Tax { get; set; }
    }

    public class EmployeeList 
    {
        public void AddStaff()
        {
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 102, StaffName = "Baban",    Salary = 22000,Department="Doctor", Location="Bengalor" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 101, StaffName = "Abhay",    Salary = 11000,Department="Nurse", Location="Bengalor" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 103, StaffName = "Chaitanya",Salary = 33000,Department="Nurse", Location="Bengalor" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 104, StaffName = "Deepak",   Salary = 44000,Department="Nurse", Location="Bengalor" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 105, StaffName = "Eshwar",   Salary = 55000,Department="Nurse", Location="Bengalor" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 106, StaffName = "Falgun",   Salary = 66000,Department="Nurse", Location="Bengalor" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 107, StaffName = "Ganpat",   Salary = 77000,Department="Doctor", Location="Hydrabad" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 108, StaffName = "Hitesh",   Salary = 88000,Department="Doctor", Location="Hydrabad" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 109, StaffName = "Ishan",    Salary = 99000,Department="Doctor", Location="Hydrabad" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 110, StaffName = "Jay",      Salary = 31000,Department="Doctor", Location="Hydrabad" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 111, StaffName = "Kaushubh", Salary = 21000,Department="Doctor", Location="Hydrabad" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 112, StaffName = "Lakshman", Salary = 22000,Department="Technician", Location="Delhi" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 113, StaffName = "Mohan",    Salary = 23000,Department="Technician", Location="Delhi" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 114, StaffName = "Naveen",   Salary = 24000,Department="Technician", Location="Delhi" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 115, StaffName = "Omkar",    Salary = 25000,Department="Technician", Location="Delhi" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 116, StaffName = "Prakash",  Salary = 26000,Department="Technician", Location="Delhi" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 117, StaffName = "Qumars",   Salary = 27000,Department="Nurse", Location="Mumbai" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 118, StaffName = "Ramesh",   Salary = 28000,Department="Nurse", Location="Mumbai" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 119, StaffName = "Sachin",   Salary = 29000,Department="Nurse", Location="Mumbai" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 120, StaffName = "Tushar",   Salary = 30000,Department="Nurse", Location="Mumbai" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 121, StaffName = "Umesh",    Salary = 31000,Department="Nurse", Location="Mumbai" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 122, StaffName = "Vivek",    Salary = 32000,Department="Doctor", Location="pune" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 123, StaffName = "Waman",    Salary = 33000,Department="Doctor", Location="pune" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 124, StaffName = "Xavier",   Salary = 34000,Department="Doctor", Location="pune" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 125, StaffName = "Yadav",    Salary = 35000,Department="Doctor", Location="pune" });
            GlobalCollection.gobalList.Add(new Staff() {StaffId = 126, StaffName = "Zishan",   Salary = 36000,Department="Doctor", Location="pune" });

        }
    }
}
