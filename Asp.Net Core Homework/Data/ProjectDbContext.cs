using Asp.Net_Core_Homework.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_Core_Homework.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
