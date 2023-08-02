using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeManagementSystem.Models
{

    public class AdminUsers
    {
        [BsonId] // to make mongo db take the employee id as the document id
        [BsonRepresentation(BsonType.ObjectId)]
        public string userId { get; set; } = String.Empty;

        [BsonElement("firstName")] // mongo db will use this name as the attribute name
        public string firstName { get; set; } = String.Empty;

        [BsonElement("lastName")]
        public string lastName { get; set; } = String.Empty;

        [BsonElement("email")]
        public string email { get; set; } = String.Empty;

        [BsonElement("password")]
        public string password { get; set; } = String.Empty;

        [BsonElement("passwordSalt")]
        public string passwordSalt { get; set; } = String.Empty;

    }
}
