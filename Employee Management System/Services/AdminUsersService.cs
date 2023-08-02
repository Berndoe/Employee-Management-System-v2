using EmployeeManagementSystem.Models;
using MongoDB.Driver;

namespace EmployeeManagementSystem.Services
{
    public class AdminUsersService: IAdminUsersService
    {
        private readonly IMongoCollection<AdminUsers> admins;

        public AdminUsersService(IEmployeeDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            admins = database.GetCollection<AdminUsers>(settings.AdminCollection);
        }

        public AdminUsers Create(AdminUsers user)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.password);

            user.password = hashedPassword;
                       
            admins.InsertOne(user);
            return user;
        }

        public List<AdminUsers> Get()
        {
            return admins.Find(user => true).ToList();
        }

        public AdminUsers Get(string id)
        {
            return admins.Find(user => user.userId.Equals(id)).FirstOrDefault();
        }

        public void Remove(string id)
        {
            admins.DeleteOne(user => user.userId == id);
        }

        public void Update(string id, AdminUsers user)
        {
            var filter = Builders<AdminUsers>.Filter.Eq(u => u.userId, id);

            var update = Builders<AdminUsers>.Update
                .Set(u => u.firstName, user.firstName)
                .Set(u => u.lastName, user.lastName)
                .Set(u => u.email, user.email)
                .Set(u => u.password, user.password);
            
            admins.UpdateOne(filter, update);
        }
    }
}
