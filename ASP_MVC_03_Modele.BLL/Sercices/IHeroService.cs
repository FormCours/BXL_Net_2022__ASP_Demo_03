using ASP_MVC_03_Modele.BLL.DTO;

namespace ASP_MVC_03_Modele.BLL.Sercices
{
    public interface IHeroService
    {
        IEnumerable<HeroDTO> GetAll();
        IEnumerable<HeroDTO> GetByEndurance(int endu);
        HeroDTO GetById(int id);
        IEnumerable<HeroDTO> GetByName(string name);
        bool Insert(HeroDTO H);
        bool Update(int id, HeroDTO H);
    }
}