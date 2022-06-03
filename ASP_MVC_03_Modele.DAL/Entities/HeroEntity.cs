using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.DAL.Entities
{
    public class HeroEntity
    {
        public int IdHero { get; set; }
        public string Name { get; set; }
        public int Endurance { get; set; }
        public int Strength { get; set; }
        public int IdRace { get; set; }

        // TODO Add link with Member (FK !!!)
    }
}
