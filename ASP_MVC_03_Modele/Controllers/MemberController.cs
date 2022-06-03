﻿using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.Models;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_03_Modele.Controllers
{
    public class MemberController : Controller
    {
        private MemberService memberService;

        public MemberController(MemberService memberService)
        {
            this.memberService = memberService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] MemberRegister memberRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(memberRegister);
            }

            // Check if Member exists
            if (memberService.CheckMemberExists(memberRegister.Pseudo, memberRegister.Email))
            {
                ModelState.AddModelError("", "Le compte existe déjà.");
                return View(memberRegister);
            }

            // Hashage du mot de passe
            string pwdHash = Argon2.Hash(memberRegister.Password);

            // Save Member in DB
            memberService.Insert(
                memberRegister.Pseudo,
                memberRegister.Email,
                pwdHash
            );

            return RedirectToAction("Index", "Home");
        }

        // TODO Add Login

    }
}
