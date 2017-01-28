using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Poikkeukset
{
    class Program
    {

        static void Main(string[] args)
        {
            //Stringi joka etsii oikean polun
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //uusi lista
            List<string> persons = new List<string>();
            //Luodaan uusi StreamWriter Olio jolla on parametrinä testitiedoston polku
            StreamWriter outputFile = new StreamWriter(mydocpath + @"\test.txt");
            
            bool result = true;

            while (result)
            {

                Console.Write("Anna nimiä ja halutessassi lopettaa kirjoita 'LOPETA' ");
                string line = Console.ReadLine();



                if (line == "LOPETA")
                {
                    result = false;
                }
                else
                {
                    persons.Add(line);
                }

            }
            //kokeillaan foreachia ja otetaan koppia erroreista
            try
            {

                foreach (string nimi in persons)
                {
                    outputFile.WriteLine(nimi.ToString());
                }
               

            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Can't open file for writing (UnauthorizedAccessException)");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Opened stream is null (ArgumentNullException)");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Opened stream is not writable (ArgumentException)");
            }
            catch (IOException)
            {
                Console.WriteLine("An IO error happend (IOException)");
            }
            catch (Exception)
            {
                Console.WriteLine("Some other exception happend (Exception)");
            }
            finally
            {
                // check for null because OpenWrite might have failed
                if (outputFile != null)
                {
                    outputFile.Close();
                }
            }
            try{
                string text = System.IO.File.ReadAllText(mydocpath + @"\test.txt");
                System.Console.WriteLine("Contents of test.txt:\n" + text);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found (FileNotFoundException)");
            }
        }
    }
}
