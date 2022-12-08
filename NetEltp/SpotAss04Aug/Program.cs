
using SpotAss04Aug;
Console.WriteLine("USing Stream");
FileOpearations operation = new FileOpearations();
try
{
    Console.WriteLine("File Reading Line By Line");
    string str = operation.ReadFileLineByLine();
    Console.WriteLine(str);


    Console.WriteLine();
    Console.WriteLine("Entire File Reading");
    String entirFile = operation.ReadEntireFile();
    Console.WriteLine(entirFile);


    Console.WriteLine();
    Console.WriteLine("Enter Start Index");
    int sindex=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Count");
    int eindex= Convert.ToInt32(Console.ReadLine());
    foreach(var s in operation.ReadFileStartandEnd(sindex, eindex))
    {
        Console.Write(s);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    operation.Dispose();
}
Console.ReadLine();