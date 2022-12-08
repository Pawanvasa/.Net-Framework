
using static Assignment26.Models.DoctorLogic;

IDbOperations<Doctor, int> doc = new DoctorLogic();
IDbOperations<Nurse, int> nurse = new NurseLogic();
IDbOperations<Driver, int> driver = new DriverLogic();
DoctorLogic doctorLogic = new DoctorLogic();

Doctor doc1 =new Doctor()
{
    StaffId=1,StaffName="Pawan",Specilization="Heart",Education="MBBS",Department="Doctor",BasicPay=40000,Email="Pawan@gmail.com",ContactNo=387653,ShiftStartTime=8,ShiftEndTime=5,Location="pune"
};
Doctor doc2 = new Doctor()
{
    StaffId = 2,StaffName = "Kumar",Specilization = "Eye",Education = "BMMS",Department="Doctor",BasicPay = 50000,Email = "Lumar@gmail.com",ContactNo = 8468,ShiftStartTime = 9,ShiftEndTime = 16,
    Location = "Mumbai"
};
Doctor doc3 = new Doctor()
{
    StaffId = 3,StaffName = "Abhi Ram",Specilization = "Kidney",Education = "MBBS",Department = "Doctor",BasicPay = 70000,Email = "Lumar@gmail.com",ContactNo = 7865,ShiftStartTime = 6,ShiftEndTime = 4,Location = "pune"
};
doc.Create(1,doc1);
doc.Create(2, doc2);
doc.Create(3, doc3);


Nurse nurse1 = new Nurse()
{
    StaffId = 4,
    StaffName = "Rani",
    Department = "Nurse",
    Experience=1,
    ContactNo=7643,
    BasicPay=15000,
    Location="Pune"
    
};
nurse.Create(4, nurse1);

Nurse nurse2 = new Nurse()
{
    StaffId = 5,
    StaffName = "Jasmin",
    Department = "Nurse",
    ContactNo = 6253,
    Experience=5,
    BasicPay = 14000,
    Location = "Mumbai"
};
nurse.Create(5, nurse2);

Nurse nurse3 = new Nurse()
{
    StaffId = 6,
    StaffName = "Roja",
    Department = "Nurse",
    ContactNo = 36424,
    Experience=9,
    BasicPay = 12000,
    Location = "Mumbai"
};
nurse.Create(6, nurse3);

Driver driv = new Driver()
{
    StaffId = 7,
    StaffName = "Raju",
    Department = "Driver",
    ContactNo = 836,
    BasicPay = 8000,
    VehicleType="Ambulence",
    Location = "Pune"
};
driver.Create(7, driv);

Driver driv2 = new Driver()
{
    StaffId = 8,
    StaffName = "",
    Department = "Driver",
    ContactNo = 836,
    BasicPay = 8000,
    VehicleType = "Staff Vehical",
    Location = "Pune"
};
driver.Create(8, driv2);



String choice = String.Empty;
do
{
    Console.WriteLine("1. To Perform Operations on Doctor");
    Console.WriteLine("2. To Perform Operations on Nurse");
    Console.WriteLine("3. To Perform Operations on Driver");
    Console.WriteLine("4. To Get All the Details of Staff");
    Console.WriteLine("5. Search");
    Console.WriteLine("Enter your Choice To Continue");

    int resopse = Convert.ToInt32(Console.ReadLine());
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
            driverExecution();
            Console.WriteLine();
            break;

        case 4:
            var all = doc.GetAll().Values;
            foreach (var s in all)
            {
                if (s.Department == "Doctor")
                {
                    var a = (Doctor)s;
                    Console.WriteLine($"{s.StaffId} {s.StaffName} {s.Email} {s.ContactNo} {s.Education} {s.ShiftStartTime} {s.ShiftEndTime} {s.Location} {s.Department}");
                }
                if (s.Department == "Nurse")
                {
                    var a = (Nurse)s;
                    Console.WriteLine($"{a.StaffId} {a.StaffName} {a.Experience} {a.Department} {a.BasicPay} {a.Location} {s.Department}");
                }
                if (s.Department == "Driver")
                {
                    var a = (Driver)s;
                    Console.WriteLine($"{a.StaffId} {a.StaffName} {a.Department} {a.VehicleType} {a.Location} {s.Department}");
                }
            }
            break;
        case 5:
            Console.WriteLine("1. Search By Name");
            Console.WriteLine("2. Search By StaffId");
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
                            var a = (Driver)s2;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.ContactNo} {a.Department} {a.Location}");
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter Staff ID");
                    int staffid1 = Convert.ToInt32(Console.ReadLine());

                    var staffs1 = searchLogic.SearchByStaffId(staffid1);
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
                            var a = (Driver)s;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.ContactNo} {a.Department} {a.Location}");
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
                            var a = (Driver)s;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.ContactNo} {a.Department} {a.Location}");
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
                            var a = (Driver)s;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.ContactNo} {a.Department} {a.Location}");
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
                            var a = (Driver)s;
                            Console.WriteLine($"{a.StaffId}  {a.StaffName}  {a.ContactNo} {a.Department} {a.Location}");
                        }
                        else
                        {
                            Console.WriteLine("No Staff Details Found");
                        }
                    }
                    break;
            }
            break;
            break;
    }


    void doctorOperation()
    {
        String choice = String.Empty;
        do
        {
            Console.WriteLine("1. Register New Doctor"); 
            Console.WriteLine("2. Update Staff Details By Id");
            Console.WriteLine("3. Delete Staff Details By Id");
            Console.WriteLine("4. Get Staff Details By Id");
            Console.WriteLine("Enter your Choice To Continue");


            int resopse = Convert.ToInt32(Console.ReadLine());
            switch (resopse)
            {
                case 1:
                    Console.WriteLine("Enter Staff Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Boolean staffSreachDoc = doctorLogic.idSearch(id);
                    if (staffSreachDoc == false)
                    {
                        doc.Create(id, addDoctor(id));
                        Console.WriteLine("Record Inserted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Staff Id Already Exists");
                    }
                    break;
              
                case 2:
                    Console.WriteLine("Enter Staff Id You Want to update");
                    int staffid = Convert.ToInt32(Console.ReadLine());
                    doc.Update(staffid, addDoctor(staffid));
                    Console.WriteLine("Staff Details Updated Successfully");
                    break;
                case 3:
                    Console.WriteLine("Enter Staff Id ");
                    int delStaffId = Convert.ToInt32(Console.ReadLine());
                    if (doctorLogic.idSearch(delStaffId) != false)
                    {
                        doc.Delete(delStaffId);
                    }
                    else
                    {
                        Console.WriteLine("Record Not Found");
                    }

                    break;
                case 4:
                    Console.WriteLine("Enter Staff Id");
                    int getId = Convert.ToInt32(Console.ReadLine());
                    var doc3 = doc.Get(getId);
                    if (doc3 != null)
                        //foreach(var doc2 in doc3.Values)
                        Console.WriteLine($"{doc2.StaffId} {doc2.StaffName} {doc2.Email} {doc2.ContactNo} {doc2.Education} {doc2.ShiftStartTime} {doc2.ShiftEndTime}");
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
        Console.WriteLine("Enter Staff Specialization");
        return doc;
    }
    Console.WriteLine();
    Console.WriteLine("Enter Y to Continue N to Stop");
    choice = Console.ReadLine();
} while (choice == "Y" || choice == "y");


void nurseExecution()
{
    String choice = String.Empty;
    do
    {
        Console.WriteLine("1. Register New Nurse");
        Console.WriteLine("2. Update Nurse Details By Id");
        Console.WriteLine("3. Delete Nurse Details By Id");
        Console.WriteLine("4. Get Nurse Details By Id");
        Console.WriteLine("Enter your Choice To Continue");

        int resopse = Convert.ToInt32(Console.ReadLine());
        switch (resopse)
        {
            case 1:
                Console.WriteLine("Enter Nurse Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Boolean staffSreachDoc = doctorLogic.idSearch(id);
                if (staffSreachDoc == false)
                {
                    nurse.Create(id, addNurse(id));
                    Console.WriteLine("Record Inserted Successfully");
                }
                else
                {
                    Console.WriteLine("Staff Id Already Exists");
                }
                break;
                
           
            case 2:
                Console.WriteLine("Enter Nurse Id You Want to update");
                int staffid = Convert.ToInt32(Console.ReadLine());
                nurse.Update(staffid, addNurse(staffid));
                Console.WriteLine("Nurse Details Updated Successfully");
                break;


            case 3:
                Console.WriteLine("Enter Staff Id ");
                int delStaffId = Convert.ToInt32(Console.ReadLine());
                if (nurse.Get(delStaffId) != null)
                {
                    nurse.Delete(delStaffId);
                    Console.WriteLine("Record Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Record Not Found");
                }
                break;


            case 4:
                Console.WriteLine("Enter Staff Id");
                int getId = Convert.ToInt32(Console.ReadLine());
                var nur2 = nurse.Get(getId);
                if (nur2 != null)
                    //foreach(var nur2 in s.Values)
                    Console.WriteLine($"{nur2.StaffId} {nur2.StaffName} {nur2.Email} {nur2.ContactNo} {nur2.Education} {nur2.ShiftStartTime} {nur2.ShiftEndTime} ");
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

    return nur;
}


void driverExecution()
{
    String choice = String.Empty;
    do
    {
        Console.WriteLine("1. Register New Driver");
        Console.WriteLine("2. Update Driver Details By Id");
        Console.WriteLine("3. Delete Driver Details By Id");
        Console.WriteLine("4. Get Driver Details By Id");
        Console.WriteLine("Enter your Choice To Continue");

        int resopse = Convert.ToInt32(Console.ReadLine());
        switch (resopse)
        {
            case 1:
                Console.WriteLine("Enter Technician Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Boolean staffSreachDoc = doctorLogic.idSearch(id);
                if (staffSreachDoc == false)
                {
                    driver.Create(id, addDriver(id));
                    Console.WriteLine("Record Inserted Successfully");
                }
                else
                {
                    Console.WriteLine("Staff Id Already Exists");
                }
                break;

            case 2:
                Console.WriteLine("Enter Driver Id You Want to update");
                int staffid = Convert.ToInt32(Console.ReadLine());
                driver.Update(staffid, addDriver(staffid));
                Console.WriteLine("Driver Details Updated Successfully");
                break;
            case 3:
                Console.WriteLine("Enter Driver Id ");
                int delStaffId = Convert.ToInt32(Console.ReadLine());
                if (driver.Get(delStaffId) != null)
                {
                    driver.Delete(delStaffId);
                    Console.WriteLine("Record Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Record Not Found");
                }
                break;
            case 4:
                Console.WriteLine("Enter Driver Id");
                int getId = Convert.ToInt32(Console.ReadLine());
                var nur2 = driver.Get(getId);
                if(nur2 != null)
                    Console.WriteLine($"{nur2.StaffId} {nur2.StaffName} {nur2.Email} {nur2.ContactNo} {nur2.Education} {nur2.ShiftStartTime} {nur2.ShiftEndTime}");
                else
                    Console.WriteLine("Driver Id is Not Found");
                break;

        }
        Console.WriteLine();
        Console.WriteLine("Enter Y to Continue N to Stop");
        choice = Console.ReadLine();
    } while (choice == "Y" || choice == "y");
}

static Driver addDriver(int staffid)
{
    Console.WriteLine("Enter Nurse Details");
    Driver tech = new Driver();
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
    return tech;
}

Console.ReadLine();