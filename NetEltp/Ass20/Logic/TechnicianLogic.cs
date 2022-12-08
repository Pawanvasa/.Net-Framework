using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ass20.Models;
namespace Assignment20.Logic
{
    public class TechnicianLogic
    {
        Dictionary<int, Technician> technicians;
        public TechnicianLogic()
        {
            technicians = new Dictionary<int, Technician>();
        }

        public Dictionary<int, Technician> RegisterNewTechnician(int id, Technician tech)
        {
            technicians.Add(id, tech);
            return technicians;
        }
        public Dictionary<int, Technician> GetAllTechnician()
        {
            return technicians;
        }

        public void updateTechById(int id, Technician tech2)
        {
            if (id == tech2.StaffId)
            {
                foreach (var s in technicians.Values)
                {
                    if (s.StaffId == tech2.StaffId)
                    {
                        // Update
                        s.StaffName = tech2.StaffName;
                        s.Email = tech2.Email;
                        s.ContactNo = tech2.ContactNo;
                        s.Education = tech2.Education;
                        s.ShiftStartTime = tech2.ShiftStartTime;
                        s.ShiftEndTime = tech2.ShiftEndTime;
                        s.saftyChecks = tech2.saftyChecks;
                        s.repairs = tech2.repairs;
                        s.BasicPay = tech2.BasicPay;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Technisian Id Not Found");
            }
        }

        public Boolean DeleteTechnisianById(int id)
        {
            Technician technicianSearch = null;
            foreach (var item in technicians.Values)
            {
                if (item.StaffId == id)
                {
                    technicianSearch = item;
                    break;
                }
            }
            if (technicianSearch == null)
            {
                Console.WriteLine("Technician Id Not Found");
            }
            else
            {
                technicians.Remove(technicianSearch.StaffId);
            }
            return false;
        }
        public Technician getTechnicianById(int id)
        {
            Technician techIdSreach = null;
            foreach (var item in technicians.Values)
            {
                if (item.StaffId == id)
                {
                    techIdSreach = item;
                    break;
                }
            }
            return techIdSreach;
        }
        public Technician getTechnicianByName(String name)
        {
            Technician techNameSreach = null;
            foreach (var item in technicians.Values)
            {
                if (item.StaffName == name)
                {
                    techNameSreach = item;
                    break;
                }
            }
            return techNameSreach;
        }
    }
}
