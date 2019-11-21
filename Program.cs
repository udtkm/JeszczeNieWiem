using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while (n != 8)
            {
                Console.WriteLine("1. Pobierz plik z internetu");
                Console.WriteLine("2. Zlicz liczbę liter w podanym pliku");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku");
                Console.WriteLine("4. Zlicz liczbę znaków interpukcyjnych w pliku");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter (A-Z)");
                Console.WriteLine("7. Zapisz statystyki z punktów 2-5 do pliku statystyki.txt");
                Console.WriteLine("8. Wyjście z programu");
                n = Convert.ToInt32(Console.ReadLine());
                if (n == 8)
                {
                    break;
                }
                if(n==1)
                {

                    WebClient webClient = new WebClient();
                    try
                    {
                        webClient.DownloadFile("https://s3.zylowski.net/public/input/2.txt", "2.txt");
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine("Błąd nie pobrało pliku");
                    }
                }
                Console.ReadKey();


            }
        }
    }
}
