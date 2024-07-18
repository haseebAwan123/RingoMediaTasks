using Modules_Implementation.Models;
using Modules_Implementation.ViewModels;

namespace Modules_Implementation.Repository
{
    public interface IDepartmentsRepository
    {
        Task AddDepartmentAsync(DepartmentViewModel viewModel);
        Task UpdateDepartmentAsync(DepartmentViewModel viewModel);
        Task DeleteDepartmentAsync(int id);
        Task<IEnumerable<Departments>> GetAllDepartmentsAsync();
        Task<DepartmentViewModel> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<Departments>> GetParentDepartmentsAsync();
       

     
    }
}
