using EmployeeManagementSystem.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IMongoCollection<Employee> employees;

        public EmployeeService(IEmployeeDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            employees = database.GetCollection<Employee>(settings.EmployeeCollection);
        }

        public Employee Create(Employee employee)
        {

            employees.InsertOne(employee);
            return employee;
        }

        public List<Employee> Get()
        {
            return employees.Find(employee => true).ToList();
        }

        public Employee Get(int id)
        {
            return employees.Find(employee => employee.employeeId == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            employees.DeleteOne(employee => employee.employeeId == id);           
        }

        public void Update(int id, Employee employee)
        {
            var filter = Builders<Employee>.Filter.Eq(emp => emp.employeeId, id);

            var update = Builders<Employee>.Update
                .Set(emp => emp.firstName, employee.firstName)
                .Set(emp => emp.lastName, employee.lastName)
                .Set(emp => emp.dateOfBirth, employee.dateOfBirth)
                .Set(emp => emp.salary, employee.salary)
                .Set(emp => emp.paymentStatus, employee.paymentStatus)
                .Set(emp => emp.departmentId, employee.departmentId)
                .Set(emp => emp.roleId, employee.roleId)
                .Set(emp => emp.assetId, employee.assetId);

           employees.UpdateOne(filter, update);
           
        }
    }
}
