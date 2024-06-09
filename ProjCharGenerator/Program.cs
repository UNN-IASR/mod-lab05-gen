using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ProjCharGenerator;

namespace generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator genChar = new BigrammChar();
            Generator genWord = new BigrammWord();

            string charStr = genChar.GetText(1000);
            string wordStr = genWord.GetText(1000);

            Console.WriteLine("Generated sequence of letters: ");
            Console.WriteLine(charStr);

            Console.WriteLine("\nGenerated sequence of words: ");
            Console.WriteLine(wordStr);

            string pathSave = "result\\";
            FileSave(pathSave + "gen-1.txt", charStr);
            FileSave(pathSave + "gen-2.txt", wordStr);

            Console.ReadLine();
        }

        static void FileSave(string path, string text)
        {
            if (!File.Exists(path))
            {
                var file = File.Create(path);
                file.Close();
            }

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(text);
            sw.Close();
        }
    }
}
