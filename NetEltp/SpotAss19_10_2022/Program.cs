//See https://aka.ms/new-console-template for more information
using SpotAss19_10_2022_DBFirstApproch.DBAccess;
using SpotAss19_10_2022_DBFirstApproch.Models;
using System.Text.Json;

Console.WriteLine("Using Entity Framework First Approch");

try
{
    CustomerDataAccess customerDataAccess = new CustomerDataAccess();
   // customerDataAccess.GetTotalOrders();
    //customerDataAccess.GetOrderDetails();
    //customerDataAccess.SumPrice();
    customerDataAccess.FromtoToday();
    //customerDataAccess.RegectedCustomers();


}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static void Print(IEnumerable<Customer> dept)
{
    foreach (Customer customer in dept)
    {
        Console.WriteLine($"Customer Id = {customer.CustomerId} Customer Name = {customer.ContactName}");
    }
}
