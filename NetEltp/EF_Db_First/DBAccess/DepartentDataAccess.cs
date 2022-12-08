using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Db_First.Models;
using Microsoft.EntityFrameworkCore;
namespace EF_Db_First.DBAccess
{
    public class DepartentDataAccess
    {
        eShoppingCodiContext _context;

        public DepartentDataAccess()
        {
            _context = new eShoppingCodiContext();
        }

        public async Task<List<Department>> GetAsync()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<Department> GetAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }
        public async Task<Department> CreateAsync(Department dept)
        {
            var res = await _context.Departments.AddAsync(dept);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Department> UpdateAsync(Department dept,Employee emp)
        {

            var rec = await _context.Departments.FindAsync(dept.DeptNo);
            var rec1=await _context.Employees.FindAsync(emp.EmpNo);

            if (rec != null) //&& rec1 !=null)
            {
                // Update Individual Property
                rec.DeptName = dept.DeptName;
                rec.Location = dept.Location;
                rec.Capacity = dept.Capacity;

               /* rec1.EmpName=emp.EmpName;
                rec1.Designation=emp.Designation;
                rec1.Salary=emp.Salary;*/
                await _context.SaveChangesAsync();
                return rec; // Modified REcord
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rec = await _context.Departments.FindAsync(id);
            if (rec != null)
            {
                _context.Departments.Remove(rec);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
