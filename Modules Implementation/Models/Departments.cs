using System.ComponentModel.DataAnnotations;

namespace Modules_Implementation.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }
        public int? ParentDepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string? DepartmentLogo { get; set; }

        // Navigation property for parent department
        public virtual Departments ParentDepartment { get; set; }
        // Collection navigation property for sub-departments
        public virtual ICollection<SubDepartments> SubDepartments { get; set; }
    }
}
