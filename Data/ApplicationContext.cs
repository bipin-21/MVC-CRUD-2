using Microsoft.EntityFrameworkCore;
using MVCCRUD2.Models;

namespace MVCCRUD2.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmpSkill> EmpSkills { get; set; }
    }
}
