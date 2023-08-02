using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeManagementSystem.Models
{


    public class Asset
    {
        [BsonId] // to make mongo db take the employee id as the document id
        [BsonRepresentation(BsonType.Int64)]
        public int assetId { get; set; }

        [BsonElement("assetName")] // mongo db will use this name as the attribute name
        public string assetName { get; set; } = String.Empty;
    }
}
