using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rischy.chemical_handler.Models
{
    public record StockChemical
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }

        public int? StockLevel { get; set; }

        public int? MaxHeld { get; set; }

        public bool ConsultationRequired { get; set; } = false;
    }
}