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
        public abstract Dictionary<int,Staff> GetStatffs();
        public abstract void updateStaff(int id,Staff staff);
        public abstract Boolean DeleteStaffById(int id);
        public abstract Staff GetStaffById(int id);
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
        public override Staff GetStaffById(int id)
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

       public override void updateStaff(int id,Staff doctor)
        { 
            if (id == doctor.StaffId)
            {
                foreach (var s in HospitalDbStore.GlobalStaffStore.Values)
                {
                    if (s.StaffId == doctor.StaffId)
                    {
                        // Update
                        s.StaffName = doctor.StaffName;
                        s.Email = doctor.Email;
                        s.ContactNo = doctor.ContactNo;
                        s.Education = doctor.Education;
                        s.Location = doctor.Location;
                        Console.WriteLine("Details Updated Successfully");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Staff Id Not Found");
            }

        }

        public override Boolean DeleteStaffById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class NurseLogic : StaffLogic
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

        public override Staff GetStaffById(int id)
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
    public override void updateStaff(int id, Staff nurse)
    {
        if (id == nurse.StaffId)
        {
            foreach (var s in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (s.StaffId == nurse.StaffId)
                {
                    // Update
                    s.StaffName = nurse.StaffName;
                    s.Email = nurse.Email;
                    s.ContactNo = nurse.ContactNo;
                    s.Education = nurse.Education;
                    s.Location = nurse.Location;
                    Console.WriteLine("Details Updated Successfully");
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Staff Id Not Found");
        }
    }

        public override Boolean DeleteStaffById(int id)
        {
            throw new NotImplementedException();
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

            public override Staff GetStaffById(int id)
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



            public override void updateStaff(int id, Staff technician)
            {
                if (id == technician.StaffId)
                {
                    foreach (var s in HospitalDbStore.GlobalStaffStore.Values)
                    {
                        if (s.StaffId == technician.StaffId)
                        {
                            // Update
                            s.StaffName = technician.StaffName;
                            s.Email = technician.Email;
                            s.ContactNo = technician.ContactNo;
                            s.Education = technician.Education;
                            s.Location = technician.Location;
                            Console.WriteLine("Details Updated Successfully");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Staff Id Not Found");
                }

            }

        public override Boolean DeleteStaffById(int id)
        {
            Staff searchefStaff = null;
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {

                if (item.StaffId == id)
                {
                    searchefStaff = item;
                    break;
                }
            }
            if (searchefStaff != null)
            {
                HospitalDbStore.GlobalStaffStore.Remove(searchefStaff.StaffId, out searchefStaff);
                return true;
            }
            else
                return false;
        }
        
    }
}
