using ASP_MVC_03_Modele.DAL.Entities;
using ASP_MVC_03_Modele.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.DAL.Repositories
{
    public class HeroRepository : IHeroRepository
    {

        public IEnumerable<HeroEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public HeroEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(HeroEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, HeroEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
