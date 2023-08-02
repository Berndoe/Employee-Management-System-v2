using EmployeeManagementSystem.Models;
using MongoDB.Driver;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IMongoCollection<Department> departments;

        public DepartmentService(IEmployeeDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            departments = database.GetCollection<Department>(settings.DepartmentCollection);
        }

        public Department Create(Department department)
        {
            departments.InsertOne(department);
            return department;
        }

        public List<Department> Get()
        {
            return departments.Find(department => true).ToList();
        }

        public Department Get(int id)
        {
            return departments.Find(department => department.departmentId == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            departments.DeleteOne(department => department.departmentId == id);
        }

        public void Update(int id, Department department)
        {
            var filter = Builders<Department>.Filter.Eq(dep => dep.departmentId, id);

            var update = Builders<Department>.Update
                .Set(dep => dep.departmentName, department.departmentName);

            departments.UpdateOne(filter, update);

        }
    }
}
