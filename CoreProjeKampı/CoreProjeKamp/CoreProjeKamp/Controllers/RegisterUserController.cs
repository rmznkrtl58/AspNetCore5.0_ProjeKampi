using CoreProjeKamp.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CoreProjeKamp.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        //Registerde UserManager kullanıyom
        //CONSTRUCTOR METOD
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager= userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegister)
        {
            if (ModelState.IsValid)//useRegister parametremdeki veriler doğrulandıysa 
                                   //proplarıma verdiğim özellikleri sağladıysa
            {
                AppUser au = new AppUser()
                {
                    NameSurname=userRegister.NameSurname,
                    Email=userRegister.Mail,
                    //password aşağıda girecez
                    UserName=userRegister.UserName
                };
                var result = await _userManager.CreateAsync(au,userRegister.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                   foreach(var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }
                }
            }
            return View(userRegister);
        }
    }
}
