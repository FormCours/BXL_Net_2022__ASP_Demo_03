using ASP_MVC_03_Modele.BLL.DTO;

namespace ASP_MVC_03_Modele.Models.Mappers
{
    internal static class BiomeMapper
    {
        public static Biome ToModel(this BiomeDTO dto)
        {
            return new Biome()
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
