using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeManagementSystem.Models
{


    public class Role
    {
        [BsonId] // to make mongo db take the employee id as the document id
        [BsonRepresentation(BsonType.String)]
        public string roleId { get; set; } 

        [BsonElement("roleName")] // mongo db will use this name as the attribute name
        public string roleName { get; set; } = String.Empty;
       
    }
}
