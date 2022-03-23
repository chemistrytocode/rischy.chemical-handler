using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rischy.chemical_handler.Helpers;
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
        
        [HttpGet(Name="GetHazardsById")]
        public async Task<IEnumerable<ChemicalHazard?>> GetHazardsById(string ids)
        {
            var base64DecryptedIds = ids.DecodeBase64();
            var listOfIds = base64DecryptedIds.Split(",").ToList();
            return await FetchChemicalHazards(listOfIds);
        }

        [HttpPost(Name="AddHazard")]
        public async Task PostHazard(ChemicalHazard chemicalHazard) => await _chemicalService.CreateHazardAsync(chemicalHazard);
        
        [HttpPut(Name = "UpdateHazard")]
        public async Task PutHazard(string id, ChemicalHazard chemicalHazard) => await _chemicalService.UpdateHazardAsync(id, chemicalHazard);

        [HttpDelete(Name = "DeleteHazard")]
        public async Task DeleteHazard(string id) => await _chemicalService.RemoveHazardAsync(id);
        
        // HazardController Helper Methods
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