﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21.Logic
{
    public abstract class StaffLogicAbstract
    {
        protected decimal BasicPay = 0;

        public virtual decimal CalculateIncome()
        {
            return this.BasicPay = 10000;
        }
        public abstract decimal ShareToHospital();

    }
    public class DoctorLogicEx : StaffLogicAbstract
    {
            private int PatientsDiagonsed = 0;
            private int OperationsPerDay = 0;
            private decimal TotalIncome = 0;
            public DoctorLogicEx(int patientsDiagonsed, int operationsPerDay)
            {
                PatientsDiagonsed = patientsDiagonsed;
                OperationsPerDay = operationsPerDay;
            }

    
        public override decimal CalculateIncome()
        {
            decimal operationFees = OperationsPerDay * 30 * 10000;
            decimal patientsFessReceived = PatientsDiagonsed * 30 * 500;
            TotalIncome = base.CalculateIncome() + operationFees + patientsFessReceived;
            return TotalIncome;
        }
        public override decimal ShareToHospital()
        {
            return TotalIncome * Convert.ToDecimal(0.2);
        }
    }


    public class NurseLogicEx : StaffLogicAbstract
    {
        private decimal InjectionApplied = 0;
        private decimal PatientsMonitored = 0;

        private decimal GrossIncome = 0;


        public NurseLogicEx(decimal injectionApplied, decimal patientsMonitored)
        {
            InjectionApplied = injectionApplied;
            PatientsMonitored = patientsMonitored;
        }

        public override decimal CalculateIncome()
        {
            decimal duetyFees = PatientsMonitored * 250;
            decimal injecionFees = InjectionApplied * 60;
            GrossIncome = base.CalculateIncome() + duetyFees + injecionFees;
            return GrossIncome;
        }

        public override decimal ShareToHospital()
        {
            return GrossIncome * Convert.ToDecimal(0.05);
        }
    }
    public class TechnicianEx : StaffLogicAbstract
    {
        private decimal saftyChecks = 0;
        private decimal repairs = 0;
        private decimal GrossIncome = 0;

        public TechnicianEx(decimal saftyChecks, decimal repairs)
        {
            saftyChecks = saftyChecks;
            repairs = repairs;
        }
        public override decimal CalculateIncome()
        {
            decimal duetyFees = saftyChecks * 50;
            decimal reapairsFees = repairs * 100;
            GrossIncome = base.CalculateIncome() + duetyFees + reapairsFees;
            return GrossIncome;
        }

        public override decimal ShareToHospital()
        {
            return GrossIncome * Convert.ToDecimal(0.05);
        }
    }
}
