using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment21_Interface.Logic
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
        public List<Staff> SearchByDpt(String dptName)
        { 
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.Department == dptName)
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
