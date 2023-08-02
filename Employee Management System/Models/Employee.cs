using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeManagementSystem.Models
{


    public class Employee
    {
        [BsonId] // to make mongo db take the employee id as the document id
        [BsonRepresentation(BsonType.Int64)]
        public int employeeId { get; set; }

        [BsonElement("firstName")] // mongo db will use this name as the attribute name
        public string firstName { get; set; } = String.Empty;

        [BsonElement("lastName")]
        public string lastName { get; set; } = String.Empty;

        [BsonElement("birthday")]
        public string dateOfBirth { get; set; } = String.Empty;

        [BsonElement("salary")]
        public double salary { get; set; }

        [BsonElement("paymentStatus")]
        public string paymentStatus { get; set; } = String.Empty;

        [BsonElement("departmentId")]
        public int departmentId { get; set; } 

        [BsonElement("roleId")]
        public string roleId { get; set; }

        [BsonElement("assetId")]
        public int assetId { get; set; }        
    }
}
