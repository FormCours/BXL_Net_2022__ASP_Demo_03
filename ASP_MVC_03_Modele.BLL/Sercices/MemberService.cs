﻿using ASP_MVC_03_Modele.BLL.DTO;
using ASP_MVC_03_Modele.BLL.Mappers;
using ASP_MVC_03_Modele.DAL.Interfaces;
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

        // Créer un compte
        public MemberDTO Insert(string pseudo, string email, string pwdHash)
        {
            int id = memberRepository.Insert(new DAL.Entities.MemberEntity
            {
                Pseudo= pseudo,
                Email = email,
                PwdHash= pwdHash
            });

            return memberRepository.GetById(id).ToDTO();
        }

        // Se loguer
        public string? GetPasswordHash(string pseudo)
        {
            return memberRepository.GetPasswordHash(pseudo);
        }

        // Supprimer un compte
        public bool Delete(int idMember)
        {
            return memberRepository.Delete(idMember);
        }
    }
}
