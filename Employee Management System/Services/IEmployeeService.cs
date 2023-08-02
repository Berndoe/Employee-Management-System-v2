using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public interface IEmployeeService
    {
        List<Employee> Get();
        Employee Get(int id);
        Employee Create(Employee employee);
        void Update(int id, Employee employeee);
        void Remove(int id);
    }
}
