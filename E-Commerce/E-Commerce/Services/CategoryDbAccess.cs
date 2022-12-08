using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Unity.Storage.RegistrationSet;

namespace E_Commerce.Services
{
    public class CategoryDbAccess
    {
        Entities entity;
        public CategoryDbAccess()
        {
            entity = new Entities();
        }
        public async Task<IEnumerable<category>> GetAllCategories()
        {
            var categories = await entity.categories.ToListAsync();
            return categories;
        }


        public bool Create(category cat)
        {

            var cats = new category()
            {
                categoryName=cat.categoryName,
                IsActive=cat.IsActive
            };
            entity.categories.Add(cats);
            var res = entity.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            return false;
        }


        public async Task<category> GetById(int id)
        {
            var cats = await entity.categories.FindAsync(id);
            return cats;
        }

        public async Task<bool> Update(int id, category cat)
        {
            var cats = await entity.categories.FindAsync(id);
            cats.categoryName = cat.categoryName;
            cats.IsActive = cat.IsActive;
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
            var recordToDelete = await entity.categories.FindAsync(id);
            entity.categories.Remove(recordToDelete);
            var res = await entity.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }
    }
}