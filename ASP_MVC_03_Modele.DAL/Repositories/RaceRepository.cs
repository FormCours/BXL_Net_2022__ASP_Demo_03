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
    public class RaceRepository : RepositoryBase<int, RaceEntity>, IRaceRepository
    {
        public RaceRepository(Connection connection) 
            : base(connection, "Race", "Id_Race") { }


        protected override RaceEntity MapRecordToEntity(IDataRecord record)
        {
            return new RaceEntity()
            {
                IdRace = (int)record["Id_Race"],   // record.GetInt32(record.GetOrdinal("Id_Race"))
                Name = (string)record["Name"],
                EnduranceModifier = (int)record["Endurance_Modifier"],
                StrengthModifier = (int)record["Strength_Modifier"]
            };
        }

        public override int Insert(RaceEntity entity)
        {
            Command cmd = new Command("INSERT INTO Race (Name, Endurance_Modifier, Strength_Modifier)" +
                " OUTPUT inserted.Id_Race" +
                " VALUES (@Name, @Endurance_Modifier, @Strength_Modifier)");
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Endurance_Modifier", entity.EnduranceModifier);
            cmd.AddParameter("Strength_Modifier", entity.StrengthModifier);

             return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, RaceEntity entity)
        {
            Command cmd = new Command($"UPDATE Race" +
                " SET Name = @Name," +
                "     Endurance_Modifier = @Endurance_Modifier," +
                "     Strength_Modifier = @Strength_Modifier" +
                $" WHERE Id_Race = @Id");

            cmd.AddParameter("Id", id);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Endurance_Modifier", entity.EnduranceModifier);
            cmd.AddParameter("Strength_Modifier", entity.StrengthModifier);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
