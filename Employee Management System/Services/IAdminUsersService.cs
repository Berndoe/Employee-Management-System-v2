using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public interface IAdminUsersService { 
    List<AdminUsers> Get();
    AdminUsers Get(string id);
    AdminUsers Create(AdminUsers user);
    void Update(string id, AdminUsers user);
    void Remove(string id);

    }
}
