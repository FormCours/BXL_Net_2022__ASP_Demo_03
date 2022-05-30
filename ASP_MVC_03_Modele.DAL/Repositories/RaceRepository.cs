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
    public class RaceRepository : IRaceRepository
    {
        private Connection _Connection; 

        public RaceRepository(Connection connection)
        {
            _Connection = connection;
        }

        private RaceEntity MapRecordToRace(IDataRecord record)
        {
            return new RaceEntity()
            {
                IdRace = (int)record["Id_Race"],   // record.GetInt32(record.GetOrdinal("Id_Race"))
                Name = (string)record["Name"],
                EnduranceModifier = (int)record["Endurance_Modifier"],
                StrengthModifier = (int)record["Strength_Modifier"]
            };
        }

        public IEnumerable<RaceEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Race");

            return _Connection.ExecuteReader(cmd, MapRecordToRace);
        }

        public RaceEntity GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Race WHERE Id_Race = @Id_Race");
            cmd.AddParameter("Id_Race", id);

            return _Connection.ExecuteReader(cmd, MapRecordToRace).SingleOrDefault();
        }

        public int Insert(RaceEntity entity)
        {
            Command cmd = new Command("INSERT INTO Race (Name, Endurance_Modifier, Strength_Modifier)" +
                " OUTPUT inserted.Id_Race" +
                " VALUES (@Name, @Endurance_Modifier, @Strength_Modifier)");
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Endurance_Modifier", entity.EnduranceModifier);
            cmd.AddParameter("Strength_Modifier", entity.StrengthModifier);

             return (int)_Connection.ExecuteScalar(cmd);
        }

        public bool Update(int id, RaceEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Race WHERE Id_Race = @Id_Race");
            cmd.AddParameter("Id_Race", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
