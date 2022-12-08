using DBConnection;
Console.WriteLine("Enter Command");
string? command = Console.ReadLine();
DbCommand dbCommand = new DbCommand(command);