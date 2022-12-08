using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass20.Models
{
    public class Doctor : Staff
    {
        public string? Specialization { get; set; }
        public int Fees { get; set; }
        public int MaxPatientsPerDay { get; set; }

        public int operationsPerDay { get;set;}
        public int patientsDiagonsed { get; set; } 

        public DateTime DOB 
        {
            get { return DOB; }
            set {
                DOB = value; }
                /*DateTime s = DOB;
                if (DateOfBirthDate(s)==false)
                {
                    Console.WriteLine("Invalid Date of Birth");
                }
                while (!DateOfBirthDate(s))
                {
                    Console.WriteLine("Enter a valid Id");
                    s = DateTime.Parse(Console.ReadLine());
                }
                DOB = s*/
        }


/*public static bool DateOfBirthDate(DateTime dtDOB) //assumes a valid date
{
    int age = GetAge(dtDOB);
    if (age < 0 || age > 150) { return false; }
    return true;
}

public static int GetAge(DateTime birthDate)
{
    DateTime today = DateTime.Now;
    int age = today.Year - birthDate.Year;
    if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day)) { age--; }
    return age;
}*/


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
