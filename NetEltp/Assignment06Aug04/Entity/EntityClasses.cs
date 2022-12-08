using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04Aug
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ContactNo { get; set; }
        public string? Education { get; set; }
        public int ShiftStartTime { get; set; }
        public int ShiftEndTime { get; set; }
        public int BasicPay { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Location { get; set; }= string.Empty;
    }

    public class Doctor : Staff
    {
        public string Specilization { get; set; } = string.Empty;
        public int Fees { get; set; }
    }

    public class Nurse : Staff
    {

        public int Experience { get; set; }
        public int PatientsMonitored { get; set; }
    }

    public class Technician : Staff
    {
        public int SaftyChecksDone { get; set; }
        public int RepairsDone { get; set; } 
    }
}
