using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Class
{
    public class StaffLogic
    {
        List<Staff> staffs;

        public StaffLogic()
        {
            // Lets have some DEfault 
            staffs = new List<Staff>()
            { 
                // Object Initializer, provide the object has public properties
               new Staff() {StaffId=1,StaffName="Amar",Email="Amar@myhosp.com", DeptName="Cancer",Gender="Male",DateOfBirth= new DateOnly(1985, 05, 24),StaffCategory="Doctor",Education="MBBS",ContatNo=7747474 },

                new Staff() {StaffId=2,StaffName="Mohan",Email="Mohan@myhosp.com", DeptName="Heart",Gender="Male",DateOfBirth= new DateOnly(1994, 07, 31),StaffCategory="Brother",Education="DMLT",ContatNo=7747499 },

            };
        }

        // Public Methods or Bhavior
        public List<Staff> RegisterNewStaff(Staff staff)
        {
            staffs.Add(staff);
            return staffs;
        }

        public List<Staff> UpdateStaffInfo(int id, Staff staff)
        {
            if (id == staff.StaffId)
            {
                foreach (var item in staffs)
                {
                    if (item.StaffId == staff.StaffId)
                    {
                        // Update
                        item.StaffName = staff.StaffName;
                        item.Email = staff.Email;
                        item.DeptName = staff.DeptName;
                        item.Gender = staff.Gender;
                        item.DateOfBirth = staff.DateOfBirth;
                        item.StaffCategory = staff.StaffCategory;
                        item.Education = staff.Education;
                        item.ContatNo = staff.ContatNo;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }
            return staffs;
        }
        public Boolean DeleteStaff(int id)
        { 
            Staff searchefStaff = null;
            foreach (var item in staffs)
            { 

                if (item.StaffId == id)
                {
                    searchefStaff = item;
                    break;
                }
            }
            if(searchefStaff != null)
            {
                staffs.Remove(searchefStaff);
                return true;
            }
           else
            return false;
        }
        public List<Staff> GetAllStaff()
        {
            return staffs;
        }
        public Staff GetStaffById(int id)
        {
             Staff idSreach = null;
             foreach (var item in staffs)
             {
                 if (item.StaffId == id)
                 {
                     idSreach= item;
                     break;
                 }
             }
             return idSreach;

        }

    }
}
