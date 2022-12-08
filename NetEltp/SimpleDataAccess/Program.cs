using SimpleDataAccess.Models;
using SimpleDataAccess.DataAccess;
using SimpleDataAccess.DataAccess.CS_SimleDataAccess.DataAccess;
using System.Data;

Console.WriteLine("USing ADO.NET");
try
{
    CategoryDbAccess categoryDbAccess = new CategoryDbAccess();

    var categories = categoryDbAccess.GetRecords();
    //PrintData(categories);
    //Console.WriteLine();
    var cat = new Category()
    {
        CategoryId = 10005,
        CategoryName = "Healthcare (Infants)",
        BasePrice = 8000
    };
    //categoryDbAccess.CreateRecord(cat);

    //categoryDbAccess.UpdateRecord(cat.CategoryId,cat);
   
    //categoryDbAccess.DeleteRecord(cat.CategoryId);

    //categories = categoryDbAccess.GetRecords();
    //PrintData(categories);


    IDbAccess<Product,int> dbAccess = new ProductDbAccess();
    var allRecordsInProduct= dbAccess.GetAll();
    printProductDBData(allRecordsInProduct);

    var prod = new Product()
    {
        ProductUniqueId =5,
        ProductId = "prod-007",
        ProductName = "Iphone",
        Description = "Mobile Phone",
        Price = 50000,
        CategoryId = 20,
        Manufacturer = "Apple"
    };

    dbAccess.Delete(4);
    allRecordsInProduct = dbAccess.GetAll();
    printProductDBData(allRecordsInProduct);

    var record=dbAccess.Get(5);
    Console.WriteLine(record.Manufacturer+""+record.ProductUniqueId);
}
catch (Exception ex)
{
    Console.WriteLine($"Error Occurred {ex.Message}");
}
Console.ReadLine();

static void PrintData(IEnumerable<Category> categories)
{
    foreach (var cat in categories)
    {
        Console.WriteLine($"{cat.CategoryId} {cat.CategoryName} {cat.BasePrice}");
    }
}

static void printProductDBData(IEnumerable<Product> products)
{
    foreach(var pro in products)
    {
        Console.WriteLine($"{pro.ProductUniqueId} {pro.ProductId} {pro.ProductName} {pro.Price} {pro.Manufacturer}");
    }
}