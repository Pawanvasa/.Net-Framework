using SpotAss19_10_2022_DBFirstApproch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotAss19_10_2022_DBFirstApproch.DBAccess;
using Microsoft.EntityFrameworkCore;

namespace SpotAss19_10_2022_DBFirstApproch.DBAccess
{
    public class CustomerDataAccess
    {
        NorthwindContext context;

        public CustomerDataAccess()
        {
            context = new NorthwindContext();
        }
        public void GetTotalOrders()
        {
            var customers = (from cus in context.Customers
                             join ord in context.Orders on
                             cus.CustomerId equals ord.CustomerId
                             group cus by cus.ContactName into custGroup
                             select new
                             {
                                 CustomerName = custGroup.Key,
                                 NumberofOrders = custGroup.Count(),
                             });

            foreach (var item in customers)
            {
                Console.WriteLine($"Customer name = {item.CustomerName} | Total order count = {item.NumberofOrders}");
            }

            // return result;
        }

        public void GetOrderDetails()
        {
            var OrderDetails = from cus in context.Customers
                               join ord in context.Orders on
                                cus.CustomerId equals ord.CustomerId
                               join ordDetails in context.OrderDetails on
                                ord.OrderId equals ordDetails.OrderId
                               select new
                               {
                                   CusName = cus.ContactName,
                                   orderId = ord.OrderId,
                                   prodId = ordDetails.ProductId,
                                   unitPrice = ordDetails.UnitPrice,
                                   quantity = ordDetails.Quantity,
                                   discount = ordDetails.Discount,
                               };

            foreach (var item in OrderDetails)
            {
                Console.WriteLine($"Customer name = {item.CusName} OrderId = {item.orderId} Product Id = {item.prodId} Unit price = {item.unitPrice} Quantity = {item.quantity} Discount = {item.discount}");
            }
        }

        public void SumPrice()
        {
            var sumPrice = from cus in context.Customers
                           join ord in context.Orders on cus.CustomerId equals ord.CustomerId
                           join ordDetails in context.OrderDetails on ord.OrderId equals ordDetails.OrderId
                           group ordDetails by new
                           {
                               cus.ContactName,
                               ord.OrderId

                           } into MyGroup
                           select new
                           {
                               custname = MyGroup.Key.ContactName,
                               Orderid = MyGroup.Key.OrderId,
                               Price = MyGroup.Sum(e => e.UnitPrice*e.Quantity),
                               //quantity= MyGroup.Sum(e => e.Quantity)
                           };

            foreach (var item in sumPrice)
            {
                Console.WriteLine($"Customer name = {item.custname}, | OrderId = {item.Orderid} | Total Price = {item.Price}");
            }
        }
        public void RegectedCustomers()
        {
            var regCustomers = from cus in context.Customers
                               join ord in context.Orders on
                               cus.CustomerId equals ord.CustomerId
                               where ord.OrderStatus=="rejected"
                               select cus;

            foreach (var item in regCustomers)
            {
                Console.WriteLine($"Customer name = {item.ContactName}, | Customer Id = {item.CustomerId} | Company Name = {item.CompanyName}");
            }
        }
        public void FromtoToday()
        {
            DateTime dateTime1 = new DateTime(2/4/1999);
            DateTime dateTime2 = DateTime.Now;
            Console.WriteLine(dateTime2);
            var records = from cus in context.Customers
                          join ord in context.Orders on
                          cus.CustomerId equals ord.CustomerId
                          where ord.OrderDate > dateTime1 && ord.OrderDate.Equals(dateTime2)
                          select cus;
            foreach(var record in records)
            {
                Console.WriteLine($"Customer Id = {record.CustomerId} Company Name = {record.CompanyName} Customer Name = {record.ContactName}");
            }
        }
    }
}
