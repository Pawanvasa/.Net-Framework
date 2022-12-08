using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Code_First_Copy.Models
{
    public class InfoDbContext :DbContext
    {
        public InfoDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=CodiCodingFirstCopy;Integrated Security=SSPI;MultipleActiveResultSets=true");

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }

}
