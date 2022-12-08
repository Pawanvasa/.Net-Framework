using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment27.Logic
{
    public class DoctorLogic
    {
        Dictionary<int, Doctor> Doctors;
        public DoctorLogic()
        {
            Doctors = new Dictionary<int, Doctor>();
        }
        public Dictionary<int, Doctor> RegisterNewDoctor(int id, Doctor doctor)
        {
            Doctors.Add(id, doctor);
            return Doctors;
        }
        public Dictionary<int, Doctor> GetAllDoctors()
        {
            return Doctors;
        }

        public void updateStaffById(int id, Doctor doctor)
        {
            if (id == doctor.StaffId)
            {
                foreach (var s in Doctors.Values)
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
                        s.Specialization = doctor.Specialization;
                        s.Fees = doctor.Fees;
                        s.MaxPatientsPerDay = doctor.MaxPatientsPerDay;
                        s.BasicPay = doctor.BasicPay;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Staff Id Not Found");
            }
        }
        public Boolean DeleteStaffById(int id)
        {
            Doctor docSearch = null;
            foreach (var item in Doctors.Values)
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
                Doctors.Remove(docSearch.StaffId);
            }
            return false;
        }
        public Doctor getByStaffId(int id)
        {
            Doctor idSreach = null;
            foreach (var item in Doctors.Values)
            {
                if (item.StaffId == id)
                {
                    idSreach = item;
                    break;
                }
            }
            return idSreach;
        }
        public Doctor getByStaffName(String name)
        {
            Doctor nameSreach = null;
            foreach (var item in Doctors.Values)
            {
                if (item.StaffName == name)
                {
                    nameSreach = item;
                    break;
                }
            }
            return nameSreach;
        }
        public Doctor getBySpecialization(String spec)
        {
            Doctor doc2 = null;
            foreach (var item in Doctors.Values)
            {
                if (item.Specialization == spec)
                {
                    doc2 = item;
                    Console.WriteLine($"{doc2.StaffId} {doc2.StaffName} {doc2.Email} {doc2.ContactNo} {doc2.Education} {doc2.ShiftStartTime} {doc2.ShiftEndTime} {doc2.Specialization} {doc2.Fees} {doc2.MaxPatientsPerDay}");
                }
            }
            return doc2;
        }

    }
}
