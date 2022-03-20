using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.chemical_handler.Models;
using rischy.chemical_handler.Services;

namespace rischy.chemical_handler.Controllers
{
    [ApiController]
    public class HazardController : Controller
    {
        private readonly ChemicalService _chemicalService;
        public HazardController(ChemicalService chemicalService) => _chemicalService = chemicalService;
        
        [Route("/all-hazards")]
        [HttpGet]
        public async Task<List<ChemicalHazard>> GetHazards() => await _chemicalService.GetHazardAsync();
        
        [Route("/hazards")]
        [HttpPost]
        public string PostHazards()
        {
            return "Adding Chemical data";
        }
        
        [Route("/hazards")]
        [HttpGet]
        public async Task<IEnumerable<ChemicalHazard?>> GetHazardsById(string ids)
        {
            var listOfIds = ids.Split(",").ToList();
            return await FetchChemicalHazards(listOfIds);
        }
        
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
    }
}