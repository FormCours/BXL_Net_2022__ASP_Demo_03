using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.BLL.DTO
{
    public class BiomeDTO
    {
        public int IdBiome { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public int DifficultyLevel { get; set; }
        public string? ImageUri { get; set; }
    }
}
