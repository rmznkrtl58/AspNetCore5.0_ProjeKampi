using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

namespace CoreProjeKamp.Areas.Admin.VievComponents
{
    public class Statistics1:ViewComponent
    {   //SOLİDE AYKIRIDIR AŞAĞISI
        Context ent = new Context();
        public IViewComponentResult Invoke()
        {   //internette hava durumu apisi çekme(openweathermap)
            //string api = "8e6e75be646275947f8163ddfa3be7cf";
            //string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode-xml&lang=tr&units=metric&appid=" + api;
            //XDocument document=XDocument.Load(connection);//değişkenimden gelen adresi yükle
            //ViewBag.v4 = document.Descendants("temp").ElementAt(0).Attribute("value").Value;
            //descendants->hangi değerlerin başlığı
            //element at->gelen değerlerden ilk değeri 0.indexi al
            //attribute->value->sıcaklık değerlerini tutan yapı
            var userinfo = User.Identity.Name;
            var writerid = ent.Writers.Where(x => x.WriterMail == userinfo).Select(x => x.WriterId).FirstOrDefault();
            ViewBag.v1 = ent.Blogs.Count();
            ViewBag.v2 = ent.Message2s.Where(x => x.ReceiverId == writerid).Count().ToString();
            ViewBag.v3 = ent.Comments.Where(x => x.Blog.WriterId == writerid).Count().ToString();
            return View();
        }
    }
}
