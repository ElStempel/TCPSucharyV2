using System;
using System.Collections;
using System.IO;

namespace TCPserverLibrary
{
    /// <summary>
    /// Klasa Joke - przechowuje i wybiera suchary.
    /// </summary>
    public class Joke
    {
        /// <summary>
        /// Suchary przechowywane w ArrayList
        /// </summary>
        ArrayList suchary = new ArrayList();


        /// <summary>
        /// Konstruktor domyślny umieszcza suchary w <see cref="ArrayList"/>
        /// </summary>
        public Joke()
        {
            var file = new System.IO.StreamReader(@"Suchary.txt", System.Text.Encoding.UTF8, true, 128);
            string lineOfText;
            while ((lineOfText = file.ReadLine()) != null)
            {
                suchary.Add(lineOfText);
            }
            file.Close();
        }

        /// <summary>
        /// dodanie suchara
        /// </summary>
        /// <param name="nowy"></param>
        public void addJoke(string nowy)
        {
            suchary.Add(nowy);
            string path = @"Suchary.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(nowy);
                
            }

        }

        /// <summary>
        /// dodanie sucharów do pliku
        /// </summary>
        public void saveToFile()
        {
            string[] lines = { "Gdzie podpisano traktat wersalski?  - Na samym dole, pod tekstem.", "Co sie po jednej stronie glaszcze a po drugiej lize??  - Nie wiem.  -... znaczek pocztowy!", "Co sie stanie jak walec drogowy przejedzie czlowieka?  - Konwersja obrazu z 3D na 2D", "Jak sie nazywa mnich odpowiedzialny za podatki?  - Brat PIT.", "Jaka jest ulubiona zabawa dzieci grabarza?   - W chowanego.", "Co robi elektryk na scenie?  - Buduje napiecie.", "Jaki jest ulubiony owoc zolnierza?  - Granat." };
            System.IO.File.WriteAllLines(@"Suchary.txt", lines);
        }

        /// <summary>
        /// Metoda wybierająca suchary z puli.
        /// </summary>
        /// <returns></returns>
        public string genJoke()
        {
            Random rnd = new Random();
            int indeks = rnd.Next(0, suchary.Count);
            string suchar = (string)suchary[indeks];

            return suchar;
        }
    }
}
