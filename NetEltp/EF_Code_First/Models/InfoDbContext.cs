using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First.Models
{
    public class InfoDbContext :DbContext
    {
        public InfoDbContext()
        {

        }

        public DbSet<Person> Persons { get; set; }
        /// <summary>
        /// This method will having connection with database
        /// DbContextBuilder : the class that uses an extension method
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=CodiCodingFirst;Integrated Security=SSPI;MultipleActiveResultSets=true");
            //base.OnConfiguring(optionsBuilder);
        }
       
        /// <summary>
        /// the method that will contains code for relations (if any)
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
