using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace KlientRest
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(3000);
          var message= GetPracownicy();
            
            string pracownicyStr = message.Content.ReadAsStringAsync().Result;
            dynamic pracownicy= JsonConvert.DeserializeObject(pracownicyStr);
           
            foreach (var pr in pracownicy.value)
            {
                Console.WriteLine(pr.id +":"+pr.nazwisko +" "+pr.imie);
            }
            Console.ReadKey();
            Console.Write("Podaj Id do usunięcia:");
            int id =int.Parse(Console.ReadLine());
            Console.WriteLine(DeletePracownik(id));

            pracownicyStr = message.Content.ReadAsStringAsync().Result;
           pracownicy = JsonConvert.DeserializeObject(pracownicyStr);
            foreach (var pr in pracownicy.value)
            {
                Console.WriteLine(pr.id + ":" + pr.nazwisko + " " + pr.imie);
            }
     


            Console.ReadKey();
        }

        private static HttpResponseMessage GetPracownicy()
        {
            HttpClient client = new HttpClient();
            var odp =  client.GetAsync("https://localhost:5001/api/pracownicy").Result;
            return odp;
        }
        private static HttpResponseMessage DeletePracownik(int id)
        {
            HttpClient client = new HttpClient();
            var odp = client.DeleteAsync($"https://localhost:5001/api/pracownicy/{id}").Result;
            return odp;
        }
    }
}
