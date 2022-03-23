using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.chemical_handler.Models;
using rischy.chemical_handler.Services;

namespace rischy.chemical_handler.Controllers
{
    [ApiController]
    [Route("/hazards")]
    public class HazardController : Controller
    {
        private readonly ChemicalService _chemicalService;
        public HazardController(ChemicalService chemicalService) => _chemicalService = chemicalService;

        private async Task<IEnumerable<ChemicalHazard?>> FetchChemicalHazards(IEnumerable<string> ids)
        {
            var getAllChemicalsFromIds = await Task.Run(() => 
                ids.Select(async id => await FetchChemicalFromId(id))
                    .ToList());

            await Task.WhenAll(getAllChemicalsFromIds);
            var filteredChemicalTaskResults = getAllChemicalsFromIds.Select(task => task.Result);
        
            return filteredChemicalTaskResults;
        }
    
        private async Task<ChemicalHazard?> FetchChemicalFromId(string id) => await _chemicalService.GetHazardAsync(id);
        
        [HttpGet(Name="GetHazardsById")]
        // Example: /hazards?id=123,456,789
        public async Task<IEnumerable<ChemicalHazard?>> GetHazardsById(string ids)
        {
            var listOfIds = ids.Split(",").ToList();
            return await FetchChemicalHazards(listOfIds);
        }

        [HttpPost(Name="AddHazard")]
        public async Task PostStock(ChemicalHazard chemicalHazard) => await _chemicalService.CreateHazardAsync(chemicalHazard);
        
        [Route("/all-hazards")]
        [HttpGet(Name="GetAllHazards")]
        public async Task<List<ChemicalHazard>> GetAllHazards() => await _chemicalService.GetHazardAsync();
    }
}