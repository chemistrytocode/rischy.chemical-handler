using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.chemical_handler.Models;
using rischy.chemical_handler.Services;

namespace rischy.chemical_handler.Controllers
{
    [ApiController]
    [Route("/stock")]
    public class StockController : Controller
    {
        private readonly ChemicalService _chemicalService;
        public StockController(ChemicalService chemicalService) => _chemicalService = chemicalService;
        
        [HttpGet(Name = "GetStock")]
        public async Task<List<ChemicalStock>> GetStock() => await _chemicalService.GetStockAsync();
        
        [HttpPost(Name = "AddStock")]
        public async Task PostStock(ChemicalStock chemicalStock) => await _chemicalService.CreateStockAsync(chemicalStock);
        
        [HttpPut(Name = "UpdateStock")]
        public async Task PutStock(string id, ChemicalStock chemicalStock) => await _chemicalService.UpdateStockAsync(id, chemicalStock);

        [HttpDelete(Name = "DeleteStock")]
        public async Task DeleteStock(string id) => await _chemicalService.RemoveStockAsync(id);
    }
}