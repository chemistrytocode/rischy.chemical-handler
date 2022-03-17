using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rischy.chemical_handler.Models;
using rischy.chemical_handler.MongoDB;

namespace rischy.chemical_handler.Services
{
    public class StockService
    {
        private readonly IMongoCollection<ChemicalStock> _stockCollection;
        
        public StockService(
            IOptions<ChemicalsDatabaseSettings> chemicalsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                chemicalsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                chemicalsDatabaseSettings.Value.DatabaseName);

            _stockCollection = mongoDatabase.GetCollection<ChemicalStock>(
                chemicalsDatabaseSettings.Value.StockCollectionName);
        }
        
        public async Task<List<ChemicalStock>> GetAsync() =>
            await _stockCollection.Find(_ => true).ToListAsync();

        public async Task<ChemicalStock?> GetAsync(string id) =>
            await _stockCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateAsync(ChemicalStock chemicalStock) =>
            await _stockCollection.InsertOneAsync(chemicalStock);

        public async Task UpdateAsync(string id, ChemicalStock updated) =>
            await _stockCollection.ReplaceOneAsync(x => x.Id == id, updated);

        public async Task RemoveAsync(string id) =>
            await _stockCollection.DeleteOneAsync(x => x.Id == id);
    }
}