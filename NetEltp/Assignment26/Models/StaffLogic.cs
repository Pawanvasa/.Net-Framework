using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment26.Models
{
    public class DoctorLogic : IDbOperations<Doctor, int>
    {
        Dictionary<int, Doctor> docDictionary = new Dictionary<int, Doctor>();
        void IDbOperations<Doctor, int>.Create(int id, Doctor entity)
        {
            if (HospitalDbStore.GlobalStaffStore != null)
            {
                HospitalDbStore.GlobalStaffStore.Add(id, entity);
            }
        }

        public Boolean idSearch(int id)
        {
            Boolean idSearch = false;
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.StaffId == id)
                {
                    idSearch =true;
                    break;
                }
            }
            return idSearch;
        }

        void IDbOperations<Doctor, int>.Delete(int id)
        {
            Staff docSearch = null;
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.StaffId == id)
                {
                    docSearch = item;
                    break;
                }
            }
            if (docSearch == null)
            {
                Console.WriteLine("Staff Id Not Found");
            }
            else
            {
                HospitalDbStore.GlobalStaffStore.Remove(docSearch.StaffId);
                Console.WriteLine("Staff Details Deleted Successfully");
            }

        }

        Staff IDbOperations<Doctor, int>.Get(int id)
        {
            Doctor idSreach = null;
            foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
            {
                if (item.StaffId == id)
                {
                    idSreach = (Doctor)item;
                    break;
                }
            }
            return idSreach;
        }

        Dictionary<int, Staff> IDbOperations<Doctor, int>.GetAll()
        {
            return HospitalDbStore.GlobalStaffStore;
        }

        void IDbOperations<Doctor, int>.Update(int id, Doctor doctor)
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
                        s.ShiftStartTime = doctor.ShiftStartTime;
                        s.ShiftEndTime = doctor.ShiftEndTime;
                        s.BasicPay = doctor.BasicPay;
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

        public class NurseLogic : IDbOperations<Nurse, int>
        {
            Dictionary<int, Nurse> nurseDictionary = new Dictionary<int, Nurse>();
            void IDbOperations<Nurse, int>.Create(int id, Nurse entity)
            {
                if (HospitalDbStore.GlobalStaffStore != null)
                {
                    HospitalDbStore.GlobalStaffStore.Add(id, entity);
                }
            }

            void IDbOperations<Nurse, int>.Delete(int id)
            {
                Staff nurseSearch = null;
                foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
                {
                    if (item.StaffId == id)
                    {
                        nurseSearch = item;
                        break;
                    }
                }
                if (nurseSearch == null)
                {
                    Console.WriteLine("Staff Id Not Found");
                }
                else
                {
                    HospitalDbStore.GlobalStaffStore.Remove(nurseSearch.StaffId);
                    Console.WriteLine("Staff Details Deleted Successfully");
                }

            }

            Staff IDbOperations<Nurse, int>.Get(int id)
            {
                Nurse idSreach = null;
                foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
                {
                    if (item.StaffId == id)
                    {
                        idSreach = (Nurse)item;
                        break;
                    }
                }
                return idSreach;
            }

            Dictionary<int, Staff> IDbOperations<Nurse, int>.GetAll()
            {
                return HospitalDbStore.GlobalStaffStore;
            }

            void IDbOperations<Nurse, int>.Update(int id, Nurse entity)
            {
                if (id == entity.StaffId)
                {
                    foreach (var s in HospitalDbStore.GlobalStaffStore.Values)
                    {
                        if (s.StaffId == entity.StaffId)
                        {
                            // Update
                            s.StaffName = entity.StaffName;
                            s.Email = entity.Email;
                            s.ContactNo = entity.ContactNo;
                            s.Education = entity.Education;
                            s.ShiftStartTime = entity.ShiftStartTime;
                            s.ShiftEndTime = entity.ShiftEndTime;
                            s.BasicPay = entity.BasicPay;
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
        }

        public class DriverLogic : IDbOperations<Driver, int>
        {
            Dictionary<int, Driver> driverDictionary = new Dictionary<int, Driver>();
            void IDbOperations<Driver, int>.Create(int id, Driver entity)
            {
                if (HospitalDbStore.GlobalStaffStore != null)
                {
                    HospitalDbStore.GlobalStaffStore.Add(id, entity);
                }
            }

            void IDbOperations<Driver, int>.Delete(int id)
            {
                Staff driverSearch = null;
                foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
                {
                    if (item.StaffId == id)
                    {
                        driverSearch = item;
                        break;
                    }
                }
                if (driverSearch == null)
                {
                    Console.WriteLine("Staff Id Not Found");
                }
                else
                {
                    HospitalDbStore.GlobalStaffStore.Remove(driverSearch.StaffId);
                    Console.WriteLine("Staff Details Deleted Successfully");
                }

            }

            Staff IDbOperations<Driver, int>.Get(int id)
            {
                Driver idSreach = null;
                foreach (var item in HospitalDbStore.GlobalStaffStore.Values)
                {
                    if (item.StaffId == id)
                    {
                        idSreach = (Driver)item;
                        break;
                    }
                }
                return idSreach;
            }

            Dictionary<int, Staff> IDbOperations<Driver, int>.GetAll()
            {
                return HospitalDbStore.GlobalStaffStore;
            }

            void IDbOperations<Driver, int>.Update(int id, Driver entity)
            {
                if (id == entity.StaffId)
                {
                    foreach (var s in HospitalDbStore.GlobalStaffStore.Values)
                    {
                        if (s.StaffId == entity.StaffId)
                        {
                            // Update
                            s.StaffName = entity.StaffName;
                            s.Email = entity.Email;
                            s.ContactNo = entity.ContactNo;
                            s.Education = entity.Education;
                            s.ShiftStartTime = entity.ShiftStartTime;
                            s.ShiftEndTime = entity.ShiftEndTime;
                            s.BasicPay = entity.BasicPay;
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
        }
    }
}

