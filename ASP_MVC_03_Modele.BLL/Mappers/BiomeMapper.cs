using ASP_MVC_03_Modele.BLL.DTO;
using ASP_MVC_03_Modele.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.BLL.Mappers
{
    internal static class BiomeMapper
    {

        public static BiomeDTO ToDTO(this BiomeEntity entity)
        {
            return new BiomeDTO()
            {
                IdBiome = entity.IdBiome,
                Name = entity.Name,
                Desc = entity.Desc,
                DifficultyLevel = entity.DifficultyLevel,
                ImageUri = entity.ImageUri
            };
        }

        public static BiomeEntity ToEntity(this BiomeDTO dto)
        {
            return new BiomeEntity()
            {
                IdBiome = dto.IdBiome,
                Name = dto.Name,
                Desc = dto.Desc,
                DifficultyLevel = dto.DifficultyLevel,
                ImageUri = dto.ImageUri
            };
        }

    }
}
