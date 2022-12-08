using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment27.Models
{
    public class Doctor : Staff
    {
        public string? Specialization { get; set; }
        public int Fees { get; set; }
        public int MaxPatientsPerDay { get; set; }

        public int operationsPerDay { get; set; }
        public int patientsDiagonsed { get; set; }

        public void SetBasicPay(int pay)
        {
            this.BasicPay = pay;
        }

        public int GetBasicPay()
        {
            return this.BasicPay;
        }

        public int PatientsDiagonsed = 0;
        public int OperationsPerDay = 0;
        public void setDetails(decimal sal, int patientsDiagonsed, int operationsPerDay)
        {
            PatientsDiagonsed = patientsDiagonsed;
            OperationsPerDay = operationsPerDay;
        }

    }
}
