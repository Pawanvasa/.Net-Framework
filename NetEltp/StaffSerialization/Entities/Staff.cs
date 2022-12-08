using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21.Entities
{
    [Serializable]
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }

    public class Doctor : Staff
    {
        public string Education { get; set; } = string.Empty;
        public string Specilization { get; set; } = string.Empty;
    }

    public class Nurse : Staff
    {
        public int Experience { get; set; }
    }
    public class Technician : Staff
    {
        public int Repairs { get; set; }
        public int SaftyChecks { get; set; }
    }
}
