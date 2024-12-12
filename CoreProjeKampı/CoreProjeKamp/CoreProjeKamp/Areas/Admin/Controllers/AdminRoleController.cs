using CoreProjeKamp.Models;
using EntityLayer.Concrete;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjeKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager; 
        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var roles =_roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult addrole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addrole(RoleViewModel r)
        {
            if (ModelState.IsValid) 
            {
                AppRole au = new AppRole()
                {
                    Name = r.name
                };
                var result=await _roleManager.CreateAsync(au);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index","AdminRole");
                }
                else
                {
                  foreach(var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }                    
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult editrole(int id)
        {
            //Index sayfamda Rolleri listeleyeceğim zaman modelimde
            //AppRole Classımı kullandım çünkü AppRole classım 
            //IdentityRole'Den kalıtım alıyor detaylara girmeden
            //düzenle butonuna tıkladığın an ilgili rolünde id'sini 
            //şuan üzerinde çalıştığım editrole sayfama taşıdım
            //sonra _rolemanager ile ilgili şartlara bağlı olarak 
            //ilgili rolü buldurup o verilerin sonradan oluşturmuş olduğum
            //modele atamasını yaptım çünkü sayfamda o modele bağlı çağırıcam verilerimi
            //ve o model vasıtasıyla güncelleme yapacağım
            var findroleid = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel ur = new UpdateRoleViewModel()
            {
                Id = findroleid.Id,
                name = findroleid.Name
            };
            return View(ur);
        }
        [HttpPost]
        public async Task<IActionResult> editrole(UpdateRoleViewModel u)
        {
            //ben modelime verilerimi çektim şimdi o id'ye güncelleme yapacağım
            var findroleid = _roleManager.Roles.FirstOrDefault(x => x.Id == u.Id);
            findroleid.Name = u.name;
            var result = await _roleManager.UpdateAsync(findroleid);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminRole");
            }
            return View(u);
        }
        public async Task<IActionResult> deleterole(int id)
        {
            var findroleid = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(findroleid);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminRole");
            }
            return View();
        }
        public IActionResult userrolelist()
        {
            //Kullanıcılara rol atama yapabilmek için Kullanıcı Listesi
            var values = _userManager.Users.ToList(); 
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssingRole(int id)
        {
            //Kullanıcılara rol atama yapabilmek için Kullanıcı Listesi

            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            //user değişkenime kullanıcılar'ın listesi olduğum sayfadan ilgili
            //kullanıcıya role ataması yapmam için tıkladığım an bu sayfaya 
            //o kullanıcını id'sini taşıdım ve firstordefault metodumla
            //şartımla o kullanıcını bilgilerini aldım
            var roles=_roleManager.Roles.ToList();
            TempData["Userid"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            //userRoles değişkenime user'da çağırmış olduğum kişiye ait 
            //rolü çekiyorum
            List<RoleAssingViewModel>model= new List<RoleAssingViewModel>();
            foreach(var x in roles)
            {
                RoleAssingViewModel r = new RoleAssingViewModel();
                r.RoleId= x.Id;
                r.name= x.Name;
                r.exists = userRoles.Contains(x.Name);
                //userRoles içerisinde roles listesin içerisindeki name
                //değeri varsa atama yap bool türü varsa yap yoksa başa dön
                model.Add(r);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssingRole(List<RoleAssingViewModel> r)
        {
            var userid =TempData["Userid"];
            var finduser =_userManager.Users.FirstOrDefault(x => x.Id == (int)userid);
            //Kullanıcılara rol atama yapabilmek için Kullanıcı Listesi
            foreach(var x in r)
            {
                if (x.exists)//exists true gelirse 
                {
                    await _userManager.AddToRoleAsync(finduser,x.name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(finduser, x.name);
                }
            }
            return RedirectToAction("userrolelist", "AdminRole");
        }
    }
}
