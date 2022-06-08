using ASP_MVC_03_Modele.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.DAL.Interfaces
{
    public interface IHeroRepository : IRepository<int, HeroEntity>
    {
      
    }
}
