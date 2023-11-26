using EasyMeds.WebAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyMeds.WebAPI.Core.Contexts;

public class EasyMedsDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<MedicationLog> MedicationLogs { get; set; }

    public EasyMedsDbContext(DbContextOptions<EasyMedsDbContext> options)  : base(options) {}
}