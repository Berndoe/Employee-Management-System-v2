using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeManagementSystem.Models
{


    public class Department
    {
        [BsonId] // to make mongo db take the employee id as the document id
        [BsonRepresentation(BsonType.Int64)]
        public int departmentId { get; set; }

        [BsonElement("departmentName")] // mongo db will use this name as the attribute name
        public string departmentName { get; set; } = String.Empty;

        [BsonElement("roles")]
        public ICollection<Role> roles { get; set; }
     
    }
}
