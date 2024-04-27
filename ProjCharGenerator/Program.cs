using System;
using System.Collections.Generic;
using System.IO;

namespace ProjCharGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for(int i = 0; i < 1000; i++) 
            {
               char ch = gen.getSymbol(); 
               if (stat.ContainsKey(ch))
                  stat[ch]++;
               else
                  stat.Add(ch, 1); Console.Write(ch);
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat) 
            {
                 Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0);
            }

            Generator generator1 = new Generator("../../../../bigram.txt");
            string resultBigram = "";
            for (int i = 0; i < 1000; i++)
            {
                resultBigram += generator1.getPartOfText();
            }
            File.WriteAllText("../../../../gen-1.txt", resultBigram, System.Text.Encoding.UTF8);

            Generator generator2 = new Generator("../../../../words.txt");
            string resultWords = "";
            for (int i = 0; i < 1000; i++)
            {
                resultWords += generator2.getPartOfText() + " ";
            }
            File.WriteAllText("../../../../gen-2.txt", resultWords, System.Text.Encoding.UTF8);
        }
    }
}

