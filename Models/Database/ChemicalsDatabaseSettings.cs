namespace rischy.chemical_handler.MongoDB
{
    public record ChemicalsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string StockCollectionName { get; set; } = null!;

        public string HazardCollectionName { get; set; } = null!;
    }
}