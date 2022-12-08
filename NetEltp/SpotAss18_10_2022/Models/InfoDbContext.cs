using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotAss18_10_2022.Models
{
    public class InfoDbContext : DbContext
    {
        public InfoDbContext()
        {

        }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Doctor> doctor { get; set; }
        public DbSet<Nurse> nurse { get; set; }
        public DbSet<WardBoy> wardBoy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data SOurce=PVASA-LAP-0703\\MSSQLSERVER01;Initial Catalog=HopitalManagement; Integrated Security=SSPI;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var doctor = new Doctor[]
            {
               new Doctor(){ StaffId=1,StaffName="Pawan",StaffCategory="Doctor",Contact="84652",NumberOperations=4,
                PatientsDaigonised=5 },
                new Doctor(){ StaffId=2,StaffName="Mohan",StaffCategory="Doctor",Contact="7372",NumberOperations=3,
                PatientsDaigonised=2 }
            };

            var nurse = new Nurse[]
            {
                new Nurse()
                {
                    StaffId=3,StaffName="Rani",StaffCategory="Nurse",Contact="7453",NumberOfInjections=34,NumberOfPatientsMonitored=4
                },
                 new Nurse()
                {
                    StaffId=4,StaffName="Jammy",StaffCategory="Nurse",Contact="7462",NumberOfInjections=5,NumberOfPatientsMonitored=7
                }
            };

            var wardBoy = new WardBoy[]
            {
                 new WardBoy()
                 {
                    StaffId=5,StaffName="Amar",StaffCategory="WardBoy",Contact="7453", NumberRoomsCleaned=5
                 },
                  new WardBoy()
                 {
                    StaffId=6,StaffName="Bam",StaffCategory="WardBoy",Contact="3464", NumberRoomsCleaned=8
                 }
            };

            var staff = doctor.Cast<Staff>()
                .Union(nurse).Union(wardBoy).ToList();

            modelBuilder.Entity<Doctor>().HasData(doctor);
            modelBuilder.Entity<Nurse>().HasData(nurse);
            modelBuilder.Entity<WardBoy>().HasData(wardBoy);

            base.OnModelCreating(modelBuilder);
        }
    }
}
