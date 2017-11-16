using Microsoft.EntityFrameworkCore;
using PatientBook.Model.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DAL.DBContext
{
    public class PatientDbContext : Common.BaseDbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patient");
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Patient> Patients { get; set; }


    }
}
