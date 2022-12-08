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
    public class ShippingDbAccess
    {
        Entities entities;
        public ShippingDbAccess()
        {
            entities=new Entities();
        }
        public async Task<IEnumerable<Shipping>> getAddress(int userid)
        {

            var address = await entities.Shippings.Where(x=>x.UserId==userid).ToListAsync();
            return address;
        }

        public async Task<IEnumerable<Shipping>> getAddressById(int shippingID)
        {

            var address = await entities.Shippings.Where(x => x.ShippingId == shippingID).ToListAsync();
            return address;
            }

        public async Task<Shipping> CreateAddress(Shipping shipping)
        {
            var address= entities.Shippings.Add(shipping);
            var res= await entities.SaveChangesAsync();
            return address;
        }
        public async Task<bool> Update(int id,Shipping shipping)
        {
            var recordtoUpdate = await entities.Shippings.FindAsync(id);
            if (recordtoUpdate == null) throw new Exception("No record Found");

            recordtoUpdate.Address = shipping.Address;
            recordtoUpdate.city = shipping.city;
            recordtoUpdate.state=shipping.state;
            recordtoUpdate.country = shipping.country;
            recordtoUpdate.Pincode = shipping.Pincode;
            recordtoUpdate.Name = shipping.Name;
            recordtoUpdate.Mobile = shipping.Mobile;

            var res=await entities.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Shipping>> Get()
        {
            var users = await entities.Shippings.ToListAsync();
            return users;
        }

        public async Task<bool> Delete(int id)
        {
            var recordToDelete = await entities.Shippings.FindAsync(id);
            entities.Shippings.Remove(recordToDelete);
            var res = await entities.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }
    }
}