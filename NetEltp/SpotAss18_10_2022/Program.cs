using SpotAss18_10_2022.Models;
Console.WriteLine("Using Table Hirachy Approch");
InfoDbContext ctx = new InfoDbContext();

Doctor doc = new Doctor()
{
    StaffId = 101,
    StaffName = "Sun",
    StaffCategory = "Doctor",
    Contact = "3863",
    NumberOperations = 23,
    PatientsDaigonised = 12
};
ctx.Staff.Add(doc);
ctx.SaveChanges();

Console.ReadLine();

Console.WriteLine(sizeof(int));