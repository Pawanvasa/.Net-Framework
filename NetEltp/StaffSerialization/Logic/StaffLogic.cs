using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.Json;
namespace Assignment21.Logic
{
    public abstract class StaffLogic
    {
        public abstract void RegisterStaff(Staff statff);
        public abstract Dictionary<int, Staff> GetStatffs();

        public abstract List<Staff> GetStaffById(int id);
    }

    public class DoctorLogic : StaffLogic
    {
        public override void RegisterStaff(Staff statff)
        {
            if (HospitalDbStore.GlobalStaffStore != null)
            {
                HospitalDbStore.GlobalStaffStore.Add(statff.StaffId, statff);
            }
            var record = statff;
            int s = record.StaffId;
            Stream fs = new FileStream(@"C:\Users\Coditas\Documents\Coditas\Files\"+s+".json", FileMode.CreateNew);
            JsonSerializer.Serialize(fs, record);
            fs.Close(); // CLose the File
            fs.Dispose(); // Release the Object
        }
        public override Dictionary<int, Staff> GetStatffs()
        {
            return HospitalDbStore.GlobalStaffStore;
        }
       
        List<Staff> list = new List<Staff>();
        public override List<Staff> GetStaffById(int id)
        {
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.StaffId == id)
                {
                    list.Add(item);
                }
            }
            return list;
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
            var record = statff;
            int s = record.StaffId;
            Stream fs = new FileStream(@"C:\Users\Coditas\Documents\Coditas\Files\" + s + ".json", FileMode.CreateNew);
            JsonSerializer.Serialize(fs, record);
            fs.Close(); // CLose the File
            fs.Dispose(); // Release the Object
        }
        public override Dictionary<int, Staff> GetStatffs()
        {
            return HospitalDbStore.GlobalStaffStore;
        }

        List<Staff> list = new List<Staff>();
        public override List<Staff> GetStaffById(int id)
        {
          
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.StaffId == id)
                {
                    list.Add(item);
                }
            }
            return list;
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
            var record = statff;
            int s = record.StaffId;
            Stream fs = new FileStream(@"C:\Users\Coditas\Documents\Coditas\Files\" + s + ".json", FileMode.CreateNew);
            JsonSerializer.Serialize(fs, record);
            fs.Close(); // CLose the File
            fs.Dispose(); // Release the Object
        }
        public override Dictionary<int, Staff> GetStatffs()
        {
            return HospitalDbStore.GlobalStaffStore;
        }

        List<Staff> list = new List<Staff>();
        public override List<Staff> GetStaffById(int id)
        {

            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.StaffId == id)
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
