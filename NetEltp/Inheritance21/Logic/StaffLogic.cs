using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21_Interface.Logic
{
    public abstract class StaffLogic
    {
       
        private decimal BasicSalary = 0;
        public StaffLogic(decimal basicSalary)
        {
            BasicSalary = basicSalary;
        }

        public virtual decimal GetIncome()
        {
            return BasicSalary;
        }

    }


    public class DoctorLogic : StaffLogic, ITax, IGstTax,CrudOperations
    {
        public DoctorLogic(decimal sal) : base(sal)
        {

        }

        public void RegisterStaff(Staff staff)
        {
            if (HospitalDbStore.GlobalStaffStore != null)
            {
                HospitalDbStore.GlobalStaffStore.Add(staff.StaffId, staff);
            }
        }

        public void updateStaffById(int id)
        {
            throw new NotImplementedException();
        }

        public void deleteStaffById(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Staff> GetAllStaff()
        {
            return HospitalDbStore.GlobalStaffStore;
        }

        public override decimal GetIncome()
        {
            return base.GetIncome();
        }

      
        decimal ITax.CalculateTax(decimal taxableAmount)
        {
            return Convert.ToDecimal(taxableAmount * (decimal)0.05);
        }
        decimal IGstTax.CalculateTax(decimal taxableAmount)
        {
            return Convert.ToDecimal(taxableAmount * (Decimal)0.02);
        }
       

    }

    public class NurseLogic : StaffLogic, ITax
    {
        public NurseLogic(decimal sal) : base(sal)
        {

        }
        public override decimal GetIncome()
        {
            return base.GetIncome();
        }

        decimal ITax.CalculateTax(decimal taxableAmount)
        {
            return Convert.ToDecimal(taxableAmount * (decimal)0.05);
        }
      
    }
    public class TechnicianLogic : StaffLogic
    {
        public TechnicianLogic(decimal basicSalary) : base(basicSalary)
        {
        }

       
    }

}
