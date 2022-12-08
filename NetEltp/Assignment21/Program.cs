using Assignment21.Logic;
Console.WriteLine("Assignment 21");

StaffLogic logic = new DoctorLogic();
StaffLogic nurLogic = new NurseLogic();
StaffLogic techLogic = new TechnicianLogic();
Doctor d1 = new Doctor()
{
    StaffId = 1,StaffName = "Sunil",Education = "M.B.B.S",
    Department = "Doctor",Location="Pune",Specilization = "General Physician"
};
logic.RegisterStaff(d1);




Doctor d2 = new Doctor()
{
    StaffId = 2,StaffName = "Ramesh",
    Department = "Doctor",
    Education = "B.H.M.S.",Location="Pune",Specilization = "Heart"
};
logic.RegisterStaff(d2);


Doctor d3 = new Doctor()
{
    StaffId = 3, StaffName = "Pawan",Education = "B.H.M.S.",
    Department = "Doctor",
    Location = "Delhi",Specilization = "Heart"
};
logic.RegisterStaff(d3);


logic = new NurseLogic();
Nurse n1 = new Nurse()
{
     StaffId = 4,StaffName= "Somu",
    Department = "Nurse",
    Location = "Mumbai",Experience = 10
};


Nurse n2 = new Nurse()
{
    StaffId = 5,StaffName = "Barath",
    Department = "Nurse",
    Location = "Pune",Experience = 10
};
logic.RegisterStaff(n1);
logic.RegisterStaff(n2);


logic = new TechnicianLogic();
Technician t1 = new Technician()
{
    StaffId = 6,StaffName = "Bravo",
    Department = "Technician",
    Repairs = 5,SaftyChecks = 10
};
logic.RegisterStaff(t1);


Technician t2 = new Technician()
{
    StaffId = 7,    StaffName = "Shyam",Location = "Mumbai",
    Department = "Technician",Repairs = 2,SaftyChecks = 20
};
logic.RegisterStaff(t2);


Technician t3 = new Technician()
{
    StaffId = 8,StaffName = "Pawan",Repairs = 2,Department="Technician",Location = "Pune",SaftyChecks = 20
};
logic.RegisterStaff(t3);
StaffLogicAbstract staff ;
Accounts accounts = new Accounts();


String choice = String.Empty;
do
{
    Console.WriteLine("1. Register New Staff");
    Console.WriteLine("2. Update Staff By Id");
    Console.WriteLine("3. Delete Staff By Id");
    Console.WriteLine("4. Get All Staff Details");
    Console.WriteLine("5. Get staff Salary");
    Console.WriteLine("6. Search Staff Details");
    
    Console.WriteLine("Enter your Choice To Continue");
    int resopse = Convert.ToInt32(Console.ReadLine());
    switch (resopse)
    {
        case 1:
            Console.WriteLine("Enter Staff Department");
            String choice2 = Console.ReadLine();
            Console.WriteLine("Enter staff Id");
            int id = Convert.ToInt32(Console.ReadLine());
            if (choice2 == "doctor" || choice2 == "Doctor")
            {
                logic.RegisterStaff(addDoc(id, choice2));
                Console.WriteLine("Record Inserted Successfully");
            }
            if (choice2 == "nurse" || choice2 == "Nurse")
            {
                logic.RegisterStaff(addNurse(id, choice2));
                Console.WriteLine("Record Inserted Successfully");
            }
            if (choice2 == "technician" || choice2 == "Technician")
            {
                logic.RegisterStaff(addTech(id, choice2));
                Console.WriteLine("Record Inserted Successfully");
            }
            break;

        case 2:
            Console.WriteLine("Enter Staff id");
            int staffId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Staff Department");
            String choice3 = Console.ReadLine();
            if (choice3 == "doctor" || choice3 == "Doctor")
            {
                logic.updateStaff(staffId,addDoc(staffId, choice3));
                Console.WriteLine("Record Inserted Successfully");
            }
            if (choice3 == "nurse" || choice3 == "Nurse")
            {
                nurLogic.updateStaff(staffId,addNurse(staffId, choice3));
                Console.WriteLine("Record Inserted Successfully");
            }
            if (choice3 == "technician" || choice3 == "Technician")
            {
                techLogic.updateStaff(staffId,addTech(staffId, choice3));
                Console.WriteLine("Record Inserted Successfully");
            }
            break;

        case 3:
            Console.WriteLine("Enter Staff Id ");
            int delStaffId = Convert.ToInt32(Console.ReadLine());
                techLogic.DeleteStaffById(delStaffId);
            Console.WriteLine("Record Deleted Successfully");

            break;
        case 4:
            var allStaff = logic.GetStatffs();
            foreach (Staff s in allStaff.Values)
            {
                if (s.Department == "Doctor")
                {
                    var a = (Doctor)s;
                    Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Specilization} {a.Department} {a.Education} {a.Location}");
                }
                if (s.Department == "Nurse")
                {
                    var a = (Nurse)s;
                    Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Experience} {a.Department} {a.Location}");
                }
                if (s.Department == "Technician")
                {
                    var a = (Technician)s;
                    Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Repairs} {a.SaftyChecks} {a.Department} {a.Location}");
                }
            }
            break;
        case 5:
            Console.WriteLine("Enter Staff Id");
            int ids = Convert.ToInt32(Console.ReadLine());
            var find = logic.GetStaffById(ids);
            String DtpName = find.Department;
            if (DtpName == "doctor" || DtpName == "Doctor")
            {
                Console.WriteLine("Enter Number Of Patients Diagonsed");
                int patientCount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Number Of Operations Done");
                int OpCount = Convert.ToInt32(Console.ReadLine());
                staff = new DoctorLogicEx(patientCount, OpCount);
                Console.WriteLine($"{find.StaffName}  {find.Department}");
                Console.WriteLine($"Gross Income of Doctor = {accounts.GetGrossIncome(staff)}");
                Console.WriteLine($"Net Income for Doctor= {accounts.GetStaffIncome(staff)}");
                Console.WriteLine($"Tax Of Doctor Income = {accounts.GetTaxIncome(staff)}");
                Console.WriteLine($"Share to Hospital = {staff.ShareToHospital()}");
            }
            if (DtpName == "nurse" || DtpName == "Nurse")
            {
                Console.WriteLine("Enter Number Of Injections Applied");
                int injectionCount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Number Of Patients Monitored");
                int monitCount = Convert.ToInt32(Console.ReadLine());
                staff = new NurseLogicEx(injectionCount, monitCount);
                Console.WriteLine($"Gross Income Of Nurse = {accounts.GetGrossIncome(staff)}");
                Console.WriteLine($"Net Income for Nurse = {accounts.GetStaffIncome(staff)}");
                Console.WriteLine($"Tax of Nurse Income = {accounts.GetTaxIncome(staff)}");
                Console.WriteLine($"Share to Hospital = {staff.ShareToHospital()}");
            }
            if (DtpName == "technician" || DtpName == "Technician")
            {
                Console.WriteLine("Enter Number Of SaftyChecks Done");
                int saftyChecks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Number Of Repairs");
                int repairCount = Convert.ToInt32(Console.ReadLine());
                staff = new TechnicianEx(saftyChecks, repairCount);
                Console.WriteLine($"Gross Income Of Technician = {accounts.GetGrossIncome(staff)}");
                Console.WriteLine($"Net Income for Technician = {accounts.GetStaffIncome(staff)}");
                Console.WriteLine($"Tax of Technician Income = {accounts.GetTaxIncome(staff)}");
                Console.WriteLine($"Share to Hospital = {staff.ShareToHospital()}");
            }
            break;

        case 6:
              Console.WriteLine("1. Search By Name");
              Console.WriteLine("2. Search By Department");
              Console.WriteLine("3. Search By Location");
              Console.WriteLine("4. Search By Name & Department & Location");
              Console.WriteLine("5. Search By Name Or Department Or Location");
              Console.WriteLine("Enter Your Choice");

              int ch=Convert.ToInt32(Console.ReadLine());
              SearchLogic searchLogic = new SearchLogic();
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter Staff Name");
                    String name = Console.ReadLine();
                    var search = searchLogic.SearchByName(name);
                    foreach (var s2 in search)
                    {
                        if (s2.Department == "Doctor")
                        {
                            var a = (Doctor)s2;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Specilization} {a.Department} {a.Education} {a.Location}");
                        }
                        if (s2.Department == "Nurse")
                        {
                            var a = (Nurse)s2;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Experience} {a.Department} {a.Location}");
                        }
                        if (s2.Department == "Technician")
                        {
                            var a = (Technician)s2;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Repairs} {a.SaftyChecks} {a.Department} {a.Location}");
                        }
                    }
                    break;

                case 2:
                     Console.WriteLine("Enter Department Of Staff");
                     String deptname1 = Console.ReadLine();

                     var staffs1 = searchLogic.SearchByDpt(deptname1);
                     foreach (var s in staffs1)
                     {
                         if (s.Department == "Doctor")
                         {
                             var a = (Doctor)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Specilization} {a.Department} {a.Education} {a.Location}");
                         }
                         if (s.Department == "Nurse")
                         {
                             var a = (Nurse)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Experience} {a.Department} {a.Location}");
                         }
                         if (s.Department == "Technician")
                         {
                             var a = (Technician)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Repairs} {a.SaftyChecks} {a.Department} {a.Location}");
                         }
                     }
                     break;
                 case 3:
                     Console.WriteLine("Enter Location Of Staff");
                     String location = Console.ReadLine();

                     var staffs2 = searchLogic.SearchByLoc(location);
                     foreach (var s in staffs2)
                     {
                         if (s.Department == "Doctor")
                         {
                             var a = (Doctor)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Specilization} {a.Department} {a.Education} {a.Location}");
                         }
                         if (s.Department == "Nurse")
                         {
                             var a = (Nurse)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Experience} {a.Department} {a.Location}");
                         }
                         if (s.Department == "Technician")
                         {
                             var a = (Technician)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Repairs} {a.SaftyChecks} {a.Department} {a.Location}");
                         }
                     }
                     break;
                case 4:
                     Console.WriteLine("Enter Department");
                     String dpt = Console.ReadLine();
                     Console.WriteLine("Enter Staff Name");
                     String nam= Console.ReadLine();
                     Console.WriteLine("Enter Location Of Staff");
                     String loc = Console.ReadLine();
                     var staffs3 = searchLogic.SearchByAnd(nam,dpt,loc);
                     foreach (var s in staffs3)
                     {
                         if (s.Department == "Doctor")
                         {
                             var a = (Doctor)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Specilization} {a.Department} {a.Education} {a.Location}");
                         }
                        else if (s.Department == "Nurse")
                         {
                             var a = (Nurse)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Experience} {a.Department} {a.Location}");
                         }
                        else if (s.Department == "Technician")
                         {
                             var a = (Technician)s;
                             Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Repairs} {a.SaftyChecks} {a.Department} {a.Location}");
                         }
                         else
                         {
                             Console.WriteLine("No Staff Details Found");
                         }
                     }                    
                     break; 
               case 5:
                    Console.WriteLine("Enter Department");
                    String dpt1 = Console.ReadLine();
                    Console.WriteLine("Enter Staff Name");
                    String nam2 = Console.ReadLine();
                    Console.WriteLine("Enter Location Of Staff");
                    String loc2 = Console.ReadLine();
                    var staffs4 = searchLogic.SearchByOr(nam2, dpt1, loc2);
                    foreach (var s in staffs4)
                    {
                        if (s.Department == "Doctor")
                        {
                            var a = (Doctor)s;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Specilization} {a.Department} {a.Education} {a.Location}");
                        }
                        else if (s.Department == "Nurse")
                        {
                            var a = (Nurse)s;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Experience} {a.Department} {a.Location}");
                        }
                        else if (s.Department == "Technician")
                        {
                            var a = (Technician)s;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.Repairs} {a.SaftyChecks} {a.Department} {a.Location}");
                        }
                        else
                        {
                            Console.WriteLine("No Staff Details Found");
                        }
                    }
                    break; 
            }
            break;
    
}
    Console.WriteLine();
    Console.WriteLine("Enter Y to Continue N to Stop");
    choice = Console.ReadLine();
} while (choice == "Y" || choice == "y");


static Doctor addDoc(int staffid,String dpt)
{
    Console.WriteLine("Enter Doctor Details");
    Doctor doc = new Doctor();
    //Console.WriteLine("StaffId");
    doc.StaffId = staffid; //Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff Name");
    doc.StaffName = Console.ReadLine();
    Console.WriteLine("Enter Staff Education");
    doc.Education = Console.ReadLine();
    Console.WriteLine("Enter Staff Specilization");
    doc.Specilization = Console.ReadLine();
    Console.WriteLine("Enter Location");
    doc.Location = Console.ReadLine();
    doc.Department = dpt;
    return doc;
}


static Nurse addNurse(int staffid,String dpt)
{
    Console.WriteLine("Enter Doctor Details");
    Nurse n = new Nurse();
    //Console.WriteLine("StaffId");
    n.StaffId = staffid; //Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Nurse Name");
    n.StaffName = Console.ReadLine();
    Console.WriteLine("Enter Nurse Experience");
    n.Experience = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Location");
    n.Location = Console.ReadLine();
    n.Department = dpt;
    return n;
}


static Technician addTech(int staffid,String dpt)
{
    Console.WriteLine("Enter Technician Details");
    Technician t = new Technician();
    //Console.WriteLine("StaffId");
    t.StaffId = staffid; //Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff Name");
    t.StaffName = Console.ReadLine();
    Console.WriteLine("Enter Safty Checks");
    t.SaftyChecks= Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff ShiftStartTime");
    t.Repairs =Convert.ToInt32( Console.ReadLine());
    Console.WriteLine("Enter Location");
    t.Location = Console.ReadLine();
    t.Department = dpt;
    return t;
}
Console.ReadLine();