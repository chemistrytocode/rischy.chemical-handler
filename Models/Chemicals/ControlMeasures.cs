namespace rischy.chemical_handler.Models
{
    public record ControlMeasures
    {
        public bool? Goggles { get; set; }
        public bool? Gloves { get; set; }
        public bool? FumeCupboard { get; set; }
        public bool? AvoidFlames { get; set; }
    }
}