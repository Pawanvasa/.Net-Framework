using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Unity.Storage.RegistrationSet;

namespace E_Commerce.Services
{
    public class SubcategoryDBAccess
    {
        Entities entity;
        public SubcategoryDBAccess()
        {
            entity= new Entities();
        }


        public bool Create(subCategory scat)
        {

            var cat = new subCategory()
            {
               categoryId=scat.categoryId,
               SubcategoryName= scat.SubcategoryName,
               Discription=scat.Discription,
            };
            entity.subCategories.Add(cat);
            var res = entity.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            return false;
        }


        public async Task<IEnumerable<subCategory>> Get()
        {
            var users = entity.subCategories.ToList();
            return users;
        }

        public async Task<subCategory> GetById(int id)
        {
            var users = await entity.subCategories.FindAsync(id);
            return users;
        }

        public async Task<bool> Update(int id, subCategory sub)
        {
            var subcat = await entity.subCategories.FindAsync(id);
            subcat.categoryId = sub.categoryId;
            subcat.SubcategoryName = sub.SubcategoryName;
            subcat.Discription = sub.Discription;
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
            var recordToDelete = await entity.subCategories.FindAsync(id);
            entity.subCategories.Remove(recordToDelete);
            var res = await entity.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }
    }
}