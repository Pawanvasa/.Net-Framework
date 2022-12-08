using AdoNet_DisConnected;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Ado Dot Net Dis-Connected");

DataAccess dataAccess = new DataAccess();
//dataAccess.CreateDept();
//dataAccess.FindRecord(80);
//dataAccess.Update(80);
//dataAccess.Delete(80);
dataAccess.EstablishRealation(10);
Console.ReadLine();
