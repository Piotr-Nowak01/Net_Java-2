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
            var date = DateTime.Today;
            string day = date.Day.ToString();
            string month = date.Month.ToString();
            string year = date.Year.ToString();
            string data="";
            string waluta = "";
            string s = "Nie mozna podac kursu z dnia, ktory jeszcze nie nastapil";
            Console.WriteLine("Podaj datę, z której chcesz poznać kurs. Datę podaj w formacie rok-msc-dn");
            data = Console.ReadLine();
            string year1 = data.Substring(0, 4);
            string month1 = data.Substring(5, 2);
            string day1 = data.Substring(8, 2);
            int day_1 = int.Parse(day);
            int month_1 = int.Parse(month);
            int year_1 = int.Parse(year);
            int day1_1 = int.Parse(day1);
            int month1_1 = int.Parse(month1);
            int year1_1 = int.Parse(year1);
            if (year1_1 > year_1)
            {
                Console.WriteLine(s);
            }
            else if (year1_1 == year_1 && month1_1 > month_1)
            {
                Console.WriteLine(s);
            }
            else if (year1_1 == year_1 && month1_1 == month_1 && day1_1 > day_1)
            {
                Console.WriteLine(s);
            }
            else
            {
                Console.WriteLine("Podaj walutę");
                waluta = Console.ReadLine();
                waluta = waluta.ToUpper();
                wczytaj(data, waluta);
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
    }
}
