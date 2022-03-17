using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rischy.chemical_handler.Models
{
    public record Chemical
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? State { get; set; }
    }
}