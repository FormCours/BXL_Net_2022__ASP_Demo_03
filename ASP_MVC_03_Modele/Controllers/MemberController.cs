using ASP_MVC_03_Modele.BLL.Sercices;
using ASP_MVC_03_Modele.Models;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_03_Modele.Controllers
{
    public class MemberController : Controller
    {
        // TODO Add missing config in injection dependance !

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

            // TODO Add Check is Email or Pseudo exists 

            string pwdHash = Argon2.Hash(memberRegister.Password);

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
