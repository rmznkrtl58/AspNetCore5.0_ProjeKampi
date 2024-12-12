using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreProjeKamp.Controllers
{
    
    public class MessageController : Controller
    {
        Context ent = new Context();
        private readonly UserManager<AppUser> _userManager;
        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        public IActionResult Index()
        {
            var userinfo = User.Identity.Name;
            //aşağıyı solide aykırı yazcaz
            Context ent = new Context();
            var usermail = ent.Users.Where(x => x.UserName == userinfo).Select(x => x.Email).FirstOrDefault();
            var userid = ent.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            //Gelen Mesajların Bulunduğu sayfa
            var values = mm.GetListMessagesByWriter(userid);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var values=mm.TGetById(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(Message2 m)
        {
            var finduser=await _userManager.FindByNameAsync(User.Identity.Name);
            //aşağıdaki kodlar solide aykırıdır
            var usermail = ent.Users.Where(x => x.UserName == finduser.ToString()).Select(x => x.Email).FirstOrDefault();
            var userid = ent.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            m.SenderId= userid;
            m.ReceiverId = 2;
            m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.MessageStatus = true;
            mm.TAdd(m);
            return RedirectToAction("Sendbox","Message");
        }
        public async Task<IActionResult> Sendbox()
        {
            var finduser = await _userManager.FindByNameAsync(User.Identity.Name);
            var findmail = ent.Users.Where(x => x.UserName == finduser.ToString()).Select(x => x.Email).FirstOrDefault();
            var findid = ent.Writers.Where(x => x.WriterMail == findmail).Select(x => x.WriterId).FirstOrDefault();
            var values = mm.GetListMessagesReceiverByWriter(findid);
            return View(values);
        }
    }
}
