using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21.Logic
{
    public abstract class StaffLogic
    {
        public abstract void RegisterStaff(Staff statff);
        public abstract Dictionary<int, Staff> GetStatffs();
    }

    public class DoctorLogic : StaffLogic
    {
        public override void RegisterStaff(Staff statff)
        {
            if (HospitalDbStore.GlobalStaffStore != null)
            {
                HospitalDbStore.GlobalStaffStore.Add(statff.StaffId,statff);
            }
        }
        public override Dictionary<int,Staff> GetStatffs()
        {
            return HospitalDbStore.GlobalStaffStore;
        }
        public  Staff GetStaffById(int id)
        {
            Staff idSreach = null;
            foreach (var item in HospitalDbStore.GlobalStaffStore)
            {
                if (item.Value.StaffId == id)
                {
                    idSreach = item.Value;
                    break;
                }
            }
            return idSreach;
        }

    }

    public class NurseLogic : StaffLogic
    {
        public override void RegisterStaff(Staff statff)
        {
            if (HospitalDbStore.GlobalStaffStore != null)
            {
                HospitalDbStore.GlobalStaffStore.Add(statff.StaffId,statff);
            }
        }
        public override Dictionary<int, Staff> GetStatffs()
        {
            return HospitalDbStore.GlobalStaffStore;
        }

     
    }
    public class TechnicianLogic : StaffLogic
    {
        public override void RegisterStaff(Staff statff)
        {
            if (HospitalDbStore.GlobalStaffStore != null)
            {
                HospitalDbStore.GlobalStaffStore.Add(statff.StaffId, statff);
            }
        }
        public override Dictionary<int, Staff> GetStatffs()
        {
            return HospitalDbStore.GlobalStaffStore;
        }

    
    }
}
