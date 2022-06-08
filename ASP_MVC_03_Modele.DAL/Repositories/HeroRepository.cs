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
            Command cmd = new Command($"INSERT INTO {TableName} (Name, Endurance, Strength, Id_Race)" +
                $" OUTPUT inserted.{TableId}" +
                " VALUES (@Name, @Endurance, @Strength, @Id_Race)");

            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Endurance", entity.Endurance);
            cmd.AddParameter("Strength", entity.Strength);
            cmd.AddParameter("Id_Race", entity.IdRace);

            int? rep = (int?)_Connection.ExecuteScalar(cmd);

            return rep ?? -1;
        }

        public override bool Update(int id, HeroEntity entity)
        {
            Command cmd = new Command($"UPDATE {TableName}" +
                " SET Name = @Name," +
                "     Endurance = @Endurance," +
                "     Strength = @Strength," +
                "     Id_Race = @Id_Race" +
                $" WHERE {TableId} = @Id");

            cmd.AddParameter("Id", id);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Endurance", entity.Endurance);
            cmd.AddParameter("Strength", entity.Strength);
            cmd.AddParameter("Id_Race", entity.IdRace);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

        protected override HeroEntity MapRecordToEntity(IDataRecord record)
        {
            return new HeroEntity()
            {
                IdHero = (int)record[TableId],
                Name = (string)record["Name"],
                Endurance = (int)record["Endurance"],
                Strength = (int)record["Strength"],
                IdRace = (int)record["Id_Race"]
            };
        }
    }
}
