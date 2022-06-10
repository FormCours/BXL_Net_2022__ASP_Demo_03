using ASP_MVC_03_Modele.BLL.DTO;
using ASP_MVC_03_Modele.BLL.Mappers;
using ASP_MVC_03_Modele.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.BLL.Sercices
{
    public class HeroService : IHeroService
    {
        private IHeroRepository heroRepository;
        public HeroService(IHeroRepository repo)
        {
            this.heroRepository = repo;
        }

        public IEnumerable<HeroDTO> GetAll()
        {

            return heroRepository.GetAll().Select(b => b.ToDTO());
        }

        public IEnumerable<HeroDTO> GetByName(string name)
        {//Version feignasse ==> On devrait prévoir la méthode dans le repo
            return heroRepository.GetAll().Where(m => m.Name.ToLower().Contains(name)).Select(b => b.ToDTO());
        }

        public HeroDTO GetById(int id)
        {
            return heroRepository.GetById(id).ToDTO();
        }

        public IEnumerable<HeroDTO> GetByEndurance(int endu)
        {
            return heroRepository.GetAll().Where(m => m.Endurance.Equals(endu)).Select(b => b.ToDTO());
        }

        public bool Insert(HeroDTO H)
        {
            return heroRepository.Insert(H.ToEntity()) > 0;
        }

        public bool Update(int id, HeroDTO H)
        {
            return heroRepository.Update(id, H.ToEntity());
        }
    }
}
