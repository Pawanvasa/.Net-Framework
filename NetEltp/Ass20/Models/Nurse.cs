using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass20.Models
{
    public class Nurse :Staff
    {
        public String nurseSpecilization { get; set; }
        public int visitingroom { get; set; }
        public String servicetype { get; set; }
        public void SetBasicPay(int pay)
        {
            this.BasicPay = pay;
        }
        public int GetBasicPay()
        {
            return this.BasicPay;
        }
        public decimal InjectionApplied { set; get; }
        public decimal PatientsMonitored { set; get; }
        public decimal GrossIncome { set; get; }
    }
}
