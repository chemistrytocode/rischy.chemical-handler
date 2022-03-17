using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rischy.chemical_handler.Models;
using rischy.chemical_handler.MongoDB;

namespace rischy.chemical_handler.Services
{
    public class ChemicalService
    {
        private readonly StockService _stockService;
        private readonly HazardService _hazardService;

        public ChemicalService(
            IOptions<ChemicalStoreDatabaseSettings> chemicalsDatabaseSettings)
        {
            _stockService = new StockService(chemicalsDatabaseSettings);
            _hazardService = new HazardService(chemicalsDatabaseSettings);
        }

        // Stock Service
        public async Task<List<ChemicalStock>> GetStockAsync() => await _stockService.GetAsync();
        public async Task<ChemicalStock?> GetStockAsync(string id) => await _stockService.GetAsync(id);
        public async Task CreateStockAsync(ChemicalStock chemicalStock) => await _stockService.CreateAsync(chemicalStock);
        public async Task UpdateStockAsync(string id, ChemicalStock updated) => await _stockService.UpdateAsync(id, updated);
        public async Task RemoveStockAsync(string id) => await _stockService.RemoveAsync(id);
        
        // Hazard Service
        public async Task<List<ChemicalHazard>> GetHazardAsync() => await _hazardService.GetAsync();
        public async Task<ChemicalHazard?> GetHazardAsync(string id) => await _hazardService.GetAsync(id);
        public async Task CreateHazardAsync(ChemicalHazard stock) => await _hazardService.CreateAsync(stock);
        public async Task UpdateHazardAsync(string id, ChemicalHazard updated) => await _hazardService.UpdateAsync(id, updated);
        public async Task RemoveHazardAsync(string id) => await _hazardService.RemoveAsync(id);
    }
}