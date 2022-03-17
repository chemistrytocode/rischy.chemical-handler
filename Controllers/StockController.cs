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
        
        // Constructor
        public StockController(ChemicalService chemicalService) => _chemicalService = chemicalService;
        
        [HttpGet(Name = "GetStock")]
        public async Task<List<StockChemical>> GetStock() => await _chemicalService.GetStockAsync();
        
        [HttpPost(Name = "AddStock")]
        public string Post()
        {
            return "Adding Stock";
        }
    }
}