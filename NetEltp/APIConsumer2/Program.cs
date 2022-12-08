// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;
Console.WriteLine("Hello, World!");
Console.WriteLine("Press a Key when Service Starts");
Console.ReadLine();

HttpClient client = new HttpClient();

/*Console.WriteLine("Enter Product Name");
string productName = Console.ReadLine();
try
{

    var customers = await client.GetFromJsonAsync<List<Customer>>($"https://localhost:7054/api/Customer?productName={productName}");
    foreach (var item in customers)
    {
        Console.WriteLine($"{item.CustomerId} {item.ContactName} {item.ContactTitle} {item.CompanyName}");
    }
}
catch (Exception)
{
    Console.WriteLine("Internal Server Error");
}*/

try
{
    var customers = await client.GetFromJsonAsync<List<CustomeModel>>($"https://c7c8-103-121-153-150.ngrok.io/");
    foreach (var item in customers!)
    {
        Console.WriteLine($"CustomerName = {item.customerName} Customer Id = {item.customerId} Order Count = {item.orderCount}");
       /* foreach(var item2 in item.OrderId)
        {
            Console.WriteLine($"Order id={item2}");
        }
        foreach(var item3 in item.QuantityOfProduct!)
        {
            Console.WriteLine($"Quantity of Product={item3}");
        }*/
    }
}
catch (Exception)
{  
    Console.WriteLine("Internal Server Error");
}

Console.ReadLine();

public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }


public partial class Order
{
    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }

    public int OrderId { get; set; }
    public string? CustomerId { get; set; }
    public int? EmployeeId { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int? ShipVia { get; set; }
    public decimal? Freight { get; set; }
    public string? ShipName { get; set; }
    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipRegion { get; set; }
    public string? ShipPostalCode { get; set; }
    public string? ShipCountry { get; set; }
    public string? OrderStatus { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}

public partial class OrderDetail
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }

    public virtual Order Order { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}

public partial class Product
{
    public Product()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }

    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }
    public string? QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public bool Discontinued { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}

public class CustomeModel
{
    public string? customerName { get; set; }
    public string? customerId { get; set; }
    public int orderCount { get; set; }
    public List<int>? OrderId { get; set; }
    public List<int>? QuantityOfProduct { get; set; }
}