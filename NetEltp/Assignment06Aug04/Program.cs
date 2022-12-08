using Assignment04Aug;
using System;
using System.Transactions;

Console.WriteLine("Assignment 04 Aug");

Opeartions op = new Opeartions();
String choice=String.Empty;
String filePath = @"C:\Users\Coditas\Documents\Assignment04Aug\";
//Console.WriteLine("Enter File Name");
String filename = "DBFile.csv";//Console.ReadLine();
//op.CreateFile(filePath, filename);
Staff staff;
staff = new Doctor() { StaffId=101,StaffName="pawan",ContactNo=87363,Department="Doctor",Education="M.B.B.S",BasicPay=34000,Email="vasa@gmail.com",Location="Pune",ShiftEndTime=5,ShiftStartTime=18,Specilization="Eye"};
op.WriteDataIntoFile(filePath,filename,staff);

var staff1 = new Doctor(){StaffId = 102,StaffName = "Sunil",ContactNo = 7462,Department = "Doctor",Education = "BMMS",BasicPay = 35000,Email = "Sunil@gmail.com",Location = "Mumbai",ShiftEndTime = 8,ShiftStartTime = 18,Specilization = "Dental" };
op.WriteDataIntoFile(filePath, filename, staff1);

var staff2 = new Doctor(){ StaffId = 103,StaffName = "Naman",ContactNo = 924235,Department = "Doctor",Education = "MBBS",BasicPay = 50000,Email = "Naman@outlook.com",Location = "Delhi",ShiftEndTime = 10,ShiftStartTime = 20, Specilization = "Eye" };
op.WriteDataIntoFile(filePath, filename, staff2);

var staff3 = new Doctor() { StaffId = 104, StaffName = "Suman", ContactNo = 6754, Department = "Doctor", Education = "MBBS", BasicPay = 70000, Email = "Suman@outlook.com", Location = "Delhi", ShiftEndTime = 9, ShiftStartTime = 17, Specilization = "Bones" };
op.WriteDataIntoFile(filePath, filename, staff3);

var staff4 = new Doctor() { StaffId = 105, StaffName = "Sita", ContactNo = 36524, Department = "Doctor", Education = "MBBS", BasicPay = 60000, Email = "Sita@outlook.com", Location = "Pune", ShiftEndTime = 10, ShiftStartTime = 18, Specilization = "Skin" };
op.WriteDataIntoFile(filePath, filename, staff4);

var staff5 = new Doctor() { StaffId = 106, StaffName = "Ramya", ContactNo = 35742, Department = "Doctor", Education = "MS", BasicPay = 95000, Email = "Ramya@outlook.com", Location = "Mumbai", ShiftEndTime = 8, ShiftStartTime = 16, Specilization = "Skin" };
op.WriteDataIntoFile(filePath, filename, staff5);

var staff6 = new Doctor() { StaffId = 107, StaffName = "Hari", ContactNo = 264827, Department = "Doctor", Education = "MD", BasicPay = 45000, Email = "Hari@gmai.com", Location = "Pune", ShiftEndTime = 10, ShiftStartTime = 20 , Specilization = "Bones" };
op.WriteDataIntoFile(filePath, filename, staff6);

var staff7 = new Doctor() { StaffId = 108, StaffName = "Mohan", ContactNo = 8688, Department = "Doctor", Education = "MS", BasicPay = 73000, Email = "Mohan@gmai.com", Location = "Banglore", ShiftEndTime = 5, ShiftStartTime = 14, Specilization = "Legs" };
op.WriteDataIntoFile(filePath, filename, staff7);

var staff8 = new Doctor() { StaffId = 109, StaffName = "Amar", ContactNo = 54387, Department = "Doctor", Education = "MBBS", BasicPay = 30800, Email = "Amar@gmai.com", Location = "Banglore", ShiftEndTime = 11, ShiftStartTime = 20 , Specilization = "Dentist" };
op.WriteDataIntoFile(filePath, filename, staff8);

var staff9 = new Doctor() { StaffId = 110, StaffName = "Barath", ContactNo = 87453, Department = "Doctor", Education = "MS", BasicPay = 60000, Email = "Barath@gmai.com", Location = "Pune", ShiftEndTime = 9, ShiftStartTime = 18 , Specilization = "Eyes" };
op.WriteDataIntoFile(filePath, filename, staff9);

var staff10 = new Nurse() { StaffId = 111, StaffName = "Ramya", ContactNo = 7463, Department = "Nurse", Education = "Nursing", BasicPay = 12000, Email = "ramya@gmai.com", Location = "Pune", ShiftEndTime = 9, ShiftStartTime = 21 , Experience=3 };
op.WriteDataIntoFile(filePath, filename, staff10);

var staff11 = new Nurse() { StaffId = 112, StaffName = "Jan", ContactNo = 26341, Department = "Nurse", Education = "Nursing", BasicPay = 22000, Email = "jan@gmai.com", Location = "Mumbai", ShiftEndTime = 3, ShiftStartTime = 12 ,Experience=1};
op.WriteDataIntoFile(filePath, filename, staff11);

var staff12 = new Nurse() { StaffId = 113, StaffName = "sun", ContactNo = 61527, Department = "Nurse", Education = "NS", BasicPay = 21000, Email = "sun@gmai.com", Location = "Mumbai", ShiftEndTime = 10, ShiftStartTime = 20 , Experience=2};
op.WriteDataIntoFile(filePath, filename, staff12);

var staff13 = new Nurse() { StaffId = 114, StaffName = "Aadhya ", ContactNo = 212842, Department = "Nurse", Education = "Nursing", BasicPay = 25000, Email = "Aadhya@gmai.com", Location = "Pune", ShiftEndTime = 9, ShiftStartTime = 19 , Experience=4};
op.WriteDataIntoFile(filePath, filename, staff13);

var staff14 = new Nurse() { StaffId = 115, StaffName = "Sita", ContactNo = 826741, Department = "Nurse", Education = "MS", BasicPay = 35000, Email = "sita@gmai.com", Location = "Delhi", ShiftEndTime = 12, ShiftStartTime = 23,Experience=4};
op.WriteDataIntoFile(filePath, filename, staff14);

var staff15 = new Technician() { StaffId = 116, StaffName = "Ramesh", ContactNo = 966476, Department = "Technician",  BasicPay = 15000, Email = "ramesh@gmai.com", Location = "Pune", ShiftEndTime = 9, ShiftStartTime = 18, SaftyChecksDone=3};
op.WriteDataIntoFile(filePath, filename, staff15);

var staff16 = new Technician() { StaffId = 117, StaffName = "Suresh", ContactNo = 14527, Department = "Technician", BasicPay = 25000, Email = "suresh@gmai.com", Location = "Mumbai", ShiftEndTime = 8, ShiftStartTime = 17, SaftyChecksDone = 6 };
op.WriteDataIntoFile(filePath, filename, staff16);

var staff17 = new Technician() { StaffId = 118, StaffName = "Sathis", ContactNo = 06126, Department = "Technician", BasicPay = 9000, Email = "sathis@gmai.com", Location = "Delhi", ShiftEndTime = 10, ShiftStartTime = 16, SaftyChecksDone = 8 };
op.WriteDataIntoFile(filePath, filename, staff17);

var staff18 = new Technician() { StaffId = 119, StaffName = "Sanath", ContactNo = 8747, Department = "Technician", BasicPay = 8300, Email = "Sanath@gmai.com", Location = "Pune", ShiftEndTime = 10, ShiftStartTime = 14, SaftyChecksDone = 5 };
op.WriteDataIntoFile(filePath, filename, staff18);

var staff19 = new Technician() { StaffId = 120, StaffName = "kasi", ContactNo = 368452, Department = "Technician", BasicPay = 31000, Email = "kasi@gmai.com", Location = "Delhi", ShiftEndTime = 10, ShiftStartTime = 22 , SaftyChecksDone = 10};
op.WriteDataIntoFile(filePath, filename, staff19);

var staff20 = new Technician() { StaffId = 121, StaffName = "Ravi", ContactNo = 87356, Department = "Technician", BasicPay = 21000, Email = "Ravi@gmai.com", Location = "Pune", ShiftEndTime = 9, ShiftStartTime = 18, SaftyChecksDone = 3};
op.WriteDataIntoFile(filePath, filename, staff20);

var staff21 = new Technician() { StaffId = 122, StaffName = "Jansi", ContactNo = 893672, Department = "Technician", BasicPay = 24000, Email = "Jansi@gmai.com", Location = "Delhi", ShiftEndTime = 11, ShiftStartTime = 22, SaftyChecksDone = 4 };
op.WriteDataIntoFile(filePath, filename, staff21);

var staff22 = new Technician() { StaffId = 123, StaffName = "Manu", ContactNo = 7287647, Department = "Technician", BasicPay = 98387, Email = "Manu@gmail.com", Location = "Delhi", ShiftEndTime = 10, ShiftStartTime = 22, SaftyChecksDone = 7};
op.WriteDataIntoFile(filePath, filename, staff22);

var staff23 = new Technician() { StaffId = 124, StaffName = "Sahilu", ContactNo = 236547, Department = "Technician", BasicPay = 11000, Email = "Sahilu@gmai.com", Location = "Mumbai", ShiftEndTime = 8, ShiftStartTime = 14, SaftyChecksDone = 4};
op.WriteDataIntoFile(filePath, filename, staff23);

var staff24 = new Technician() { StaffId = 125, StaffName = "Tom", ContactNo = 73463, Department = "Technician", BasicPay = 20000, Email = "Tom@gmai.com", Location = "Pune", ShiftEndTime = 10, ShiftStartTime = 18, SaftyChecksDone = 5};
op.WriteDataIntoFile(filePath, filename, staff24);

var staff25 = new Technician() { StaffId = 126, StaffName = "james", ContactNo = 7345, Department = "Technician", BasicPay = 23000, Email = "james@gmai.com", Location = "Mumbai", ShiftEndTime = 8, ShiftStartTime = 19, SaftyChecksDone = 10 };
op.WriteDataIntoFile(filePath, filename, staff25);

var staff26 = new Technician() { StaffId = 127, StaffName = "Jerry", ContactNo = 3648265, Department = "Technician", BasicPay = 13000, Email = "Jerry@gmai.com", Location = "Delhi", ShiftEndTime = 6, ShiftStartTime = 14, SaftyChecksDone = 20};
op.WriteDataIntoFile(filePath, filename, staff26);

var staff27 = new Technician() { StaffId = 128, StaffName = "Rammy", ContactNo = 728534, Department = "Technician", BasicPay = 11000, Email = "Rammy@gmai.com", Location = "Pune", ShiftEndTime = 8, ShiftStartTime = 18, SaftyChecksDone = 15 };
op.WriteDataIntoFile(filePath, filename, staff27);

do
{
    Console.WriteLine("1. Read Staff By Category");
    Console.WriteLine("2. Check If The Staff Exsist");
    Console.WriteLine("3. Read Records By Count");
    Console.WriteLine("4. Delete Staff By Id");
    Console.WriteLine("5. Update Staff By Id");
    int res = Convert.ToInt32(Console.ReadLine());
    switch (res)
    {
        case 1:
            Console.WriteLine("Enter Staff Category");
            String category = Console.ReadLine();
            op.ReadFileByCategory(category!,$"{filePath}{filename}");
            break;

        case 2:
            Console.WriteLine("Enter Staff Id");
            int id = Convert.ToInt32(Console.ReadLine());
            op.CheckStaffId(id);
            break;

        case 3:
            Console.WriteLine("Enter Count ");
            int count = Convert.ToInt32(Console.ReadLine());
            op.GetStaffByCount(count);
            break;
        case 4:
            Console.WriteLine("Enter Staff Id");
            int staffid=Convert.ToInt32(Console.ReadLine());
            op.DeleteStaffById(staffid);
            break;
        case 5:
            Console.WriteLine("Enter Staff Id ");
            int staffidtoupdate = Convert.ToInt32(Console.ReadLine());
            op.UpdateStaffById(staffidtoupdate);
            break;
    }
    Console.WriteLine("To Continue Enter Y");
    choice = Console.ReadLine();
} while (choice == "y" || choice == "Y");
Console.WriteLine();

