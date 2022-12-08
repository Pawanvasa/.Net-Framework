﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21_Interface.Models
{
    public interface CrudOperations
    {
        void RegisterStaff(Staff staff);
        Dictionary<int, Staff> GetAllStaff();
        void updateStaffById(int id);
        void deleteStaffById(int id);

    }
}
