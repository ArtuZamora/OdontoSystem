using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Agenda> Agenda{ get; set; }
        public DbSet<AppointmentHistory> AppointmentHistory { get; set; }
        public DbSet<Constraints> Constraints { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<Odontogram> Odontogram{ get; set; }
        public DbSet<OrthodonticPatientRecord> OrthodonticPatientRecord { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientHistory> PatientHistory { get; set; }
        public DbSet<PatientRecord> PatientRecord { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Treatment> Treatment { get; set; }

   
    }
}
