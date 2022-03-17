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
        public async Task<List<StockChemical>> GetStockAsync() => await _stockService.GetAsync();
        public async Task<StockChemical?> GetStockAsync(string id) => await _stockService.GetAsync(id);
        public async Task CreateStockAsync(StockChemical stockChemical) => await _stockService.CreateAsync(stockChemical);
        public async Task UpdateStockAsync(string id, StockChemical updatedChemical) => await _stockService.UpdateAsync(id, updatedChemical);
        public async Task RemoveStockAsync(string id) => await _stockService.RemoveAsync(id);
        
        
        // Hazard Service
        public async Task<List<HazardChemical>> GetHazardAsync() => await _hazardService.GetAsync();
        public async Task<HazardChemical?> GetHazardAsync(string id) => await _hazardService.GetAsync(id);
        public async Task CreateHazardAsync(HazardChemical stockChemical) => await _hazardService.CreateAsync(stockChemical);
        public async Task UpdateHazardAsync(string id, HazardChemical updatedChemical) => await _hazardService.UpdateAsync(id, updatedChemical);
        public async Task RemoveHazardAsync(string id) => await _hazardService.RemoveAsync(id);
    }
}