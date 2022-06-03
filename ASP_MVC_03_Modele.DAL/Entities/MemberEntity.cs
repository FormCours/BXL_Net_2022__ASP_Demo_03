using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.DAL.Entities
{
    public class MemberEntity
    {
        public int IdMember { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string PwdHash { get; set; }
    }
}
