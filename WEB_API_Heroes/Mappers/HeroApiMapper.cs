using ASP_MVC_03_Modele.BLL.DTO;
using WEB_API_Heroes.Models;

namespace WEB_API_Heroes.Mappers
{
    public static class HeroApiMapper
    {
        public static HeroApiModel ToApi(this HeroDTO hero)
        {
            return new HeroApiModel()
            { 
               IdHero = hero.IdHero,
                Endurance=hero.Endurance,
                 Name=hero.Name,
                  Strength=hero.Strength
            };
        }

        public static HeroDTO ToDto(this HeroApiModel hero)
        {
            return new HeroDTO()
            {
                IdHero = hero.IdHero,
                Endurance = hero.Endurance,
                Name = hero.Name,
                Strength = hero.Strength
            };
        }
    }
}
