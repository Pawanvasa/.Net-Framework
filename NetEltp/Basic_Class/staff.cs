using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Class
{
   public class Staff
    {
        private int _StaffId;
        public int StaffId
        {
            get { return _StaffId; }
            set
            {
                int temp = value;
                if (value < 0) 
                {
                    Console.WriteLine("Invalid id");
                }
                while (temp < 0)
                {
                    Console.WriteLine("Enter a valid Id");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                _StaffId = temp;
            }
        }
        private string _StaffName=String.Empty;
        String ?strtemp ;
        public string StaffName
        {
            get { return _StaffName; }
            set { 
                strtemp = value;
                if(staffNameValid(strtemp))
                _StaffName = strtemp;
                while(staffNameValid(strtemp)==false)
                { 
                    Console.WriteLine("Enter A valide Name");
                    strtemp = Console.ReadLine();
                }
                _StaffName = strtemp;
            }
        }

        //To validate staff name
        static Boolean staffNameValid(String staffname) 
        {
            int count = 0;
            for (int i = 0; i < staffname.Length; i++) {
                if (Char.IsLetter(staffname[i]) || Char.IsDigit(staffname[i]))
                {
                    count++;
                }
            }
            if (count == staffname.Length)
                return true;
            else
                return false;
        }

        private string _Email=String.Empty;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }


        private string _DeptName=String.Empty;
        String ?dpttemp;
        public string DeptName
        {
           
            get { return _DeptName; }
            set
            {
                dpttemp = value;
                if (deptCheck(dpttemp))
                    _DeptName = dpttemp;
                while (deptCheck(dpttemp) == false)
                {
                    Console.WriteLine("Enter A valide Department Name");
                        dpttemp = Console.ReadLine();
                }
                _DeptName = dpttemp;
            
            }
        }

        //Department Check
        static Boolean deptCheck(String str)
        {
            String[] check = { "Cancer","cancer", "Heart","heart", "Pathology","pathology", "Radiology","radiology", "Bloob Bank","blood bank", "Organs","organs", "Orthopeic","orthopeic", "Eye","eye", "Dental","dental"};
            Boolean bol = false;
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] == str)
                {
                    bol = true;
                    break;
                }
            }
            return bol;
        }


        private string _Gender = String.Empty;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                _Gender = value;
            }
        }


        private DateOnly _DateOfBirth;
        public DateOnly DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                _DateOfBirth = value;
            }
        }


        private string _StaffCategory = String.Empty;
        String categoryCheck;
        public string StaffCategory
        {
            get { return _StaffCategory; }
            set {
                categoryCheck = value;
                if (staffCatCheck(categoryCheck))
                    _StaffCategory = categoryCheck;
                while (staffCatCheck(categoryCheck) == false)
                {
                    Console.WriteLine("Enter A valide Staff Category Name");
                    categoryCheck = Console.ReadLine();
                }
                _StaffCategory = categoryCheck; 
            }
        }

        //Staff Category check
        static Boolean staffCatCheck(String str)
        {
            String[] checkCat = { "Doctor","doctor", "Nurse","nurse", "Wardnboy", "wardnboy", "Brother", "brother", "Technician", "Technician" };
            Boolean bolcheck = false;
            for (int i = 0; i < checkCat.Length; i++)
            {
                if (checkCat[i] == str)
                {
                    bolcheck = true;
                    break;
                }
            }
            return bolcheck;
        }

        private string _Education = String.Empty;
        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
        }
        private int _ContactNo;
        public int ContatNo
        {
            get { return _ContactNo; }
            set
            {
                _ContactNo = value;
            }
        }
    }
}
