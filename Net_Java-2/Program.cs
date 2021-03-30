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
            if(data_spr(data))
            {
                Console.WriteLine("Podaj walutę");
                waluta = Console.ReadLine();
                waluta = waluta.ToUpper();
                wczytaj(data, waluta);
            }
            else
            {
                Console.WriteLine("Nie mozna podac kursu z dnia, ktory jeszcze nie nastapil");
            }
        Console.Read();
        }
        public static async void wczytaj(string data,string waluta)
        {
            double value;
            string call = "https://openexchangerates.org/api/historical/" + data + ".json?app_id=3183c3ec233b4b6783f194898d8accac";
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(call);
            currency wal = JsonConvert.DeserializeObject<currency>(json);
            if ( wal.Rates.TryGetValue(waluta,out value))
            {
                
                Console.WriteLine("Waluta: " + waluta + " kurs: " + wal.Rates[waluta] + " Dzien: " + data);
            }
            else
            {
                Console.WriteLine("Nie ma takiej waluty w tym API. \n");
            }

        }
        public static bool data_spr (string data)
        {
            var date = DateTime.Today;
            string year = data.Substring(0, 4);
            string month = data.Substring(5, 2);
            string day = data.Substring(8, 2);
            int day1 = int.Parse(day);
            int month1 = int.Parse(month);
            int year1 = int.Parse(year);
            var date1 = new DateTime(year1, month1,day1);
            if(date1>date)
            {
                return false;
            }
            return true;
        }
    }
}
