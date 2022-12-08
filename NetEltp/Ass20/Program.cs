using Ass20.Models;
using Ass20.Logic;
using Assignment20.Logic;
Console.WriteLine("Assignment 20");

DoctorLogic logic = new DoctorLogic();
NurseLogic nurse = new NurseLogic();
TechnicianLogic technician = new TechnicianLogic();
Accounts acc = new Accounts();


var doc= new Doctor()
{
    StaffId = 1,StaffName = "Dr.Ramesh",Email = "Ramesh@villian.com",ContactNo = 9234799,Education = "MBBS",ShiftStartTime = 9,
    ShiftEndTime = 20,Specialization = "Heart",Fees = 1000,MaxPatientsPerDay = 100,operationsPerDay=5,patientsDiagonsed=10
};
var doc1 = new Doctor()
{
    StaffId = 2,StaffName = "Sandya",Email = "drno@villian.com",ContactNo = 999999,Education = "MBBS",ShiftStartTime = 10,
    ShiftEndTime = 19,Specialization = "Heart",Fees = 3456,MaxPatientsPerDay = 50,operationsPerDay = 10,patientsDiagonsed = 15
};
doc.SetBasicPay(50000);
logic.RegisterNewDoctor(1, doc);
doc1.SetBasicPay(45000);
logic.RegisterNewDoctor(2,doc1);
var doc2 = new Doctor()
{
    StaffId = 7,
    StaffName = "Samrat",
    Email = "Samrat@gmail.com",
    ContactNo = 5757,
    Education = "MBBS",
    ShiftStartTime = 8,
    ShiftEndTime = 16,
    Specialization = "Eye",
    Fees = 30,
    MaxPatientsPerDay = 30,
    operationsPerDay = 10,
    patientsDiagonsed = 10
};
doc2.SetBasicPay(40000);
logic.RegisterNewDoctor(7, doc2);

var nur = new Nurse()
{
    StaffId = 3,
    StaffName = "Ramya",
    Email = "Lasya@villian.com",
    ContactNo = 923569,
    Education = "Mentel Health",
    ShiftStartTime = 9,
    ShiftEndTime = 20,
    nurseSpecilization = "bpharmacy",
    visitingroom = 10,
    servicetype = "Full Day",
    PatientsMonitored=20,
    InjectionApplied=50,
    GrossIncome=25000
};
var nur1 = new Nurse()
{
    StaffId = 4,
    StaffName = "Jasmine",
    Email = "Jasmine@Google.com",
    ContactNo = 933569,
    Education = "Genetics",
    ShiftStartTime = 10,
    ShiftEndTime = 18,
    nurseSpecilization = "DNA",
    visitingroom = 5,
    servicetype = "Full Day",
    PatientsMonitored = 30,
    InjectionApplied = 90,
    GrossIncome = 25000
};
nurse.RegisterNewNurse(3, nur);
nurse.RegisterNewNurse(4, nur1);

var tech = new Technician()
{
    StaffId = 5,
    StaffName = "Sunil",
    Email = "Sunil@outlook.com",
    ContactNo = 735235,
    Education = "ITI",
    ShiftStartTime = 8,
    ShiftEndTime = 20,
    saftyChecks= 5,
    repairs = 2,
    BasicPay=20000
};

var tech1 = new Technician()
{
    StaffId = 6,
    StaffName = "BravoAuto",
    Email = "Bravo@auto.com",
    ContactNo = 83468,
    Education = "IIT",
    ShiftStartTime = 11,
    ShiftEndTime = 18,
    saftyChecks = 10,
    repairs = 4,
    BasicPay=15000
};
technician.RegisterNewTechnician(5, tech); 
technician.RegisterNewTechnician(6, tech1);

String choice=String.Empty;
do
{
    Console.WriteLine("1. To Perform Operations on Doctor");
    Console.WriteLine("2. To Perform Operations on Nurse");
    Console.WriteLine("3. To Perform Operations on Technisian");
    Console.WriteLine("4. To Search Doctor By Specilization");
    Console.WriteLine("5. To Get Staff Details By Name");
    Console.WriteLine("6. To Get The Income Of Staff by Id");
    Console.WriteLine("7. To Get All the Details of Staff");
    Console.WriteLine("Enter your Choice To Continue");

    int resopse=Convert.ToInt32(Console.ReadLine());
    switch (resopse)
    {
        case 1:
            doctorOperation();
            Console.WriteLine();
            break;


        case 2:
            nurseExecution();
            Console.WriteLine();
            break;

        case 3:
            techExecution();
            Console.WriteLine( );
            break;

        case 4:
            Console.WriteLine("Enter Doctor Specialization");
            String spec = Console.ReadLine();
            var it = logic.getBySpecialization(spec);
                if (it == null)
                {
                    Console.WriteLine("No Records Found");
                }
            break;
       
        case 5:
            Console.WriteLine("Enter Staff Name");
            String nam = Console.ReadLine();
            var staffSreachDoc=logic.getByStaffName(nam);
            var staffSearchTech=technician.getTechnicianByName(nam);
            var staffSearchNurse = nurse.getNurseByName(nam);
            if (staffSreachDoc != null)
                Console.WriteLine($"{staffSreachDoc.StaffId} {staffSreachDoc.StaffName} {staffSreachDoc.Email} {staffSreachDoc.ContactNo} {staffSreachDoc.Education} {staffSreachDoc.ShiftStartTime} {staffSreachDoc.ShiftEndTime} {staffSreachDoc.Specialization} {staffSreachDoc.Fees} {staffSreachDoc.MaxPatientsPerDay}");
            
            if(staffSearchTech != null)
                Console.WriteLine($"{staffSearchTech.StaffId} {staffSearchTech.StaffName} {staffSearchTech.Email} {staffSearchTech.ContactNo} {staffSearchTech.Education} {staffSearchTech.ShiftStartTime} {staffSearchTech.ShiftEndTime} {staffSearchTech.saftyChecks} {staffSearchTech.repairs} ");
            
            if(staffSearchNurse!=null)
                Console.WriteLine($"{staffSearchNurse.StaffId} {staffSearchNurse.StaffName} {staffSearchNurse.Email} {staffSearchNurse.ContactNo} {staffSearchNurse.Education} {staffSearchNurse.ShiftStartTime} {staffSearchNurse.ShiftEndTime} {staffSearchNurse.servicetype} {staffSearchNurse.visitingroom} ");

            if(staffSreachDoc==null && staffSearchTech==null && staffSearchNurse==null)
                Console.WriteLine("Staff Details Not Found");
            break;

        case 6:
            Console.WriteLine("Enter Staff Id");
            int id = Convert.ToInt32(Console.ReadLine());
            var docSearch=logic.getByStaffId(id);
            var nursSearch = nurse.getNurseId(id);
            var techSearch = technician.getTechnicianById(id);
            if( docSearch != null )
            {
                int patient = docSearch.PatientsDiagonsed;
                int operations = docSearch.OperationsPerDay;
                acc.docSet(patient, operations);
                Decimal income= acc.docIncomeCal(docSearch.BasicPay);
                int starttime = docSearch.ShiftStartTime;
                int endTime=docSearch.ShiftEndTime;
                if (endTime - starttime > 10)
                {
                    Decimal timeAlloence = income + 1000;
                    Console.WriteLine($"Income of {docSearch.StaffName} is = {timeAlloence}");
                }
                else
                Console.WriteLine($"Income of {docSearch.StaffName} is = {income}");

            }
            if(nursSearch != null)
            {
                Decimal patients= nursSearch.PatientsMonitored;
                Decimal numOfInjections = nursSearch.InjectionApplied;
                acc.setNurse(patients, numOfInjections);
                Decimal income = acc.nurseIncomeCal(nursSearch.BasicPay);
                int starttime = docSearch.ShiftStartTime;
                int endTime = docSearch.ShiftEndTime;
                if (endTime - starttime > 10)
                {
                    Decimal timeAlloence = income + 1000;
                    Console.WriteLine($"Income of {nursSearch.StaffName} is = {timeAlloence}");
                }
                else
                    Console.WriteLine($"Income of {nursSearch.StaffName} is = {income}");
            }
            if(techSearch != null)
            {
                int checks = techSearch.saftyChecks;
                int numofRepairs = techSearch.repairs;
                acc.setTeachnician(checks, numofRepairs);
                Decimal income = acc.techIncomeCal(techSearch.BasicPay);
                int starttime = docSearch.ShiftStartTime;
                int endTime = docSearch.ShiftEndTime;
                if (endTime - starttime > 10)
                {
                    Decimal timeAlloence = income + 1000;
                    Console.WriteLine($"Income of {techSearch.StaffName} is = {timeAlloence}");
                }
                else
                    Console.WriteLine($"Income of {techSearch.StaffName} is = {income}");
            }
            if(docSearch == null &&techSearch == null&&nursSearch == null)
            {
                Console.WriteLine("Staff Id Not Found");
            }

            break;

        case 7:
            var allDoctors = logic.GetAllDoctors();
            foreach (var s in allDoctors.Values)
            {
                Console.WriteLine("______________________________________________________________________________");
                Console.WriteLine($"Staff Id = {s.StaffId} \n Staff Name = {s.StaffName} \n Email = {s.Email} \n ContactNumber = {s.ContactNo} \n Education = {s.Education} \n Shift Start Time = {s.ShiftStartTime} \n shift End Time = {s.ShiftEndTime} \n Specialization = {s.Specialization} \n Fees = {s.Fees} \n Max Patients = {s.MaxPatientsPerDay} \n Basic Pay = {s.GetBasicPay()}");

            }
            var allNurse = nurse.GetAllNurse();
            foreach (var s in allNurse.Values)
            {
                Console.WriteLine("______________________________________________________________________________");
                Console.WriteLine($" StaffId = {s.StaffId} \n StaffName = {s.StaffName} \n Staff Eamil = {s.Email} \n Contact = {s.ContactNo} \n Education = {s.Education} \n Shift Start Time = {s.ShiftStartTime} \n Nurse Specalization = {s.nurseSpecilization} \n VisitingRoom = {s.visitingroom} \n ServiceType = {s.servicetype} \n Basic pay = {s.GetBasicPay()}");

            }
            var alltech = technician.GetAllTechnician();
            foreach (var s in alltech.Values)
            {
                // Console.WriteLine(allDoctors.Keys);
                Console.WriteLine("______________________________________________________________________________");
                Console.WriteLine($" StaffId = {s.StaffId} \n StaffName = {s.StaffName} \n Staff Eamil = {s.Email} \n Contact = {s.ContactNo} \n Education = {s.Education} \n Shift Start Time = {s.ShiftStartTime} \n Shift End Time = {s.ShiftEndTime} \n Stafty Checks = {s.saftyChecks} \n Repairs = {s.repairs} \n Basic Salry = {s.GetBasicPay()} ");

            }
            break;
    }


 
    void doctorOperation()
    {
        String choice = String.Empty;
        do
        {
            Console.WriteLine("1. Register New Doctor");
            Console.WriteLine("2. Get All Doctor Details");
            Console.WriteLine("3. Update Staff Details By Id");
            Console.WriteLine("4. Delete Staff Details By Id");
            Console.WriteLine("5. Get Staff Details By Id");
            Console.WriteLine("Enter your Choice To Continue");

            int resopse = Convert.ToInt32(Console.ReadLine());
            switch (resopse)
            {
                case 1:
                    Console.WriteLine("Enter Staff Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var staffSreachDoc = logic.getByStaffId(id);
                    var staffSearchTech = technician.getTechnicianById(id);
                    var staffSearchNurse = nurse.getNurseId(id);

                    if (staffSreachDoc == null && staffSearchTech==null && staffSearchNurse==null)
                    {
                        logic.RegisterNewDoctor(id, addDoctor(id));
                        Console.WriteLine("Record Inserted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Staff Id Already Exists");
                    }
                    break;
                case 2:
                    var allDoctors = logic.GetAllDoctors();
                    foreach (var s in allDoctors.Values)
                    {
                        // Console.WriteLine(allDoctors.Keys);
                        Console.WriteLine($"{s.StaffId} {s.StaffName} {s.Email} {s.ContactNo} {s.Education} {s.ShiftStartTime} {s.ShiftEndTime} {s.Specialization} {s.Fees} {s.MaxPatientsPerDay} {s.GetBasicPay()}");

                    }
                    break;
                case 3:
                    Console.WriteLine("Enter Staff Id You Want to update");
                    int staffid = Convert.ToInt32(Console.ReadLine());
                    logic.updateStaffById(staffid, addDoctor(staffid));
                    Console.WriteLine("Staff Details Updated Successfully");
                    break;
                case 4:
                    Console.WriteLine("Enter Staff Id ");
                    int delStaffId = Convert.ToInt32(Console.ReadLine());
                    if (logic.getByStaffId(delStaffId) != null)
                    {
                        logic.DeleteStaffById(delStaffId);
                        Console.WriteLine("Record Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Record Not Found");
                    }

                    break;
                case 5:
                    Console.WriteLine("Enter Staff Id");
                    int getId = Convert.ToInt32(Console.ReadLine());
                    var doc2 = logic.getByStaffId(getId);
                    if (doc2 != null)
                        Console.WriteLine($"{doc2.StaffId} {doc2.StaffName} {doc2.Email} {doc2.ContactNo} {doc2.Education} {doc2.ShiftStartTime} {doc2.ShiftEndTime} {doc2.Specialization} {doc2.Fees} {doc2.MaxPatientsPerDay}");
                    else
                        Console.WriteLine("Staff Id is Not Found");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Enter Y to Continue N to Stop");
            choice = Console.ReadLine();
        } while (choice == "Y" || choice == "y");
    }
    static Doctor addDoctor(int staffid)
    {
        Console.WriteLine("Enter Doctor Details");
        Doctor doc = new Doctor();
        //Console.WriteLine("StaffId");
        doc.StaffId = staffid; //Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Staff Name");
        doc.StaffName = Console.ReadLine();
        Console.WriteLine("Enter Staff Email");
        doc.Email = Console.ReadLine();
        Console.WriteLine("Enter Staff ContactNo");
        doc.ContactNo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Staff Education");
        doc.Education = Console.ReadLine();
        Console.WriteLine("Enter Staff ShiftStartTime");
        doc.ShiftStartTime = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Staff ShiftEndTime");
        doc.ShiftEndTime = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Date of Birth");
       // doc.DOB = DateTime.Parse(Console.ReadLine());
        //Console.WriteLine("Enter Staff Specialization");
        doc.Specialization = Console.ReadLine();
        Console.WriteLine("Enter Staff Fess");
        doc.Fees = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Staff Max Patients per Day");
        doc.MaxPatientsPerDay = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Basic Pay Of Doctor");
        doc.SetBasicPay(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Enter Operations Per Day");
        doc.operationsPerDay = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Patients Diagonsed ");
        doc.patientsDiagonsed = Convert.ToInt32(Console.ReadLine());
        return doc;
    }
    Console.WriteLine();
    Console.WriteLine("Enter Y to Continue N to Stop");
    choice = Console.ReadLine();
} while (choice=="Y" ||choice =="y");


void nurseExecution()
{
    String choice = String.Empty;
    do
    {
        Console.WriteLine("1. Register New Nurse");
        Console.WriteLine("2. Get All Nurse Details");
        Console.WriteLine("3. Update Nurse Details By Id");
        Console.WriteLine("4. Delete Nurse Details By Id");
        Console.WriteLine("5. Get Nurse Details By Id");
        Console.WriteLine("Enter your Choice To Continue");

        int resopse = Convert.ToInt32(Console.ReadLine());
        switch (resopse)
        {
            case 1:
                Console.WriteLine("Enter Nurse Id");
                int id = Convert.ToInt32(Console.ReadLine());
                var check = nurse.getNurseId(id);
                if (check == null)
                {
                    nurse. RegisterNewNurse(id, addNurse(id));
                    Console.WriteLine("Record Inserted Successfully");
                }
                else
                {
                    Console.WriteLine("Nurse Id Already Registerd");
                }
                break;
            case 2:
                var allNurse = nurse.GetAllNurse();
                foreach (var s in allNurse.Values)
                { 
                    Console.WriteLine($"{s.StaffId} {s.StaffName} {s.Email} {s.ContactNo} {s.Education} {s.ShiftStartTime} {s.ShiftEndTime} {s.nurseSpecilization} {s.visitingroom} {s.servicetype} {s.GetBasicPay()}");

                }
                break;
            case 3:
                Console.WriteLine("Enter Nurse Id You Want to update");
                int staffid = Convert.ToInt32(Console.ReadLine());
                nurse.updateNurseById(staffid, addNurse(staffid));
                Console.WriteLine("Nurse Details Updated Successfully");
                break;
            case 4:
                Console.WriteLine("Enter Staff Id ");
                int delStaffId = Convert.ToInt32(Console.ReadLine());
                if (nurse.getNurseId(delStaffId) != null)
                {
                    nurse.DeleteNurseById(delStaffId);
                    Console.WriteLine("Record Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Record Not Found");
                }

                break;
            case 5:
                Console.WriteLine("Enter Staff Id");
                int getId = Convert.ToInt32(Console.ReadLine());
                var nur2 = nurse.getNurseId(getId);
                if (nur2 != null)
                    Console.WriteLine($"{nur2.StaffId} {nur2.StaffName} {nur2.Email} {nur2.ContactNo} {nur2.Education} {nur2.ShiftStartTime} {nur2.ShiftEndTime} {nur2.nurseSpecilization} {nur2.visitingroom} {nur2.servicetype} {nur2.GetBasicPay()}");
                else
                    Console.WriteLine("Nurse Id is Not Found");
                break;
        }
        Console.WriteLine();
        Console.WriteLine("Enter Y to Continue N to Stop");
        choice = Console.ReadLine();
    } while (choice == "Y" || choice == "y");
}

static Nurse addNurse(int staffid)
{
    Console.WriteLine("Enter Nurse Details");
    Nurse nur = new Nurse();
    nur.StaffId = staffid;
    Console.WriteLine("Enter Staff Name");
    nur.StaffName = Console.ReadLine();
    Console.WriteLine("Enter Staff Email");
    nur.Email = Console.ReadLine();
    Console.WriteLine("Enter Staff ContactNo");
    nur.ContactNo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff Education");
    nur.Education = Console.ReadLine();
    Console.WriteLine("Enter Staff ShiftStartTime");
    nur.ShiftStartTime = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff ShiftEndTime");
    nur.ShiftEndTime = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff Specialization");
    nur.nurseSpecilization = Console.ReadLine();
    Console.WriteLine("Enter Number of Rooms Visited");
    nur.visitingroom = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Service type");
    nur.servicetype = (Console.ReadLine());
    Console.WriteLine("Enter Basic Pay Of Nurse");
    nur.SetBasicPay(Convert.ToInt32(Console.ReadLine()));
    Console.WriteLine("Enter Number of PatientsMonitored ");
    nur.PatientsMonitored = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Number of InjectionApplied");
    nur.InjectionApplied = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Number of GrossIncome");
    nur.GrossIncome = Convert.ToInt32(Console.ReadLine());
    return nur;
}


void techExecution()
{
    String choice = String.Empty;
    do
    {
        Console.WriteLine("1. Register New Technician");
        Console.WriteLine("2. Get All Technician Details");
        Console.WriteLine("3. Update Technician Details By Id");
        Console.WriteLine("4. Delete Technician Details By Id");
        Console.WriteLine("5. Get Technician Details By Id");
        Console.WriteLine("Enter your Choice To Continue");

        int resopse = Convert.ToInt32(Console.ReadLine());
        switch (resopse)
        {
            case 1:
                Console.WriteLine("Enter Technician Id");
                int id = Convert.ToInt32(Console.ReadLine());
                var check = technician.getTechnicianById(id);
                if (check == null)
                {
                    technician.RegisterNewTechnician(id, addTechnician(id));
                    Console.WriteLine("Record Inserted Successfully");
                }
                else
                {
                    Console.WriteLine("Technician Id Already Registerd");
                }
                break;
            case 2:
                var allTech = technician.GetAllTechnician();
                foreach (var s in allTech.Values)
                {
                    // Console.WriteLine(allDoctors.Keys);
                    Console.WriteLine($"{s.StaffId} {s.StaffName} {s.Email} {s.ContactNo} {s.Education} {s.ShiftStartTime} {s.ShiftEndTime} {s.saftyChecks} {s.repairs} {s.GetBasicPay()} ");

                }
                break;
            case 3:
                Console.WriteLine("Enter Technician Id You Want to update");
                int staffid = Convert.ToInt32(Console.ReadLine());
                technician.updateTechById(staffid, addTechnician(staffid));
                Console.WriteLine("Technician Details Updated Successfully");
                break;
            case 4:
                Console.WriteLine("Enter Technician Id ");
                int delStaffId = Convert.ToInt32(Console.ReadLine());
                if (technician.getTechnicianById(delStaffId) != null)
                {
                    technician.DeleteTechnisianById(delStaffId);
                    Console.WriteLine("Record Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Record Not Found");
                }

                break;
            case 5:
                Console.WriteLine("Enter Technician Id");
                int getId = Convert.ToInt32(Console.ReadLine());
                var nur2 = technician.getTechnicianById(getId);
                if (nur2 != null)
                    Console.WriteLine($"{nur2.StaffId} {nur2.StaffName} {nur2.Email} {nur2.ContactNo} {nur2.Education} {nur2.ShiftStartTime} {nur2.ShiftEndTime} {nur2.saftyChecks} {nur2.repairs} {nur2.GetBasicPay()}");
                else
                    Console.WriteLine("Technician Id is Not Found");
                break;
        }
        Console.WriteLine();
        Console.WriteLine("Enter Y to Continue N to Stop");
        choice = Console.ReadLine();
    } while (choice == "Y" || choice == "y");
}

static Technician addTechnician(int staffid)
{
    Console.WriteLine("Enter Nurse Details");
    Technician tech = new Technician();
    tech.StaffId = staffid;
    Console.WriteLine("Enter Staff Name");
    tech.StaffName = Console.ReadLine();
    Console.WriteLine("Enter Staff Email");
    tech.Email = Console.ReadLine();
    Console.WriteLine("Enter Staff ContactNo");
    tech.ContactNo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff Education");
    tech.Education = Console.ReadLine();
    Console.WriteLine("Enter Staff ShiftStartTime");
    tech.ShiftStartTime = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Staff ShiftEndTime");
    tech.ShiftEndTime = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Number of Safty checks Done");
    tech.saftyChecks = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Number Repairs Done");
    tech.repairs = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Basic Pay Of Technician");
    tech.SetBasicPay(Convert.ToInt32(Console.ReadLine()));
    return tech;
}

Console.ReadLine();