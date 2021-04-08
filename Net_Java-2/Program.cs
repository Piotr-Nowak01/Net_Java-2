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
                Console.WriteLine("Nie mozna podac kursu. Nieprawidlowa data.");
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
            if(date_check(day1,month1,year1))
            {
                var date1 = new DateTime(year1, month1, day1);
                if (date1<date)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool date_check(int day, int month, int year)
        {
            if(year_check(year)&&month_check(month)&&day_check(day,month,year))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool day_check(int day, int month, int year)
        {
            bool przestepne = false;
            int x = year % 4;
            int y = year % 100;
            int z = year % 400;
            bool wynik = true;
            if(( x==0 && y!=0) || z==0)
            {
                przestepne = true;
            }
            switch(month)
            {
                case 1:
                    {
                        if (day<1 || day>31)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 2:
                    {
                        if(przestepne)
                        {
                            if (day < 1 || day > 29)
                            {
                                wynik = false;
                            }
                        }
                        else
                        {
                            if (day < 1 || day > 28)
                            {
                                wynik = false;
                            }
                        }
                        break;
                    }
                case 3:
                    { 
                        if (day < 1 || day > 31)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 4:
                    {
                        if (day < 1 || day > 30)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 5:
                    {
                        if (day < 1 || day > 31)
                        {
                            wynik = false;
                        }
                    break;
                    }
                case 6:
                    {
                        if (day < 1 || day > 30)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 7:
                    {
                        if (day < 1 || day > 31)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 8:
                    {
                        if (day < 1 || day > 31)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 9:
                    {
                        if (day < 1 || day > 30)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 10:
                    {
                        if (day < 1 || day > 31)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 11:
                    {
                        if (day < 1 || day > 30)
                        {
                            wynik = false;
                        }
                        break;
                    }
                case 12:
                    {
                        if (day < 1 || day > 31)
                        {
                            wynik = false;
                        }
                        break;
                    }
            }
            return wynik;
        }
        public static bool month_check(int month)
        {
            if(month>12 || month<0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool year_check(int year)
        {
            if (year < 1999)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
