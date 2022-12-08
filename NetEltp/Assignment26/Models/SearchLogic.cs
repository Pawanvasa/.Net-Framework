using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment26.Models
{
    public class SearchLogic
    {
        List<Staff> list=new List<Staff>();
        public List<Staff> SearchByName(String name)
        {
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.StaffName == name)
                {
                    list.Add (item);
                }
            }
            return list;
        }
        public List<Staff> SearchByStaffId(int id)
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
        public List<Staff> SearchByLoc(String loc)
        {
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.Location == loc)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public List<Staff> SearchByAnd(String name, String dptname, String loc)
        {
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.Location == loc && item.Department == dptname && item.StaffName == name)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public List<Staff> SearchByOr(String name, String dptname, String loc)
        {
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.Location == loc || item.Department == dptname || item.StaffName == name)
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
