using ASP_MVC_03_Modele.BLL.DTO;

namespace ASP_MVC_03_Modele.Models.Mappers
{
    internal static class MemberMapper
    {
        public static Member ToModel(this MemberDTO dto)
        {
            return new Member()
            {
                IdMember = dto.IdMember,
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
        }
    }
}
