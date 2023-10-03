using Coditas.ECom.DataAccess1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Data.Common;

namespace Coditas.ECom.Repositories
{
    public class CategoryRepository :IDBRepository<Category,int>
    {
        eShoppingContext _context;
        public CategoryRepository(eShoppingContext context)
        {
            _context= context;
        }

        async Task<Category> IDBRepository<Category,int>.CreateAsync(Category entity)
        {
            try
            {
                var result = await _context.Categories.AddAsync(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Invalid Record");
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }

        async Task<bool> IDBRepository<Category,int>.DeleteAsync(int id)
        {
            try
            {
                var recordToDelete = await _context.Categories.FindAsync(id);
                if (recordToDelete == null) throw new Exception($"No Record found with the Id {id}");
                _context.Categories.Remove(recordToDelete);
                int result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
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

        async Task<IEnumerable<Category>> IDBRepository<Category,int>.GetAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        async Task<Category> IDBRepository<Category, int>.GetByIdAsync(int id)
        {
            try
            {
                var record = await _context.Categories.FindAsync(id);
                if (record == null)
                    throw new Exception($"No Record found with the Id {id}");
                return record;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Category> IDBRepository<Category, int>.UpdateAsync(int id, Category entity)
        {
            try
            {
                var recordToUpate = await _context.Categories.FindAsync(id);
                if (recordToUpate == null) throw new Exception("Record for Deleteupdate is not found");
                recordToUpate.CategoryName = entity.CategoryName;
                recordToUpate.BasePrice = entity.BasePrice;

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
