using CoreProjeKamp.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace CoreProjeKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult TestAjax()
        {
            //statik olarak ajax kullanımını bu sayfada yapacağız
            return View();
        }
        //Ajaxı yazacağım scriptimde çağıracağım metod aşağıdakidir
        public IActionResult GetWriterListAjax()
        {
            var jsonwriters = JsonConvert.SerializeObject(wlist);
            return Json(jsonwriters);
        }
        //İd'ye göre veriyi sayfaya getirme Ajaxla
        public IActionResult GetWriterByIdAjax(int writerid)
        {
            var findwriter = wlist.FirstOrDefault(x=>x.WriterId== writerid);
            var jsonwriters=JsonConvert.SerializeObject(findwriter);
            return Json(jsonwriters);   
        }
        [HttpPost]
        //YAZAR EKLEME AJAX
        public IActionResult WriterAddAjax(WriterListAjax w)
        {
            wlist.Add(w);
            var jsonwritersadd = JsonConvert.SerializeObject(w);
            return Json(jsonwritersadd);
        }
        //YAZAR SİLME AJAX
        public IActionResult DeleteWriterAjax(int id)
        {
            var findwriter = wlist.FirstOrDefault(x => x.WriterId == id);
            var jsonwritersdelete= wlist.Remove(findwriter);
            return Json(jsonwritersdelete);
        }
        //YAZAR Güncelleme AJAX
        public IActionResult UpdateWriterAjax(WriterListAjax w)
        {
            var findwriter = wlist.FirstOrDefault(x => x.WriterId == w.WriterId);
            findwriter.WriterName= w.WriterName;
            var jsonwritersupdate = JsonConvert.SerializeObject(w);
            return Json(jsonwritersupdate);
        }
        public static List<WriterListAjax> wlist = new List<WriterListAjax>()
        {
            //Ajax için statik veriler
            new WriterListAjax()
            {
                WriterId=1,
                WriterName="İlhan Kartal"
            },
            new WriterListAjax()
            {
                WriterId=2,
                WriterName="Ramazan Kartal"
            },
            new WriterListAjax()
            {
                WriterId=3,
                WriterName="Emre Kartal"
            },
            new WriterListAjax()
            {
                WriterId=4,
                WriterName="Kadir Kartal"
            }
        };
    }
}
