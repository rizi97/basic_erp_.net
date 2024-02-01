using HMS_ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS_ERP.Data
{
    public class HmsErpContext : DbContext
    {
        public HmsErpContext(DbContextOptions<HmsErpContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<RoomAllocate> RoomAllocate { get; set; }
    }
}
