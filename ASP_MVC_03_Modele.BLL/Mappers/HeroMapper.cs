using ASP_MVC_03_Modele.BLL.DTO;
using ASP_MVC_03_Modele.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.BLL.Mappers
{
    public static class HeroMapper
    {
        public static HeroDTO ToDTO(this HeroEntity entity)
        {
            return new HeroDTO()
            {
               IdHero = entity.IdHero,
               Endurance = entity.Endurance,
               IdRace=entity.IdRace,
               Name= entity.Name,
               Strength=entity.Strength
            };
        }

        public static HeroEntity ToEntity(this HeroDTO dto)
        {
            return new HeroEntity()
            {
                IdHero = dto.IdHero,
                Endurance = dto.Endurance,
                IdRace = dto.IdRace<=0?1:dto.IdRace,
                Name = dto.Name,
                Strength = dto.Strength
            };
        }
    }
}
