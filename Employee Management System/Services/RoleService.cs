using EmployeeManagementSystem.Models;
using MongoDB.Driver;

namespace EmployeeManagementSystem.Services
{
    public class RoleService: IRoleService
    {
        
            private readonly IMongoCollection<Role> roles;

            public RoleService(IEmployeeDatabaseSettings settings, IMongoClient mongoClient)
            {
                var database = mongoClient.GetDatabase(settings.DatabaseName);
                roles = database.GetCollection<Role>(settings.RoleCollection);
            }

            public Role Create(Role role)
            {
                roles.InsertOne(role);
                return role;
            }

            public List<Role> Get()
            {
                return roles.Find(role => true).ToList();
            }


            public Role Get(string id)
            {
                return roles.Find(role => role.roleId == id).FirstOrDefault();
            }

            public void Remove(string id)
            {
                roles.DeleteOne(role => role.roleId == id);
            }

            public void Update(string id, Role role)
            {
                var filter = Builders<Role>.Filter.Eq(r => r.roleId, id);

                var update = Builders<Role>.Update
                    .Set(r => r.roleName, role.roleName);

                roles.UpdateOne(filter, update);

            }
    }
}

