namespace rischy.chemical_handler.Models
{
    public record ChemicalStock : Chemical
    {
        public int? StockLevel { get; set; }
        public int? MaxHeld { get; set; }
        public bool ConsultationRequired { get; set; } = false;
        public string Hazard_Id { get; set; }
    }
}