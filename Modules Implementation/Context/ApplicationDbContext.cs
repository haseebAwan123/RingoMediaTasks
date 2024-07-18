using Microsoft.EntityFrameworkCore;
using Modules_Implementation.Models;
using Modules_Implementation.ViewModels;

namespace Modules_Implementation.Context
{
    public class ApplicationDbContext: DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<SubDepartments> SubDepartments { get; set; }
        public virtual DbSet<Reminders> Reminders { get; set; }
        //public DbSet<Modules_Implementation.ViewModels.DepartmentViewModel>? DepartmentViewModel { get; set; }
    }
}
