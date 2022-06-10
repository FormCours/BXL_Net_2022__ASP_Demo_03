using ASP_MVC_03_Modele.BLL.DTO;
using ASP_MVC_03_Modele.BLL.Sercices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_API_Heroes.Test.Fakes
{
    internal class FakeHeroService : IHeroService
    {
        List<HeroDTO> _heroes;
        public FakeHeroService()
        {
            _heroes= new List<HeroDTO>()
           { new HeroDTO(){ IdHero=1, Endurance=456, IdRace=1, Name="MOI", Strength=665 } };
        }
        public IEnumerable<HeroDTO> GetAll()
        {
            return _heroes;
        }

        public IEnumerable<HeroDTO> GetByEndurance(int endu)
        {
            throw new NotImplementedException();
        }

        public HeroDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HeroDTO> GetByName(string name)
        {
            return _heroes.Where(m => m.Name == name);
        }

        public bool Insert(HeroDTO H)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, HeroDTO H)
        {
            var hh = from he in _heroes
                     where he.IdHero == id
                     select he;

           HeroDTO h = _heroes.FirstOrDefault(h => h.IdHero == id);
            if(h != null )
            {
                return true;
            }
            return false;
        }
    }
}
