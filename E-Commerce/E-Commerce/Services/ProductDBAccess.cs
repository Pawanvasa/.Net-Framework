using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using E_Commerce.Models.EntityClasses;

namespace E_Commerce.Services
{
    public class ProductDBAccess
    {
        
        Entities entity;
        public ProductDBAccess()
        {
            entity = new Entities();
        }

        public bool Create(Product prd)
        {

            var prod = new Product()
            {
                productName = prd.productName,
                SubCategoryId = prd.SubCategoryId,
                ProductPrice = prd.ProductPrice,
                Discount = prd.Discount,
                ProductImage = prd.ProductImage,
                Description = prd.Description,
                Quantity = prd.Quantity,
                IsActive = prd.IsActive,
                CreatedDate = DateTime.Now
            };
            entity.Products.Add(prod);
            var res = entity.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            return false;
        }


        public async Task<IEnumerable<Product>> Get()
        {
            var users =await entity.Products.ToListAsync();
            return users;
        }

        public async Task<Product> GetById(int id)
        {
            var users = await entity.Products.FindAsync(id);
            return users;
        }

        public async Task<bool> Update(int id,Product prd)
        {
            var product = await entity.Products.FindAsync(id);
            product.productName= prd.productName;
            product.SubCategoryId = prd.SubCategoryId;
            product.ProductPrice = prd.ProductPrice;
            product.Discount=prd.Discount;
            product.ProductImage = prd.ProductImage;
            product.Description=prd.Description;
            product.Quantity=prd.Quantity;
            product.IsActive=prd.IsActive;
            product.CreatedDate = prd.CreatedDate;

            var res= await entity.SaveChangesAsync();
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

        public async Task<IEnumerable<Product>> searchProducts(string SearchCriteria)
        {
            var result = entity.Products.ToList();
            if (SearchCriteria != null)
            {
                var keyWords = SearchCriteria.Split(' ');
                result = new List<Product>();
                foreach (var keyWord in keyWords)
                {
                    var records =await (from prod in entity.Products
                                   select prod).Where(c => c.Description.Contains(keyWord)
                                   || c.productName.Contains(keyWord)
                                   || c.Description.Contains(keyWord)
                                   || c.ProductPrice.ToString().Equals(keyWord)
                                   || c.subCategory.SubcategoryName.Contains(keyWord)).ToListAsync();
                    result.AddRange(records);

                }
                result = result.Distinct().ToList();
                return result;
            }
            return result;
        }

        public async Task<IEnumerable<Product>> getProdsBycategoryId(int catId)
        {
            var products = await (from cat in entity.categories
                           join scat in entity.subCategories
                           on cat.categoryid equals scat.categoryId
                           join prd in entity.Products on scat.SubCategoryId equals prd.SubCategoryId
                           where scat.categoryId==catId && cat.categoryid==catId
                           select prd).ToListAsync();

            return products;
        }

    }
}