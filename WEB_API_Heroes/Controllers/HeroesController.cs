using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_Heroes.Mappers;

namespace WEB_API_Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        HeroService _repo;
        public HeroesController(HeroService repo)
        {
            this._repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
             //renvoie une 200 + json

            return Ok(_repo.GetAll().ToArray());
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetByName(string name)
        {
            //renvoie une 200 + json

            return Ok(_repo.GetByName(name).Select(m => m.ToApi()));
        }

        [HttpGet()]
        [Route("{endurance:min(1)}")]
        public IActionResult GetByEndurance(int endurance)
        {
            //renvoie une 200 + json

            return Ok(_repo.GetByEndurance(endurance).Select(m => m.ToApi()));
        }

        [HttpPost]
        public IActionResult AddHero(WEB_API_Heroes.Models.HeroApiModel monHero)
        {
            if(_repo.Insert(monHero.ToDto()))
            {
                return Ok(monHero);
            }
            else
            {
                return new BadRequestObjectResult(monHero);
            }
        }
    }
}
