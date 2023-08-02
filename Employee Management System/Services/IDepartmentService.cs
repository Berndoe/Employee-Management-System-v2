using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public interface IDepartmentService
    {
        List<Department> Get();
        Department Get(int id);
        Department Create(Department department);
        void Update(int id, Department department);
        void Remove(int id);
    }
}
