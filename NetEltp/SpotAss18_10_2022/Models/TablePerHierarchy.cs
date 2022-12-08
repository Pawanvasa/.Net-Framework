using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpotAss18_10_2022.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffCategory { get; set; }=String.Empty;
        public string StaffName { get; set; } = String.Empty;
        public string Contact { get; set; } = String.Empty;
    }
    public class Doctor :Staff
    {
        public int PatientsDaigonised { get; set; }
        public int NumberOperations { get; set; }
    }
    public class Nurse : Staff
    {
        public int NumberOfInjections { get; set; }
        public int NumberOfPatientsMonitored { get; set; }
    }
    public class WardBoy : Staff
    {
        public int NumberRoomsCleaned { get; set; }
    }
}
