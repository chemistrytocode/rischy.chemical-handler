using System.Collections.Generic;

namespace rischy.chemical_handler.Models
{
    public record ChemicalHazard : Chemical
    {
        public IEnumerable<string>? Hazard { get; set; }

        public string? Comment { get; set; }

        public ControlMeasures? ControlMeasures { get; set; }
    }
}