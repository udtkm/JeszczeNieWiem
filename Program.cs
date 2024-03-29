using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

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
                Console.WriteLine("1. Wybierz plik wejściowy");
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
                    //delete files
                    try
                    {
                        System.IO.File.Delete(@"2.txt");
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine("błąd przy usuwaniu pliku");
                        return;
                    }
                    try
                    {
                        System.IO.File.Delete(@"statystyki.txt");
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine("błąd przy usuwaniu pliku");
                        return;
                    }
                    break;
                }
                if (n == 1)
                {
                    Console.WriteLine("Czy pobrać plik z internetu ? [T/N]");
                    char t = Convert.ToChar(Console.ReadLine());
                    if (t == 't' | t == 'T')
                    {
                        Console.WriteLine("Podaj adres pliku");
                        string address = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Podaj nazwę pliku");
                        string nazwapliku = Convert.ToString(Console.ReadLine());
                        WebClient webClient = new WebClient();
                        try
                        {
                            webClient.DownloadFile(address, "2.txt");
                        }
                        catch (WebException e)
                        {
                            Console.WriteLine("Podaj prawidłowe dane");
                        }
                    }
                    else
                    {


                        string filename;
                        Console.WriteLine("Podaj nazwę pliku");
                        filename = Console.ReadLine();
                        if (File.Exists(filename))
                        {
                            File.OpenRead(filename);
                            Console.WriteLine("Plik został otwarty!");
                        }
                        else
                        {
                            Console.WriteLine($"Podany plik '{filename}' nie istnieje w ścieżce {Directory.GetCurrentDirectory()}");
                        }
                    }


                }
                if (n == 2)
                {

                    Console.Clear();
                    try
                    {
                        /* changing comment for automatic close issue */
                        string text = System.IO.File.ReadAllText(@"2.txt");
                        if (text != null)
                        {
                            if (text == null)
                            {
                                Console.WriteLine("nie pobrano pliku");
                                break;
                            }
                            int vowel = 0;
                            int consonants = 0;
                            foreach (char y in text)
                            {
                                string x = Convert.ToString(y);
                                if (x != "," && x != "." && x != ";" && x != "'" && x != "?" && x != "!" && x != "-" && x != ":" && x != " ")
                                {

                                    if (x == "a" || x == "A" || x == "ą" || x == "Ą" || x == "e" || x == "E" || x == "ę" || x == "Ę" || x == "i" || x == "I" || x == "o" || x == "O" || x == "ó" || x == "Ó" || x == "u" || x == "U" || x == "y" || x == "Y")
                                    {
                                        vowel++;
                                    }
                                    else
                                    {
                                        consonants++;
                                    }

                                }

                            }
                            Console.WriteLine("Ilość samogłosek w pliku : " + vowel);
                            Console.WriteLine("Ilość spółgłosek w pliku : " + consonants);
                        }

                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }


                }

                if (n == 3)
                {
                    //counting letters
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
                            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            int words = 0;
                            foreach (string word in source)
                            {
                                if (word.Length > 1)
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
                    /* counting punctuation marks*/
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
                                if (x == "," || x == "." || x == "?")
                                {
                                    tmp++;

                                }

                            }

                            Console.WriteLine("Ilość znaków interpunkcyjnych(?,.) = " + tmp);
                        }

                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }


                }

                if (n == 5)
                {
                    //counting sentences
                    Console.Clear();
                    try
                    {
                        string text = System.IO.File.ReadAllText(@"2.txt");
                        if (text != null)
                        {
                            int tmp = 0;
                            for (int i = 0; i < text.Length; i++)
                            {

                                if (text[i] == '.' || text[i] == '?')
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

                if (n == 6)
                {
                    string text = System.IO.File.ReadAllText(@"2.txt");
                    Console.Clear();
                    try     //liczenie samogłosek
                    {

                        if (text != null)
                        {

                            int[] character = new int[(int)char.MaxValue];

                            foreach (char tp in text)
                            {

                                character[(int)tp]++;
                            }

                            Console.WriteLine("SAMOGŁOSKI: ");
                            for (int i = 0; i < (int)char.MaxValue; i++)
                            {


                                if ((char)i == 'a' || (char)i == 'A' || (char)i == 'E' || (char)i == 'e' || (char)i == 'i' || (char)i == 'I' || (char)i == 'O' || (char)i == 'o' || (char)i == 'u' || (char)i == 'U' || (char)i == 'y' || (char)i == 'Y')
                                {
                                    if (character[i] > 0 && char.IsLetterOrDigit((char)i))
                                    {
                                        Console.WriteLine("{0},{1}", (char)i, character[i]);
                                    }
                                }

                            }


                        }
                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }



                    try             //liczenie spółgłosek
                    {

                        if (text != null)
                        {

                            int[] character = new int[(int)char.MaxValue];

                            foreach (char tp in text)
                            {

                                character[(int)tp]++;
                            }

                            Console.WriteLine("SPÓŁGŁOSKI: ");
                            for (int i = 0; i < (int)char.MaxValue; i++)
                            {


                                if ((char)i != 'a' && (char)i != 'A' && (char)i != 'E' && (char)i != 'e' && (char)i != 'i' && (char)i != 'I' && (char)i != 'O' && (char)i != 'o' && (char)i != 'u' && (char)i != 'U' && (char)i != 'y' && (char)i != 'Y' && (char)i != '1' && (char)i != '2' && (char)i != '3' && (char)i != '4')
                                {
                                    if (character[i] > 0 && char.IsLetterOrDigit((char)i))
                                    {
                                        Console.WriteLine("{0},{1}", (char)i, character[i]);
                                    }
                                }

                            }


                        }
                    }

                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }
                    int iloscwyrazow = 0;
                    int ilosczdan = 0;

                    try
                    {
                        foreach (char znak in text)
                        {

                            if (znak == '.' || znak == '!' || znak == '?')
                            {
                                ilosczdan++;

                            }

                        }

                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("błąd przy liczeniu zdan");

                    }
                    Console.WriteLine("Ilosc zdañ w pliku: " + ilosczdan);


                    try
                    {
                        foreach (char znak in text)
                        {

                            if (znak == ' ')
                            {
                                iloscwyrazow++;

                            }

                        }

                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("błąd przy liczeniu wyrazów");

                    }
                    Console.WriteLine("Ilosc zdañ w wyrazow: " + iloscwyrazow);

                }



                if (n == 7)
                {
                    try
                    {
                        string text = System.IO.File.ReadAllText(@"2.txt");
                        int sentences = 0;
                        int punMarks = 0;
                        int letters = 0;
                        int words = 0;
                        foreach (char znak in text)
                        {

                            if (znak == '.' || znak == '!' || znak == '?')
                            {
                                sentences++;

                            }
                            if (znak == ',' || znak == '.' || znak == ';' || Convert.ToString(znak) == "'" || znak == '?' || znak == '!' || znak == '-' || znak == ':')
                            {
                                punMarks++;

                            }

                            if (Convert.ToString(znak) != "," && Convert.ToString(znak) != "." && Convert.ToString(znak) != ";" && Convert.ToString(znak) != "'" && Convert.ToString(znak) != "?" && Convert.ToString(znak) != "!" && Convert.ToString(znak) != "-" && Convert.ToString(znak) != ":")
                            {
                                letters++;

                            }

                            if (Convert.ToString(znak) == " ")
                            {
                                words++;

                            }



                        }
                        string path = @"statystyki.txt";
                        StreamWriter sw = new StreamWriter(path);
                        sw.WriteLine("ILość liter w pliku = " + letters);
                        sw.WriteLine("ILość wyrazów w pliku = " + words);
                        sw.WriteLine("ILość znakow interpunkcyjnych  w pliku = " + punMarks);
                        sw.WriteLine("ILość zdań w pliku = " + sentences);
                        sw.Close();
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("Błąd, nie znaleziono pliku, najpierw pobierz plik");
                    }
                }
            }
        }
    }
}