using APIAss04.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using APIAss04.Models;
namespace APIAss04.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        NorthWindContext context;
        public CustomerController(NorthWindContext context)
        {
            this.context = context;
        }
        /*[HttpGet]
         public async Task<IActionResult> Get(string productName)
         {
             var res = (from cus in context.Customers
                       join ord in context.Orders on cus.CustomerId equals ord.CustomerId
                       join ordDetails in context.OrderDetails on ord.OrderId equals ordDetails.OrderId
                       join prod in context.Products on ordDetails.ProductId equals prod.ProductId
                       where prod.ProductName == productName
                       select cus).ToList();

             if (res.Count <=0)
             {
                 throw new Exception($"No Customers have placed order for {productName}");
             }
             return Ok(res);
         }

        [HttpGet]
        public async Task<IActionResult> GetCustomerDetails()
        {
            var result = from cus in context.Customers
                         join ord in context.Orders on cus.CustomerId equals ord.CustomerId
                         join ordDetails in context.OrderDetails on ord.OrderId equals ordDetails.OrderId
                         group ordDetails by new
                         {
                             cus.ContactName,
                             cus.CustomerId,
                             ord.OrderId,
                         } into myDetails
                         select new
                         {
                             CustomerName = myDetails.Key.ContactName,
                             CustomerId = myDetails.Key.CustomerId,
                             orderCount = myDetails.Sum(s => s.Quantity),
                             ProductId = myDetails.Select(s => s.ProductId),
                             QuantityOfProduct = myDetails.Select(s => s.Quantity)
                         };
            return Ok(result);
        }*/
    }
}
