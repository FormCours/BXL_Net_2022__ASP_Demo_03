using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_Heroes.Mappers;
using WEB_API_Heroes.Models;
namespace WEB_API_Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        IHeroService _service;
        public HeroesController(IHeroService service)
        {
            this._service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
             //renvoie une 200 + json

            return Ok(_service.GetAll().ToArray());
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetByName(string name)
        {
            //renvoie une 200 + json

            return Ok(_service.GetByName(name).Select(m => m.ToApi()));
        }

        [HttpGet()]
        [Route("{endurance:min(1)}")]
        public IActionResult GetByEndurance(int endurance)
        {
            //renvoie une 200 + json

            return Ok(_service.GetByEndurance(endurance).Select(m => m.ToApi()));
        }

        [HttpPost]
        public IActionResult AddHero(HeroApiModel monHero)
        {
            if(_service.Insert(monHero.ToDto()))
            {
                return new CreatedResult("/api/Heroes", monHero);
            }
            else
            {
                return new BadRequestObjectResult(monHero);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult ModifyHero(int id,HeroApiModel monHero)
        { 
             if(monHero.Endurance<450) return new BadRequestObjectResult(new { Hero = monHero, Reason = "Le héro doit avoir plus de 450 d'endurance" });

            //1- vérification
            if (id!=monHero.IdHero)
            {
                return new BadRequestObjectResult(new { Hero = monHero, Reason="Les ids ne correspondent pas" });
            }
            HeroApiModel FromDb = _service.GetById(id).ToApi();
            if(FromDb == null)
            {
                return new BadRequestObjectResult(new { Hero = monHero, Reason = "Le héro n'existe pas" });
            }

           if(_service.Update(id, monHero.ToDto()))
            {
                return NoContent();
            }
            else
            {
                return new BadRequestObjectResult(monHero);
            }

        }
    }
}
