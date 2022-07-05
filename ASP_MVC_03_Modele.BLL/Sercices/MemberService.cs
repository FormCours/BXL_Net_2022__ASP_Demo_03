using ASP_MVC_03_Modele.BLL.DTO;
using ASP_MVC_03_Modele.BLL.Mappers;
using ASP_MVC_03_Modele.DAL.Interfaces;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_03_Modele.BLL.Sercices
{
    public class MemberService
    {
        private IMemberRepository memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        #region Register & Login
        public bool CheckMemberExists(string pseudo, string email)
        {
            return memberRepository.CheckMemberExists(pseudo, email);
        }

        public MemberDTO? GetByCredentials(string pseudo, string pwd)
        {
            // Récuperation du hashage du mot de passe
            string? pwdHash = memberRepository.GetPasswordHash(pseudo);
            if (pwdHash is null)
            {
                return null;
            }

            // Validation du hashage du mot de passe
            if (!Argon2.Verify(pwdHash, pwd))
            {
                return null;
            }

            return memberRepository.GetByPseudo(pseudo).ToDTO();
        }
        #endregion

        #region Crud
        public MemberDTO Insert(string pseudo, string email, string pwd)
        {
            // Hashage du mot de passe
            string pwdHash = Argon2.Hash(pwd);

            int id = memberRepository.Insert(new DAL.Entities.MemberEntity
            {
                Pseudo = pseudo,
                Email = email,
                PwdHash = pwdHash
            });

            return memberRepository.GetById(id).ToDTO();
        }

        public bool Delete(int idMember)
        {
            return memberRepository.Delete(idMember);
        }
        #endregion
    }
}
