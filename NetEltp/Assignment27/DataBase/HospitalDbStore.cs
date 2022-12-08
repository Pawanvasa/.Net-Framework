using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21.DataBase
{
    public class HospitalDbStore
    {
        public static Dictionary<int,Staff>? GlobalStaffStore { get; set; } = new Dictionary<int, Staff>();

    }
}
