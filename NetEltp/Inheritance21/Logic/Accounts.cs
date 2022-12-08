using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21_Interface.Logic
{
    public class Accounts
    {
        public decimal GetStaffIncome(StaffLogicAbstract staff)
        {
            decimal NetIncome = staff.CalculateIncome() - staff.ShareToHospital()-GetTaxIncome(staff);
            return NetIncome;
        }
        public decimal GetGrossIncome(StaffLogicAbstract staff)
        {
            return staff.CalculateIncome() ;
        }
        public  decimal GetTaxIncome(StaffLogicAbstract staff)
        {
            return staff.CalculateIncome() * (decimal)0.2;
        }
    }
}
