using ASP_MVC_03_Modele.BLL.DTO;
using ASP_MVC_03_Modele.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ASP_MVC_03_Modele.BLL.Mappers;
using ASP_MVC_03_Modele.DAL.Interfaces;

namespace ASP_MVC_03_Modele.BLL.Sercices
{
    public class BiomeService
    {
        private IBiomeRepository biomeRepository;

        public BiomeService(IBiomeRepository biomeRepository)
        {
            this.biomeRepository = biomeRepository;
        }


        public BiomeDTO GetById(int id)
        {
            return biomeRepository.GetById(id)?.ToDTO();
        }

        public IEnumerable<BiomeDTO> GetAll()
        {
            return biomeRepository.GetAll().Select(b => b.ToDTO());
        }

        public BiomeDTO Insert(BiomeDTO biome)
        {
            int idBiome = biomeRepository.Insert(biome.ToEntity());

            biome.IdBiome = idBiome;
            return biome;
        }

    }
}
