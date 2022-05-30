using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.DAL.Entities
{
    public class RaceEntity
    {
        public int IdRace { get; set; }
        public string Name { get; set; }
        public int EnduranceModifier { get; set; }
        public int StrengthModifier { get; set; }
    }
}
