using System;
using System.Collections.Generic;

namespace ProjCharGenerator
{
    class CharGenerator 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator() 
        {
           size = syms.Length;
           data = syms.ToCharArray(); 
        }
        public char getSym() 
        {
           return data[random.Next(0, size)]; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Bigrams test = new Bigrams(r);
            string res1 = test.GetText(1000);
            Console.WriteLine(res1);
            test.WriteToFile(@"Output/BigramsOutput.txt", res1);

            Console.WriteLine();
            Words test1 = new Words(r);
            string res2 = test1.GetText(1000);
            Console.WriteLine(res2);
            Console.WriteLine();
            test1.WriteToFile(@"Output/WordGen.txt", res2);

            WordPairs test2 = new WordPairs(r);
            string res3 = test2.GetText(1000);
            Console.WriteLine(res3);
            Console.WriteLine();
            test2.WriteToFile(@"Output/PairsGen.txt", res3);
        }
    }
}

