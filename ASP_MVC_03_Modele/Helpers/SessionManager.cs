using ASP_MVC_03_Modele.Models;
using System.Text.Json;

namespace ASP_MVC_03_Modele.Helpers
{
    public class SessionManager
    {
        private readonly ISession _Session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _Session = httpContextAccessor.HttpContext.Session;
        }

        public MemberSession? MemberSession
        {
            get
            {
                string? member = _Session.GetString(nameof(MemberSession));
                if (member is null)
                {
                    return null;
                }

                return JsonSerializer.Deserialize<MemberSession>(member);
            }
            set
            {
                _Session.SetString(nameof(MemberSession), JsonSerializer.Serialize(value));
            }
        }

        public bool IsLogged
        {
            get { return !(MemberSession is null); }
        }


        public void Login(Member member)
        {
            MemberSession = new MemberSession
            {
                IdMember = member.IdMember,
                Pseudo = member.Pseudo,
                Email = member.Email
            };
        }

        public void Logout()
        {
            _Session.Clear();
        }
    }
}
