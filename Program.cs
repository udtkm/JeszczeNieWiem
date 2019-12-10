﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while (n != 8)
            {
                /* for issue #1 editing text in comment */
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
                        Console.WriteLine("Błąd przy pobraniu pliku");
                    }
                }
                if (n == 2)
                {

                    Console.Clear();
                    try
                    {
                        string text = System.IO.File.ReadAllText(@"2.txt");
                        if (text != null)
                        {
                            if (text == null)
                            {
                                Console.WriteLine("nie pobrano pliku");
                                break;
                            }
                            int tmp = 0;
                            foreach (char y in text)
                            {
                                string x = Convert.ToString(y);
                                if (x != "," && x != "." && x != ";" && x != "'" && x != "?" && x != "!" && x != "-" && x != ":")
                                {
                                    tmp++;

                                }

                            }
                            Console.WriteLine("Ilość liter w pliku : " + tmp);
                        }

                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }


                }

                if (n == 3)
                {

                    Console.Clear();
                    try
                    {
                        string text = System.IO.File.ReadAllText(@"2.txt");
                        if (text != null)
                        {
                            if (text == null)
                            {
                                Console.WriteLine("nie pobrano pliku");
                                break;
                            }
                            int words = 0;
                            foreach (char znak in text)
                            {
                                string x = Convert.ToString(znak);
                                if (x==" ")
                                {
                                    words++;

                                }

                            }
                            Console.WriteLine("Ilość wyrazów w pliku = " + words);
                        }

                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }


                }

                if (n == 4)
                {
                    /* na potrzeby pull requesta*/
                    try
                    {
                        string text = System.IO.File.ReadAllText(@"2.txt");
                        if (text != null)
                        {
                            if (text == null)
                            {
                                Console.WriteLine("nie pobrano pliku");
                                break;
                            }
                            int tmp = 0;
                            foreach (char znak in text)
                            {
                                string x = Convert.ToString(znak);
                                if (x == "," || x == "." || x == ";" || x == "'" || x == "?" || x == "!" || x == "-" || x == ":")
                                {
                                    tmp++;

                                }

                            }

                            Console.WriteLine("Ilość znaków interpunkcyjnych = " + tmp);
                        }

                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }


                }

                if (n == 5)
                {

                    Console.Clear();
                    try
                    {
                        string text = System.IO.File.ReadAllText(@"2.txt");
                        if (text != null)
                        {
                            int tmp = 0;
                            foreach (char znak in text)
                            {

                                if (znak == '.' || znak == '!' || znak == '?')
                                {
                                    tmp++;

                                }

                            }
                            Console.WriteLine("Ilość zdań w pliku = " + tmp);
                        }

                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }




                }
                if (n == 7)
                {
                    string text = System.IO.File.ReadAllText(@"2.txt");
                    int iloscZdan = 0;
                    int iloscZnakow =0;
                    foreach (char znak in text)
                    {

                        if (znak == '.' || znak == '!' || znak == '?')
                        {
                            iloscZdan++;

                        }
                        if (znak == ',' || znak == '.' || znak == ';' || Convert.ToString(znak) == "'" || znak == '?' || znak == '!' || znak == '-' || znak == ':')
                        {
                            iloscZnakow++;

                        }


                    }
                    string path = @"statystyki.txt";
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine("ILość znakow interpunkcyjnych  w pliku = " + iloscZnakow);
                    sw.WriteLine("ILość zdań w pliku = " + iloscZdan);
                    sw.Close();

                }
            }
        }
    }
}
