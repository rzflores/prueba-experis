using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DTO;
using PruebaTecnica.Problema3;

namespace PruebaTecnica.Controllers
{
    public class ProblemaController : Controller
    {
        [HttpGet("{Amount}")]
        public async Task<ActionResult> generateCombinations(string Amount)
        {
            try
            {

                List<List<decimal>> result = MoneyParts.Build(Amount);
                
                return StatusCode(200, result.Select(combination => $"[{string.Join(", ", combination)}]"));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


    }
}
