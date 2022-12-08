using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment27.Logic
{
    public class Accounts
    {
        private int PatientsDiagonsed = 0;
        private int OperationsPerDay = 0;
        private decimal TotalIncome = 0;
        public void docSet(int patientsDiagonsed, int operationsPerDay)
        {
            PatientsDiagonsed = patientsDiagonsed;
            OperationsPerDay = operationsPerDay;
        }
        public Decimal docIncomeCal(int BasicPay)
        {
            decimal operationFees = OperationsPerDay * 30 * 10000;
            decimal patientsFessReceived = PatientsDiagonsed * 30 * 500;
            TotalIncome = BasicPay + operationFees + patientsFessReceived;
            return TotalIncome;
        }

        public decimal InjectionApplied = 0;
        public decimal PatientsMonitored = 0;
        public void setNurse(Decimal injections, Decimal patients)
        {
            InjectionApplied = injections;
            PatientsMonitored = patients;
        }
        public Decimal nurseIncomeCal(int BasicPay)
        {
            decimal InjectionFess = InjectionApplied * 30 * 100;
            decimal patientsFessReceived = PatientsMonitored * 30 * 50;
            TotalIncome = BasicPay + InjectionFess + patientsFessReceived;
            return TotalIncome;
        }

        public int saftyChecks { get; set; }
        public int repairs { get; set; }

        public void setTeachnician(int checks, int Repairs)
        {
            saftyChecks = checks;
            repairs = Repairs;
        }
        public Decimal techIncomeCal(int BasicPay)
        {
            decimal saftyChecksFee = saftyChecks * 30 * 50;
            decimal repairsFee = repairs * 30 * 100;
            TotalIncome = BasicPay + saftyChecksFee + repairsFee;
            return TotalIncome;
        }
    }
}
