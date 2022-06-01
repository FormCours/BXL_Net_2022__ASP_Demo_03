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
    public class HeroRepository : RepositoryBase<int, HeroEntity>, IHeroRepository
    {
        public HeroRepository(Connection connection)
            : base(connection, "Hero", "Id_Hero")
        { }

        public override int Insert(HeroEntity entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, HeroEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override HeroEntity MapRecordToEntity(IDataRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
