using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public interface IRoleService
    {
        List<Role> Get();
        Role Get(string id);
        Role Create(Role role);
        void Update(string id, Role role);
        void Remove(string id);

    }
}
