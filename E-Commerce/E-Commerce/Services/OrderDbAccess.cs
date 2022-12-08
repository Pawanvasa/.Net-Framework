using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Unity.Storage.RegistrationSet;

namespace E_Commerce.Services
{
    public class OrderDbAccess
    {
        Entities entity;
        public OrderDbAccess()
        {
            entity = new Entities();
        }

        public async Task<bool> Insert(IEnumerable<Product> orderdetails, int userId, int ship)
        {
            int result = 0;
            foreach (var product in orderdetails)
            {
                orderTable order = new orderTable()
                {
                    UserId = userId,
                    ShippingId = ship,
                    TotalAmount = product.ProductPrice,
                    DiscountAmount = product.Discount,
                    PayableAmount = product.ProductPrice - product.Discount,
                    IsCompleted = true,
                    PaymentType = "Card",
                    orderDate = DateTime.Now,
                    ProductId = product.ProductId,
                    Quantity = 1,
                };

                var res = entity.orderTables.Add(order);
                result = await entity.SaveChangesAsync();
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<orderTable>> Get()
        {
            var orders = await entity.orderTables.ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<orderTable>> GetById(int id)
        {
            var orders = await entity.orderTables.Where(x=>x.UserId==id).ToListAsync();
            return orders;
        }

        public async Task<bool> Update(int id, orderTable ord)
        {
            var ords = await entity.orderTables.FindAsync(id);
            ords.UserId = ord.UserId;
            ords.ShippingId = ord.ShippingId;
            ords.TotalAmount = ord.TotalAmount;
            ords.DiscountAmount = ord.DiscountAmount;
            ords.PayableAmount = ord.PayableAmount;
            ords.IsCompleted = ord.IsCompleted;
            ords.orderDate = ord.orderDate;
            ords.PaymentType = ord.PaymentType;
            ords.ProductId = ord.ProductId;
            ords.Quantity = ord.Quantity;
            var res = await entity.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> Delete(int id)
        {
            var recordToDelete = await entity.Products.FindAsync(id);
            entity.Products.Remove(recordToDelete);
            var res = await entity.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Cancel(int id)
        {
            var orderToCancel = await entity.orderTables.FindAsync(id);
            orderToCancel.IsCompleted = false;
            var res = await entity.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}