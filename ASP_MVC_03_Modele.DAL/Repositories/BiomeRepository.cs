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
            Command cmd = new Command($"INSERT INTO {TableName}(Name, Description, Difficulty_Level, Image_Uri)" +
                $" OUTPUT inserted.{TableId}" +
                " VALUES (@Name, @Description, @Difficulty_Level, @Image_Uri)");

            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Description", entity.Desc);
            cmd.AddParameter("Difficulty_Level", entity.DifficultyLevel);
            cmd.AddParameter("Image_Uri", entity.ImageUri);

            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, BiomeEntity entity)
        {
            Command cmd = new Command($"UPDATE {TableName} " +
                " SET Name = @Name," +
                "     Description = @Desc," +
                "     Difficulty_Level = @Diff_Level" +
                "     Image_Uri = @Image_Uri" +
                $" WHERE {TableId} = @Id");

            cmd.AddParameter("Id", id);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Desc", entity.Desc);
            cmd.AddParameter("Diff_Level", entity.DifficultyLevel);
            cmd.AddParameter("Image_Uri", entity.ImageUri);

            return _Connection.ExecuteNonQuery(cmd) == 1; 
        }

        protected override BiomeEntity MapRecordToEntity(IDataRecord record)
        {
            return new BiomeEntity()
            {
                IdBiome = (int)record[TableId],
                Name = (string)record["Name"],
                Desc = record["Description"] is DBNull ? null : (string)record["Description"],
                DifficultyLevel = (int)record["Difficulty_Level"],
                ImageUri = record["Image_Uri"] is DBNull ? null : (string)record["Image_Uri"]
            };
        }
    }
}
