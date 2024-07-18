using Modules_Implementation.Models;
using System.ComponentModel.DataAnnotations;

namespace Modules_Implementation.ViewModels
{
    public class DepartmentViewModel
    {
        [Key]
        public int DepartmentID { get; set; }
        public int? ParentDepartmentID { get; set; }
        public string? ParentDepartment { get; set; }
        public string DepartmentName { get; set; }
        public string? DepartmentLogo { get; set; }
        public List<SubDepartmentViewModel> SubDepartments { get; set; } = new List<SubDepartmentViewModel>();

    }
    public class SubDepartmentViewModel
    {
        [Key]
        public int SubDepartmentID { get; set; }
        public int DepartmentID { get; set; }
        public string SubDepartmentName { get; set; }
        public string? SubDepartmentLogo { get; set; }
    }
    public class DepartmentsDetailsViewModel
    {
        public int DepartmentID { get; set; }
        public string ParentDepartment { get; set; }
        public string? Department { get; set; }
        public string? SubDepartment { get; set; }
    }
}
