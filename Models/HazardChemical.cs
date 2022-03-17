using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rischy.chemical_handler.Models
{
    public record HazardChemical
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string? Name { get; set; }

        public IEnumerable<string>? Hazard { get; set; }

        public string? Comment { get; set; }

        public ControlMeasures? ControlMeasures { get; set; }
    }
}