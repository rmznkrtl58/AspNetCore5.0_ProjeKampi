using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjeKamp.Controllers
{
    
    public class PersonTestController : Controller
    {
        //Aşağıya api katmanımdaki person tablomdaki proplarımı yazmam lazım
        public class Class1
        {
            public int Id { get; set; }
            public string NameSurname { get; set; }
        }
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44335/api/Default");
            //getasync->listeleme yapmam için gereken komut içerisine
            //swaggerda yer alan request adresimi yapıştırmam gerek
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            //responsemessage'daki verilen istekteki veriyi oku
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            //verilei api'den çekerken (alırken) deserialize olarak göndeririz 
            return View(values);
        }
        [HttpGet]
        public IActionResult addperson()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addperson(Class1 c)
        {
            var httpClient=new HttpClient();
            var jsonperson=JsonConvert.SerializeObject(c);
            //verilei api'ye gönderirken serialize olarak göndeririz 
            StringContent content= new StringContent(jsonperson,Encoding.UTF8,"application/json");
            //jsonperson değişkenimdeki gönderilecek verilerin içeriğinin özelliklerini belitiriz
            var responseMessage = await httpClient.PostAsync("https://localhost:44335/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "PersonTest");
            }
            return View(c);
        }
        [HttpGet]
        public async Task<IActionResult> editperson(int id)
        {
            //Güncellenecek olan veriyi getirme
            var httpClient= new HttpClient();
            var responseMessage =await httpClient.GetAsync("https://localhost:44335/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonperson=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonperson);
                //verilei api'den çekerken (alırken) deserialize olarak göndeririz 
                return View(values);
            }
            return RedirectToAction("Index","PersonTest");
        }
        [HttpPost]
        public async Task<IActionResult> editperson(Class1 c)
        {
            //Güncelleme işlemi
            var httpClient = new HttpClient();
            var jsonperson=JsonConvert.SerializeObject(c);
            //verilei api'ye gönderirken serialize olarak göndeririz 
            var content = new StringContent(jsonperson, Encoding.UTF8, "application/json");
            var responseMessage =await httpClient.PutAsync("https://localhost:44335/api/Default", content);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index", "PersonTest");
            }
            return View(c);
        }
        public async Task<IActionResult> deleteperson(int id)
        {
            //Silme işlemi
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44335/api/Default/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "PersonTest");
            }
            return View();
        }


    }
}
