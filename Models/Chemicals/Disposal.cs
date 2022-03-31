using System.Collections.Generic;

namespace rischy.chemical_handler.Models
{
    public record Disposal
    {
        public IEnumerable<string> Codes { get; set; }
        
        public string? Instructions { get; set; }
    }
}