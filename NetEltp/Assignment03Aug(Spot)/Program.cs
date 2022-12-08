using System.IO;
using Assignment03Aug_Spot_.Operations;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Files");
try
{
    String filename = "Info.txt";
    string directory = @"C:\Users\Coditas\Documents\Coditas\Files\";
    FileOperations operation = new FileOperations();
    operation.CreateFile(directory, filename);
    operation.WriteFile(directory, filename, "The First File Created using the File Class");
    var dataFromFile = operation.ReadFile(directory, filename);

    Console.WriteLine($"Initial Data = " + $"{dataFromFile}");
    operation.AppendFile(directory, filename, "THe Next Data for Append");
    dataFromFile = operation.ReadFile(directory, filename);
    Console.WriteLine($"Data After Append = " + $"{dataFromFile}");

    string[] data = new string[] { "Line 1", "Line 2", "Line 3", "Line 4" };
    operation.AppendFile(directory, filename, data);
    dataFromFile = operation.ReadFile(directory, filename);
    Console.WriteLine($"Data After Appending Array = " + $"{dataFromFile}");


    String choice = String.Empty;
    do
    {
        Console.WriteLine("1. Make Copy of File");
        Console.WriteLine("2. Move File");
        Console.WriteLine("3. Encrypt the File");
        Console.WriteLine("4. Decrypt the File");
        Console.WriteLine("5. Delete the File ");
        Console.WriteLine("Enter Your Choice");
        int i = Convert.ToInt32(Console.ReadLine());
        switch (i)
        {
            case 1:
                operation.MakeCopy($"{directory}{filename}", @"C:\Users\Coditas\Documents\Coditas\Files\CopyOfInfo.txt");
                break;

            case 2:
                operation.MoveFile($"{directory}{filename}", @"C:\Users\Coditas\Documents\Coditas\MovedFiles\Info.txt");
                break;

            case 3:
                operation.Encrypt(@"C:\Users\Coditas\Documents\Coditas\MovedFiles\Info.txt");
                break;

            case 4:
                operation.Decrypt(@"C:\Users\Coditas\Documents\Coditas\MovedFiles\Info.txt");
                break;
            case 5:
                operation.DeleteFile(@"C:\Users\Coditas\Documents\Coditas\MovedFiles\Info.txt");
                break;
        }
        Console.WriteLine("Enter Y to Continue");
        choice = Console.ReadLine();
    } while (choice == "Y" || choice == "y");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}



Console.ReadLine();