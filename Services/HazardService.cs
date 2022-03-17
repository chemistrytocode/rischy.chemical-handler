using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rischy.chemical_handler.Models;
using rischy.chemical_handler.MongoDB;

namespace rischy.chemical_handler.Services
{
    public class HazardService
    {
        private readonly IMongoCollection<ChemicalHazard> _hazardCollection;
        
        public HazardService(
            IOptions<ChemicalStoreDatabaseSettings> chemicalsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                chemicalsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                chemicalsDatabaseSettings.Value.DatabaseName);

            _hazardCollection = mongoDatabase.GetCollection<ChemicalHazard>(
                chemicalsDatabaseSettings.Value.HazardCollectionName);
        }
        
        public async Task<List<ChemicalHazard>> GetAsync() =>
            await _hazardCollection.Find(_ => true).ToListAsync();
        
        public async Task<ChemicalHazard?> GetAsync(string id) =>
            await _hazardCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateAsync(ChemicalHazard chemicalHazard) =>
            await _hazardCollection.InsertOneAsync(chemicalHazard);

        public async Task UpdateAsync(string id, ChemicalHazard updated) =>
            await _hazardCollection.ReplaceOneAsync(x => x.Id == id, updated);

        public async Task RemoveAsync(string id) =>
            await _hazardCollection.DeleteOneAsync(x => x.Id == id);
    }
}