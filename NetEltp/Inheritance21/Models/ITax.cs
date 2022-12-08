using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21_Interface.Models
{
    public interface ITax
    {
        decimal CalculateTax(decimal taxableAmount);
    }
}
