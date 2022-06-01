using ASP_MVC_03_Modele.DAL.Entities;
using ASP_MVC_03_Modele.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Connections;

namespace ASP_MVC_03_Modele.DAL.Repositories
{
    public class BiomeRepository : RepositoryBase<int, BiomeEntity>, IBiomeRepository
    {
        public BiomeRepository(Connection connection)
            : base(connection, "Biome", "Id_Biome")
        { }

        public override int Insert(BiomeEntity entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, BiomeEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override BiomeEntity MapRecordToEntity(IDataRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
