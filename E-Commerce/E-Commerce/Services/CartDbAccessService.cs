using E_Commerce.Models;
using E_Commerce.Models.EntityClasses;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace E_Commerce.Services
{
    public class CartDbAccessService
    {
        Entities entities;
        public CartDbAccessService()
        {
            entities = new Entities();
        }


        public bool AddToCart(Cart cart)
        {
            var res = entities.Carts.Add(cart);
            entities.SaveChanges();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetProductsOnCart(int userId)
        {
            var products = await (from prod in entities.Products
                                  join cart in entities.Carts
                                  on prod.ProductId equals cart.ProductId
                                  where cart.UserId == userId
                                  select prod).ToListAsync();
            return products;
        }

        public async Task<bool> RemoveProdsFormCart(int id)
        {
            var prod = await (from crt in entities.Carts
                              where crt.ProductId == id
                              select crt).ToListAsync();
            foreach (var item in prod)
            {
                var res = entities.Carts.Remove(item);
            }
            var result = entities.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveProdsFromCartByUserID(int UserId)
        {
            var prod = await (from crt in entities.Carts
                              where crt.UserId == UserId
                              select crt).ToListAsync();
            foreach (var item in prod)
            {
                var res = entities.Carts.Remove(item);
            }
            var result = entities.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddQuantity(int productId)
        {
            var product = entities.Carts.FirstOrDefault(x => x.ProductId == productId);
            product.ProductCount += 1;
            var res = await entities.SaveChangesAsync();
            if (res > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ReduceQuantity(int productId)
        {
            var product = entities.Carts.FirstOrDefault(x => x.ProductId == productId);
            product.ProductCount -= 1;
            var res = await entities.SaveChangesAsync();
            if (res > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }



        public async Task<IEnumerable<Cart>> GetCarts()
        {
            var cartdeatils = await entities.Carts.ToListAsync();
            return cartdeatils;
        }

        public async Task<Cart> GetProdQuantity(int productId)
        {
            var carts = await entities.Carts.ToListAsync();
            var quntity = (from crt in carts
                           where crt.ProductId == productId
                           select crt).FirstOrDefault();
            return quntity;
        }

        public async Task<PaymentDetails> getPayment(int userid)
        {
            var prodsOnCart = await GetProductsOnCart(userid);
            var cartValues = await GetCarts();
            int totalAmount = 0;
            int Discount = 0;
            int delivary = 0;
            int SubTotal = 0;
            int specialParcelFee = 0;
            foreach (var item in prodsOnCart)
            {
                foreach (var carts in cartValues)
                {
                    if (item.ProductId == carts.ProductId)
                    {
                        totalAmount += item.ProductPrice * carts.ProductCount;
                        Discount += item.Discount * carts.ProductCount;
                    }
                }

            }
            if (totalAmount > 0)
            {
                specialParcelFee = 39;
                SubTotal = totalAmount - Discount + delivary + specialParcelFee;
            }
            PaymentDetails payment = new PaymentDetails()
            {
                Price = totalAmount,
                Discount = Discount,
                DeliveryCharges = delivary,
                SecurePackagingFee = specialParcelFee,
                TotalAmount = SubTotal
            };

            return payment;
        }

    }
}