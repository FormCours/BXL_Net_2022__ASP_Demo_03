using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.Models;
using ASP_MVC_03_Modele.Models.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_03_Modele.Controllers
{
    public class BiomeController : Controller
    {
        private BiomeService biomeService;

        public BiomeController(BiomeService biomeService)
        {
            this.biomeService = biomeService;   
        }

        public IActionResult Index()
        {
            IEnumerable<Biome> biomes = biomeService.GetAll()
                                                    .Select(b => b.ToModel())
                                                    .OrderBy(b => b.Name);

            return View(biomes);
        }
    }
}
