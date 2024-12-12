using BlogApiDemo.Dal.Database;
using BlogApiDemo.Dal.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]//apide çağırmada api/controller ismi
    [ApiController]
    public class DefaultController : ControllerBase
    {
        Context ent = new Context();
        [HttpGet]
        public IActionResult personlist()
        {
            var values = ent.persons.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult personadd(Person p)
        {
            ent.persons.Add(p);
            ent.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult getperson(int id)
        {
            var findperson = ent.persons.Find(id);
            if (findperson == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(findperson);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deleteperson(int id)
        {
            var findperson = ent.persons.Find(id);
            if (findperson == null)
            {
                return NotFound();
            }
            else
            {
                ent.persons.Remove(findperson);
                ent.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult Updateperson(Person p)
        {
            var personfind = ent.persons.Find(p.Id);
            if (personfind == null)
            {
                return NotFound();
            }
            else
            {
                personfind.NameSurname = p.NameSurname;
                ent.persons.Update(personfind);
                ent.SaveChanges();
                return Ok();
            }
            
        }
    }
}
