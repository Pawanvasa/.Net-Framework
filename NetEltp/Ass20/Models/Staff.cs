using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass20.Models
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
    }
}
