using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
namespace Net_Java_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string data="";
            string waluta = "";
            Console.WriteLine("Podaj datę, z której chcesz poznać kurs. Datę podaj w formacie rok-msc-dn");
            data = Console.ReadLine();
            Console.WriteLine("Podaj walutę");
            waluta = Console.ReadLine();
            waluta = waluta.ToUpper();
            wczytaj(data,waluta);
            Console.Read();
        }
        public static async void wczytaj(string data,string waluta)
        {
            string call = "https://openexchangerates.org/api/historical/" + data + ".json?app_id=3183c3ec233b4b6783f194898d8accac";
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(call);
            currency wal = JsonConvert.DeserializeObject<currency>(json);
            Console.WriteLine("Waluta: "+waluta+" kurs: "+ wal.Rates[waluta] + " Dzien: "+data);
        }
    }
}
