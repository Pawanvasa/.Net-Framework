using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Text;
using E_Commerce.Models.EntityClasses;
using System.Web.Mvc;
using System.Security.Cryptography.Xml;

namespace E_Commerce.Services
{
    public class UserDBAccessService
    {

        Entities entity;
        public UserDBAccessService()
        {
            entity = new Entities();
        }

        public async Task<IEnumerable<UserTable>> ValidateUser(LoginDetails user)
        {
            //var isValid = entity.UserTables.Any(x => x.UserName == user.UserName && x.Password == user.Password);
            var findUser =await (from usr in entity.UserTables
                          where usr.UserName == user.UserName && usr.Password == user.Password
                          select usr).ToListAsync();

            return findUser;

        }

        public List<RoleTable> GetRole(LoginDetails user)
        {
            var GetRole = (from rol in entity.RoleTables
                           join usr in entity.UserTables
                           on rol.RoleId equals usr.RoleId
                           where usr.UserName == user.UserName && usr.Password == user.Password
                           select rol).ToList();
            return GetRole;
        }
        public bool Create(UserEntity users)
        {
            var user = new UserTable()
            {
                FirstName = users.FirstName,
                LastName = users.LastName,
                UserName = users.UserName,
                Password =users.Password,
                Email = users.Email,
                
            };
            user.AccountCreated = DateTime.Now;
            user.RoleId = 2;
            entity.UserTables.Add(user);   
           var res= entity.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<UserTable>> Get()
        {
            var users = await entity.UserTables.ToListAsync();
            return users;
        }
        
        public async Task<UserTable> GetById(int id)
        {
            var users= await entity.UserTables.FindAsync(id);
            return users;
        }

        public async Task<bool> Update(int id,UserTable user)
        {
            var recordToUpdate= await entity.UserTables.FindAsync(id);
            recordToUpdate.UserName = user.UserName;
            recordToUpdate.Password = user.Password;
            recordToUpdate.RoleId = 2;
            recordToUpdate.AccountCreated = DateTime.Now;
            recordToUpdate.FirstName=user.FirstName;
            recordToUpdate.LastName=user.LastName;
            recordToUpdate.Email=user.Email;
            recordToUpdate.Password=user.Password;
            var res=await entity.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdatePassword(int id,UserTable user)
        {
            var recordToUpdate= await entity.UserTables.FindAsync(id);
            recordToUpdate.Password = user.Password;
            var res=await entity.SaveChangesAsync();
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
            var recordToDelete=await entity.UserTables.FindAsync(id);
            entity.UserTables.Remove(recordToDelete);
            var res=await entity.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }
    }
}