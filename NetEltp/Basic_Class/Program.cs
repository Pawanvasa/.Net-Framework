using Basic_Class;
StaffLogic logic = new StaffLogic();
var staffs = logic.GetAllStaff();


static Staff addStaff(int id)
{
    //Console.WriteLine("Enter Staff Details ");
    Staff staff1 = new Staff();
    staff1.StaffId = id; 
    Console.WriteLine("Enter Staff Name");
    staff1.StaffName = Console.ReadLine();
    Console.WriteLine("Enter Email");
    staff1.Email = Console.ReadLine();
    Console.WriteLine("Enter Department Name");
    staff1.DeptName = Console.ReadLine();
    Console.WriteLine("Ender Gender");
    staff1.Gender = Console.ReadLine();
    Console.WriteLine("Enter Date of Birth");
    staff1.DateOfBirth = DateOnly.Parse(Console.ReadLine());
    Console.WriteLine("Enter Staff Category");
    staff1.StaffCategory = Console.ReadLine();
    Console.WriteLine("Enter Education");
    staff1.Education = Console.ReadLine();
    Console.WriteLine("Enter Contact Number");
    staff1.ContatNo = Convert.ToInt32(Console.ReadLine());
    
    return staff1;
}
String cont;
do
{
    Console.WriteLine("1. Register a new Staff");
    Console.WriteLine("2. Update staff Details");
    Console.WriteLine("3. Delete Staff Details");
    Console.WriteLine("4. Display Staff Details By Id");
    Console.WriteLine("5. Display all the Staff Details");
    Console.WriteLine();
    Console.WriteLine("Enter Your Choice to perform Operation");
    int respose = Convert.ToInt32(Console.ReadLine());

    switch (respose)
    {
        //Register a new Staff
        case 1:
            Console.WriteLine("Enter Staff Id");
            int staffid1=Convert.ToInt32(Console.ReadLine());
            var staff1 = logic.GetStaffById(staffid1);
            if (staff1 == null)
            {
                staffs = logic.RegisterNewStaff(addStaff(staffid1));
                Console.WriteLine("User Registered Successfully");
            }
            else
            {
                Console.WriteLine("Staff Id Already Exits");
            }
            break;

        //Update staff Details
        case 2:
            Console.WriteLine("Enter Staffid That You want to update");
            int id=Convert.ToInt32(Console.ReadLine());
            var staff2 = logic.GetStaffById(id);
            if (staff2 != null)
            {
                logic.UpdateStaffInfo(id, addStaff(id));
                Console.WriteLine("Record Updated Successfully");
            }
            else
            {
                Console.WriteLine("Staff id Not Found");
            }

            break;

        //Delete Staff Details
        case 3:
            Console.WriteLine("Enter Staff Id To Delete The Information");
            int staffid=Convert.ToInt32(Console.ReadLine());
            Boolean res=logic.DeleteStaff(staffid);
            if (res)
                Console.WriteLine($"Staff {staffid} is Successfully Deleted");
            else
                Console.WriteLine("Staff id Not Found");
            break;

        //Display Staff Details By Id
        case 4:
            Console.WriteLine("Enter Staff Id");
            int ressid = Convert.ToInt32(Console.ReadLine());
            var staffd = logic.GetStaffById(ressid);  
            if (staffd != null)
                Console.WriteLine($"{staffd.StaffId} {staffd.StaffName} {staffd.DeptName} {staffd.Email} {staffd.Gender} {staffd.ContatNo} {staffd.DateOfBirth} {staffd.Education}");
            if (staffd == null)
            {
                Console.WriteLine("Staff Details Not Found");
            }
            break;

        //Display all the Staff Details
        case 5:
            Console.WriteLine("All Staffs Details");
            foreach (var s in staffs)
            {
                Console.WriteLine($"{s.StaffId} {s.StaffName} {s.DeptName} {s.Email} {s.Gender} {s.ContatNo} {s.DateOfBirth} {s.Education}");
            }
            break;
            default:
            Console.WriteLine("Choose valide option");
            break;
        
    }
    Console.WriteLine();
    Console.WriteLine("Enter Y to Continue N to Stop ");
    cont = Console.ReadLine();
    //Console.Clear();
}while(cont=="Y" || cont=="y");



