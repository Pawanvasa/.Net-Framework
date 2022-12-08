using DapperExample.Constants;
using DapperExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DapperExample.DbConnect.EShoppingCodiContext;
using Dapper;
using Microsoft.Data.SqlClient;
namespace DapperExample.DataAccessServices
{
    public class EmployeeDataAccess
    {
        EShopingCodiContext _context = null;
        public EmployeeDataAccess()
        {
            _context = new EShopingCodiContext();
        }
        public async Task<List<Employee>> GetAsyncEmp()
        {
            try
            {
                var queryEmp = StaticConstants.SelectQueryEmp;
                var resultEmp = await _context.CreateConnection()
                           .QueryAsync<Employee>(queryEmp);
                return resultEmp.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
