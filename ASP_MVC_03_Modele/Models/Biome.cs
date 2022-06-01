using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_03_Modele.Models
{
    public class Biome
    {
        public int IdBiome { get; set; }

        [DisplayName("Nom de la zone")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string? Desc { get; set; }

        [DisplayName("Niveau")]
        public int DifficultyLevel { get; set; }

        public string? ImageUri { get; set; }

    }
}
