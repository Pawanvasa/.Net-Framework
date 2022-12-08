Console.WriteLine("Demo ABstract Class && Interfaces");

StaffLogic logic = new DoctorLogic(29999);

Console.WriteLine($"Doctor Income {logic.GetIncome()}");
// Tax Result from Doctor
var tds = ((ITax)logic).CalculateTax(logic.GetIncome());
Console.WriteLine($"Tax of Doctor = {tds}");
// GST Result for the Doctor
var gst = ((IGstTax)logic).CalculateTax(logic.GetIncome());
Console.WriteLine($"GST Of Doctor = {gst}");


Console.WriteLine("Assignment 21 Interface");
StaffLogicAbstract Logic;
StaffLogic nurLogic = new NurseLogic(30282);

Doctor d1 = new Doctor()
{
    StaffId = 1,
    StaffName = "Sunil",
    Education = "M.B.B.S",
    Department = "Doctor",
    Location = "Pune",
    Specilization = "General Physician"
};
logic.RegisterStaff(d1);


Doctor d2 = new Doctor()
{
    StaffId = 2,
    StaffName = "Ramesh",
    Department = "Doctor",
    Education = "B.H.M.S.",
    Location = "Pune",
    Specilization = "Heart"
};
logic.RegisterStaff(d2);


Doctor d3 = new Doctor()
{
    StaffId = 3,
    StaffName = "Pawan",
    Education = "B.H.M.S.",
    Department = "Doctor",
    Location = "Delhi",
    Specilization = "Heart"
};
logic.RegisterStaff(d3);


logic = new NurseLogic(453342);
Nurse n1 = new Nurse()
{
    StaffId = 4,
    StaffName = "Somu",
    Department = "Nurse",
    Location = "Mumbai",
    Experience = 10
};


Nurse n2 = new Nurse()
{
    StaffId = 5,
    StaffName = "Barath",
    Department = "Nurse",
    Location = "Pune",
    Experience = 10
};
logic.RegisterStaff(n1);
logic.RegisterStaff(n2);


logic = new TechnicianLogic(78343);
Technician t1 = new Technician()
{
    StaffId = 6,
    StaffName = "Bravo",
    Department = "Technician",
    Repairs = 5,
    SaftyChecks = 10
};
logic.RegisterStaff(t1);


Technician t2 = new Technician()
{
    StaffId = 7,
    StaffName = "Shyam",
    Location = "Mumbai",
    Department = "Technician",
    Repairs = 2,
    SaftyChecks = 20
};
logic.RegisterStaff(t2);


Technician t3 = new Technician()
{
    StaffId = 8,
    StaffName = "Pawan",
    Repairs = 2,
    Department = "Technician",
    Location = "Pune",
    SaftyChecks = 20
};
logic.RegisterStaff(t3);
StaffLogicAbstract staff;
Accounts accounts = new Accounts();

String choice = String.Empty;
do
{
    Console.WriteLine("1. Register New Staff");
    Console.WriteLine("2. Get All Staff Details");
    Console.WriteLine("3. Get staff Salary");
    Console.WriteLine("4. Search Staff Details");
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
        case 3:
            Console.WriteLine("Enter Staff category");
            String DtpName = Console.ReadLine();
            if (DtpName == "doctor" || DtpName == "Doctor")
            {
                Console.WriteLine("Enter Number Of Patients Diagonsed");
                int patientCount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Number Of Operations Done");
                int OpCount = Convert.ToInt32(Console.ReadLine());
                Logic = new DoctorLogicEx(patientCount, OpCount);
                Console.WriteLine($"Gross Income of Doctor = {accounts.GetGrossIncome(Logic)}");
                Console.WriteLine($"Net Income for Doctor= {accounts.GetStaffIncome(Logic)}");
                Console.WriteLine($"Tax Of Doctor Income = {((ITax)logic).CalculateTax(logic.GetIncome())}");
                Console.WriteLine($"Share to Hospital = {Logic.ShareToHospital()}");
            }
            if (DtpName == "nurse" || DtpName == "Nurse")
            {
                Console.WriteLine("Enter Number Of Injections Applied");
                int injectionCount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Number Of Patients Monitored");
                int monitCount = Convert.ToInt32(Console.ReadLine());
                Logic = new NurseLogicEx(injectionCount, monitCount);
                Console.WriteLine($"Gross Income Of Nurse = {accounts.GetGrossIncome(Logic)}");
                Console.WriteLine($"Net Income for Nurse = {accounts.GetStaffIncome(Logic)}");
                Console.WriteLine($"Tax of Nurse Income = {accounts.GetTaxIncome(Logic)}");
                Console.WriteLine($"Share to Hospital = {Logic.ShareToHospital()}");
            }
            if (DtpName == "technician" || DtpName == "Technician")
            {
                Console.WriteLine("Enter Number Of SaftyChecks Done");
                int saftyChecks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Number Of Repairs");
                int repairCount = Convert.ToInt32(Console.ReadLine());
                Logic = new TechnicianEx(saftyChecks, repairCount);

                Console.WriteLine($"Gross Income Of Technician = {accounts.GetGrossIncome(Logic)}");
                Console.WriteLine($"Net Income for Technician = {accounts.GetStaffIncome(Logic)}");
                Console.WriteLine($"Tax of Technician Income = {accounts.GetTaxIncome(Logic)}");
                Console.WriteLine($"Share to Hospital = {Logic.ShareToHospital()}");
            }
            break;

        case 4:
            Console.WriteLine("1. Search By Name");
            Console.WriteLine("2. Search By Department");
            Console.WriteLine("3. Search By Location");
            Console.WriteLine("4. Search By Name & Department & Location");
            Console.WriteLine("5. Search By Name Or Department Or Location");
            Console.WriteLine("Enter Your Choice");

            int ch = Convert.ToInt32(Console.ReadLine());
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
                    String nam = Console.ReadLine();
                    Console.WriteLine("Enter Location Of Staff");
                    String loc = Console.ReadLine();
                    var staffs3 = searchLogic.SearchByAnd(nam, dpt, loc);
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


static Doctor addDoc(int staffid, String dpt)
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

static Nurse addNurse(int staffid, String dpt)
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


static Technician addTech(int staffid, String dpt)
{
    Console.WriteLine("Enter Technician Details");
    Technician t = new Technician();
    //Console.WriteLine("StaffId");
    t.StaffId = staffid; //Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff Name");
    t.StaffName = Console.ReadLine();
    Console.WriteLine("Enter Safty Checks");
    t.SaftyChecks = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff ShiftStartTime");
    t.Repairs = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Location");
    t.Location = Console.ReadLine();
    t.Department = dpt;
    return t;
}
Console.ReadLine();