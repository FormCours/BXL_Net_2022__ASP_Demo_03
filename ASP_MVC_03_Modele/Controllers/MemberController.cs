using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.Helpers;
using ASP_MVC_03_Modele.Models;
using ASP_MVC_03_Modele.Models.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_03_Modele.Controllers
{
    public class MemberController : Controller
    {
        private MemberService memberService;
        private SessionManager sessionManager;

        public MemberController(MemberService memberService, SessionManager sessionManager)
        {
            this.memberService = memberService;
            this.sessionManager = sessionManager;
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

            // Save Member in DB
            Member member = memberService.Insert(
                memberRegister.Pseudo,
                memberRegister.Email,
                memberRegister.Password
            ).ToModel();

            // Store Member in Session
            sessionManager.Login(member);
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

            // Récuperation du compte via son pseudo
            Member? member = memberService.GetByCredentials(
                memberLogin.Pseudo,
                memberLogin.Password
            )?.ToModel();

            // Envoi d'une erreur si le compte ne peut pas être récuperé
            if (member is null)
            {
                ModelState.AddModelError("", "Les credentials ne sont pas valide");
                return View(memberLogin);
            }

            // Store Member in Session
            sessionManager.Login(member); 
            Console.WriteLine($"Member login with id {member.IdMember}");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            // Clear session
            sessionManager.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
