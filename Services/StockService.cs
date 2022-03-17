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
        private readonly IMongoCollection<StockChemical> _stockCollection;
        
        public StockService(
            IOptions<ChemicalStoreDatabaseSettings> chemicalsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                chemicalsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                chemicalsDatabaseSettings.Value.DatabaseName);

            _stockCollection = mongoDatabase.GetCollection<StockChemical>(
                chemicalsDatabaseSettings.Value.StockCollectionName);
        }
        
        public async Task<List<StockChemical>> GetAsync() =>
            await _stockCollection.Find(_ => true).ToListAsync();
        
        public async Task<StockChemical?> GetAsync(string id) =>
            await _stockCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateAsync(StockChemical stockChemical) =>
            await _stockCollection.InsertOneAsync(stockChemical);

        public async Task UpdateAsync(string id, StockChemical updatedChemical) =>
            await _stockCollection.ReplaceOneAsync(x => x.Id == id, updatedChemical);

        public async Task RemoveAsync(string id) =>
            await _stockCollection.DeleteOneAsync(x => x.Id == id);
    }
}