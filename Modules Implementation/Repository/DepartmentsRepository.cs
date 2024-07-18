using Microsoft.EntityFrameworkCore;
using Modules_Implementation.Context;
using Modules_Implementation.Models;
using Modules_Implementation.ViewModels;

namespace Modules_Implementation.Repository
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddDepartmentAsync(DepartmentViewModel viewModel)
        {
            if (viewModel != null)
            {
                Departments department = new Departments();
                department.ParentDepartmentID = viewModel.ParentDepartmentID;
                department.DepartmentName = viewModel.DepartmentName;
                department.DepartmentLogo = viewModel.DepartmentLogo;
                await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();

                if (viewModel.SubDepartments != null)
                {
                    foreach (var item in viewModel.SubDepartments)
                    {
                        SubDepartments subDepartments = new SubDepartments
                        {
                            SubDepartmentName = item.SubDepartmentName,
                            SubDepartmentLogo = item.SubDepartmentLogo,
                            DepartmentID = department.DepartmentID // Assign parent department ID
                        };
                        await _context.SubDepartments.AddAsync(subDepartments);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            _context.SaveChanges();
        }
        public async Task UpdateDepartmentAsync(DepartmentViewModel viewModel)
        {
            if (viewModel != null)
            {
                Departments department = new Departments();
                department.DepartmentID = viewModel.DepartmentID;
                department.ParentDepartmentID = viewModel.ParentDepartmentID;
                department.DepartmentName = viewModel.DepartmentName;
                department.DepartmentLogo = viewModel.DepartmentLogo;
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();

                if (viewModel.SubDepartments != null)
                {
                    foreach (var item in viewModel.SubDepartments)
                    {
                        if (_context.SubDepartments.Any(x=>x.SubDepartmentID == item.SubDepartmentID))
                        {
                            SubDepartments subDepartments = new SubDepartments
                            {
                               SubDepartmentID = item.SubDepartmentID,
                                SubDepartmentName = item.SubDepartmentName,
                                SubDepartmentLogo = item.SubDepartmentLogo,
                                DepartmentID = department.DepartmentID // Assign parent department ID
                            };
                             _context.SubDepartments.Update(subDepartments);
                        }
                        else
                        {
                            SubDepartments subDepartments = new SubDepartments
                            {
                                SubDepartmentName = item.SubDepartmentName,
                                SubDepartmentLogo = item.SubDepartmentLogo,
                                DepartmentID = department.DepartmentID // Assign parent department ID
                            };
                            await _context.SubDepartments.AddAsync(subDepartments);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }
           
           _context.SaveChanges();
        }
        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.Where(x => x.DepartmentID == id).FirstOrDefaultAsync();
           _context.Departments.Remove(department);

            var Subdepartment = await _context.SubDepartments.Where(x => x.DepartmentID == id).FirstOrDefaultAsync();
            if (Subdepartment != null)
            {
                _context.SubDepartments.Remove(Subdepartment);
            }
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Departments>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments;
        }

        public async Task<DepartmentViewModel> GetDepartmentByIdAsync(int id)
        {
           var query = _context.Departments
                             .Include(d => d.SubDepartments)
                             .Where(d => d.DepartmentID == id)
                             .Select(d => new DepartmentViewModel
                             {
                                 DepartmentID = d.DepartmentID,
                                 DepartmentName= d.DepartmentName,
                                 ParentDepartment = d.ParentDepartmentID != null ? d.ParentDepartment.DepartmentName : null,
                                 DepartmentLogo=  d.DepartmentLogo,
                                 ParentDepartmentID=  d.ParentDepartmentID,
                                 
                             });

            DepartmentViewModel viewModel = await query.FirstOrDefaultAsync();

            viewModel.SubDepartments = await _context.SubDepartments.Where(x => x.DepartmentID == viewModel.DepartmentID).Select(subDepartment => new SubDepartmentViewModel
            {
                SubDepartmentID = subDepartment.SubDepartmentID,
                DepartmentID = subDepartment.DepartmentID,
                SubDepartmentName = subDepartment.SubDepartmentName,
                SubDepartmentLogo = subDepartment.SubDepartmentLogo
            }).ToListAsync();



            return viewModel;
        }

        public async Task<IEnumerable<Departments>> GetParentDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
