using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass20.Models
{
    public class Technician : Staff
    { 
        public int saftyChecks { get; set; }
        public int repairs { get; set; }

        public void SetBasicPay(int pay)
        {
            this.BasicPay = pay;
        }
        public int GetBasicPay()
        {
            return this.BasicPay;
        }
    }
}
