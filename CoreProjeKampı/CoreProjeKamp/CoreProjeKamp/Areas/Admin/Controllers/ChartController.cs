using CoreProjeKamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreProjeKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()//grafiğimin yapısını oluşturacak metod
        {
            List<ChartCategory> ChartCategoryList=new List<ChartCategory>();
            ChartCategoryList.Add(new ChartCategory
            {
                categorycount = 5,//filim dizi kategorisine düşen blog miktarı
                categoryname = "Filim & Dizi"
            });
            ChartCategoryList.Add(new ChartCategory
            {
                categorycount = 3,
                categoryname = "Edebiyat"
            });
            ChartCategoryList.Add(new ChartCategory
            {
                categorycount = 12,
                categoryname = "Oyun"
            });
            ChartCategoryList.Add(new ChartCategory
            {
                categorycount = 17,
                categoryname = "Yazılım"
            });
            ChartCategoryList.Add(new ChartCategory
            {
                categorycount = 7,
                categoryname = "Bilim"
            });
            return Json(new {jsonlist=ChartCategoryList});
            //json türünde döndürdüm çünkü js ile chartlarımı çağıracağım
            //json türünde dönmesi gerekiyordu jsonlist adında değişkenimi döndürdüm
            //ve değişkenime ChartCategoryList'tten gelen değerlerimi atadım
        }
    }
}
