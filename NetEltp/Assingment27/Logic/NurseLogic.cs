using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment27.Logic
{
    public class NurseLogic
    {
        Dictionary<int, Nurse> nurse;
        public NurseLogic()
        {
            nurse = new Dictionary<int, Nurse>();
        }

        public Dictionary<int, Nurse> RegisterNewNurse(int id, Nurse nurses)
        {
            nurse.Add(id, nurses);
            return nurse;
        }
        public Dictionary<int, Nurse> GetAllNurse()
        {
            return nurse;
        }

        public void updateNurseById(int id, Nurse nurses)
        {
            if (id == nurses.StaffId)
            {
                foreach (var s in nurse.Values)
                {
                    if (s.StaffId == nurses.StaffId)
                    {
                        // Update
                        s.StaffName = nurses.StaffName;
                        s.Email = nurses.Email;
                        s.ContactNo = nurses.ContactNo;
                        s.Education = nurses.Education;
                        s.ShiftStartTime = nurses.ShiftStartTime;
                        s.ShiftEndTime = nurses.ShiftEndTime;
                        s.nurseSpecilization = nurses.nurseSpecilization;
                        s.visitingroom = nurses.visitingroom;
                        s.servicetype = nurses.servicetype;
                        s.BasicPay = nurses.BasicPay;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Nurse Id Not Found");
            }
        }

        public Boolean DeleteNurseById(int id)
        {
            Nurse nurseSearch = null;
            foreach (var item in nurse.Values)
            {
                if (item.StaffId == id)
                {
                    nurseSearch = item;
                    break;
                }
            }
            if (nurseSearch == null)
            {
                Console.WriteLine("Nurse Id Not Found");
            }
            else
            {
                nurse.Remove(nurseSearch.StaffId);
            }
            return false;
        }
        public Nurse getNurseId(int id)
        {
            Nurse idSreach = null;
            foreach (var item in nurse.Values)
            {
                if (item.StaffId == id)
                {
                    idSreach = item;
                    break;
                }
            }
            return idSreach;
        }
        public Nurse getNurseByName(String name)
        {
            Nurse nameSreach = null;
            foreach (var item in nurse.Values)
            {
                if (item.StaffName == name)
                {
                    nameSreach = item;
                    break;
                }
            }
            return nameSreach;
        }
    }
}
