using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracownicyController : ControllerBase
    {
       List<Pracownik> pracownicy;
        public PracownicyController()
        {
            pracownicy = new List<Pracownik>{
                new Pracownik { Id = 1, Imie = "Jan", Nazwisko = "Kowalski " },
                new Pracownik { Id = 2, Imie = "Tomasz", Nazwisko = "Sekielski "},
                new Pracownik { Id = 3, Imie = "Bogdan", Nazwisko = "Kurczak" },
                new Pracownik { Id = 4, Imie = "Max", Nazwisko = "Dotnet" },
                new Pracownik { Id = 5, Imie = "Klaudia", Nazwisko = "Java" },
                new Pracownik { Id = 6, Imie = "Maciej", Nazwisko = "Azure" },
             };

           
        }
        // GET api/values
        [HttpGet]
        public ActionResult<JsonResult> Get()
        { 
            return new JsonResult(pracownicy);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<JsonResult> Get(int id)
        {
            return new JsonResult(pracownicy.First(p=>p.Id==id));
        }

        // POST api/pracownicy
        [HttpPost]
        public void Post([FromBody] Pracownik value)
        {
          pracownicy.Add(value);
        }

        // PUT api/pracownicy/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Pracownik value)
        {
           var edytowany = pracownicy.First(p => p.Id == id);

            edytowany.Id = value.Id;
            edytowany.Nazwisko = value.Nazwisko;
            edytowany.Imie = value.Imie;

            return $"Zmodyfikowano pracownika id={value.Id} ({value.Imie} {value.Nazwisko})";
        }

        // DELETE api/pracownicy/bynazwisko/kowalski
        [HttpDelete("bynazwisko/{nazwisko}")]
        public ActionResult<string> Delete(string nazwisko)
        {
            return new JsonResult($"Usunięto {pracownicy.RemoveAll(p => p.Nazwisko == nazwisko)} pracowników");
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            return new JsonResult($"Usunięto {pracownicy.RemoveAll(p => p.Id == id)} pracowników");
        }
    }
}
