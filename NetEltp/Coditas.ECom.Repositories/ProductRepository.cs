using Coditas.ECom.DataAccess1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coditas.ECom.Repositories
{
    public class ProductRepository : IDBRepository<Product, int>
    {
        eShoppingContext _context;
        public ProductRepository(eShoppingContext context)
        {
            _context = context;
        }

        async Task<Product> IDBRepository<Product, int>.CreateAsync(Product entity)
        {
            try
            {
                var result = await _context.Products.AddAsync(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (DbUpdateException)
            {
                throw new Exception("Parent key Not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<bool> IDBRepository<Product, int>.DeleteAsync(int id)
        {
            try
            {
                var recordToDelete = await _context.Products.FindAsync(id);
                if (recordToDelete == null) throw new Exception("Record for Delete is not found");

                _context.Products.Remove(recordToDelete);
                int result = await _context.SaveChangesAsync();
                if (result > 0)  return true;
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<IEnumerable<Product>> IDBRepository<Product, int>.GetAsync()
        {
            return await _context.Products.ToListAsync();
        }

        async Task<Product> IDBRepository<Product, int>.GetByIdAsync(int id)
        {
            try
            {
                var record = await _context.Products.FindAsync(id);
                if (record == null)
                    throw new Exception("Record  not found");
                return record;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Product> IDBRepository<Product, int>.UpdateAsync(int id, Product entity)
        {
            try
            {
                var recordToUpate = await _context.Products.FindAsync(id);
                if (recordToUpate == null) throw new Exception("Record for Deleteupdate is not found");

                recordToUpate.ProductName = entity.ProductName;
                recordToUpate.Manufacturer = entity.Manufacturer;
                await _context.SaveChangesAsync();
                return recordToUpate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
