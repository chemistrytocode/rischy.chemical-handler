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
        private readonly IMongoCollection<HazardChemical> _hazardCollection;
        
        public HazardService(
            IOptions<ChemicalStoreDatabaseSettings> chemicalsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                chemicalsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                chemicalsDatabaseSettings.Value.DatabaseName);

            _hazardCollection = mongoDatabase.GetCollection<HazardChemical>(
                chemicalsDatabaseSettings.Value.HazardCollectionName);
        }
        
        public async Task<List<HazardChemical>> GetAsync() =>
            await _hazardCollection.Find(_ => true).ToListAsync();
        
        public async Task<HazardChemical?> GetAsync(string id) =>
            await _hazardCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task CreateAsync(HazardChemical hazardChemical) =>
            await _hazardCollection.InsertOneAsync(hazardChemical);

        public async Task UpdateAsync(string id, HazardChemical updatedChemical) =>
            await _hazardCollection.ReplaceOneAsync(x => x.Id == id, updatedChemical);

        public async Task RemoveAsync(string id) =>
            await _hazardCollection.DeleteOneAsync(x => x.Id == id);
    }
}