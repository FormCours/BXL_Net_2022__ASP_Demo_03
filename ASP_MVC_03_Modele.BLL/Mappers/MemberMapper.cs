using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_MVC_03_Modele.BLL.DTO;
using ASP_MVC_03_Modele.DAL.Entities;

namespace ASP_MVC_03_Modele.BLL.Mappers
{
    internal static class MemberMapper
    {
        public static MemberDTO ToDTO(this MemberEntity entity)
        {
            return new MemberDTO()
            {
                IdMember = entity.IdMember,
                Pseudo = entity.Pseudo,
                Email = entity.Email,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
                PwdHash = entity.PwdHash
            };
        }

        public static MemberEntity ToEntity(this MemberDTO dto)
        {
            return new MemberEntity()
            {
                IdMember = dto.IdMember,
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                PwdHash = dto.PwdHash
            };
        }
    }
}
