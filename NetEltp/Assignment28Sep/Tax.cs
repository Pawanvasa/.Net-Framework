using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment28Sep_Task
{
    public class Tax
    {

        public Staff CalculateTax(Staff staff)
        {
       
            staff.Tax = (int)(staff.Salary * 0.1);
            return staff;
        }

        public async void RightAllDataAsync(Staff staff)
        {
            await Task.Run(() =>
            {
                string filePath = @"C:\Users\Coditas\Documents\Coditas\Files\All.txt";
                Console.WriteLine($"----------------Record-{staff.StaffId}----------------");
                Console.WriteLine($" StaffId = {staff.StaffId} \n StaffName = {staff.StaffName} \n Department = {staff.Department} \n Location = {staff.Location} \n salary = {staff.Salary} \n tax = {staff.Tax}");
                Console.WriteLine($"----------------------------------------");
                WriteFile(filePath, $"----------------Record-{staff.StaffId}----------------");
                WriteFile(filePath, $" StaffId = {staff.StaffId} \n StaffName = {staff.StaffName} \n Department = {staff.Department} \n Location = {staff.Location} \n salary = {staff.Salary} \n tax = {staff.Tax}");
                WriteFile(filePath, $"----------------------------------------");
            });
        }

        public async void generateSalarySlips(Staff staff)
        {
            await Task.Run(() => {
                string filename = $@"C:\Users\Coditas\Documents\Coditas\Files\SalarySlip{staff.StaffId}.txt";
                salarySlip(filename, staff);
            });
           
        }

        public async void salarySlip(string filename, Staff staff)
        {
            await Task.Run(() => {
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
            });
        }

        public async void WriteFile(string fileName, string contents)
        {
            try
            {
                if (fileName == string.Empty)
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                using StreamWriter sw = new StreamWriter(fileName, true);
                await sw.WriteLineAsync(contents);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }
    }
}
