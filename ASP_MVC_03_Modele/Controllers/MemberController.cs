using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.Models;
using ASP_MVC_03_Modele.Models.Mappers;
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
        [ValidateAntiForgeryToken]
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
            Member member = memberService.Insert(
                memberRegister.Pseudo,
                memberRegister.Email,
                pwdHash
            ).ToModel();

            // TODO Store Member in Session
            Console.WriteLine($"Member create with id {member.IdMember}");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromForm] MemberLogin memberLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(memberLogin);
            }

            // Récuperation du hashage du mot de passe
            string? pwdHash = memberService.GetPasswordHash(memberLogin.Pseudo);
            if(pwdHash is null)
            {
                ModelState.AddModelError("", "Les credentials ne sont pas valide");
                return View(memberLogin);
            }

            // Validation du hashage du mot de passe
            if(!Argon2.Verify(pwdHash, memberLogin.Password))
            {
                ModelState.AddModelError("", "Les credentials ne sont pas valide");
                return View(memberLogin);
            }

            // Récuperation du compte via son pseudo
            Member member = memberService.GetByPseudo(memberLogin.Pseudo).ToModel();

            // TODO Store Member in Session
            Console.WriteLine($"Member login with id {member.IdMember}");

            return RedirectToAction("Index", "Home");
        }
    }
}
