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
    public class MemberRepository : RepositoryBase<int, MemberEntity>, IMemberRepository
    {
        public MemberRepository(Connection connection)
            : base(connection, "Member", "Id_Member")
        { }

        protected override MemberEntity MapRecordToEntity(IDataRecord record)
        {
            return new MemberEntity()
            {
                IdMember = (int)record[TableId],
                Pseudo = (string)record["Pseudo"],
                Email = (string)record["Email"],
                Firstname = record["Firstname"] is DBNull ? null : record["Firstname"].ToString(),
                Lastname = record["Lastname"] is DBNull ? null : record["Lastname"].ToString(),
                PwdHash = null
            };
        }

        public override int Insert(MemberEntity entity)
        {
            Command cmd = new Command($"INSERT INTO {TableName} (Pseudo, Email, Firstname, Lastname, Pwd_Hash)" +
                $" OUTPUT inserted.{TableId}" +
                $" VALUES (@Pseudo, @Email, @Firstname, @Lastname, @Pwd_Hash)");

            cmd.AddParameter("Pseudo", entity.Pseudo);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Firstname", entity.Firstname);
            cmd.AddParameter("Lastname", entity.Lastname);
            cmd.AddParameter("Pwd_Hash", entity.PwdHash);

            return (int)_Connection.ExecuteScalar(cmd);
        }

        public override bool Update(int id, MemberEntity entity)
        {
            // TODO Implementer la mise a jour du Member
            throw new NotImplementedException();
        }

        public string? GetPasswordHash(string pseudo)
        {
            Command cmd = new Command($"SELECT Pwd_Hash FROM {TableName} WHERE Pseudo = @Pseudo");
            cmd.AddParameter("Pseudo", pseudo);

            return _Connection.ExecuteScalar(cmd)?.ToString();
        }

        public bool CheckMemberExists(string pseudo, string email)
        {
            Command cmd = new Command($"SELECT COUNT(*) FROM {TableName} WHERE Pseudo = @Pseudo OR Email = @email");
            cmd.AddParameter("Pseudo", pseudo);
            cmd.AddParameter("Email", email);

            return ((int)_Connection.ExecuteScalar(cmd)) == 1;
        }

        public virtual MemberEntity GetByPseudo(string pseudo)
        {
            Command cmd = new Command($"SELECT * FROM {TableName} WHERE Pseudo = @Pseudo");
            cmd.AddParameter("Pseudo", pseudo);

            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
    }
}
