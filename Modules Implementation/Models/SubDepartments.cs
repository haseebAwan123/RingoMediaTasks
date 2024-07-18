using System.ComponentModel.DataAnnotations;

namespace Modules_Implementation.Models
{
    public class SubDepartments 
    {
        [Key]
        public int SubDepartmentID { get; set; }
        public int DepartmentID { get; set; }
        public string SubDepartmentName { get; set; }
        public string? SubDepartmentLogo { get; set; }

        // Navigation property for parent department
        public virtual Departments? Department { get; set; }
    }
}
