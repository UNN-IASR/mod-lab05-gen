using System;
using System.Collections.Generic;
using System.IO;

namespace generator
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

    class CharGenerator1
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public static string filePath = "...\\file.txt";
        public int[,] Weights { get; set; }
        public CharGenerator1()
        {
            size = syms.Length;
            data = syms.ToCharArray();
        }

        public char getSym1()
        {
            char c = data[random.Next(0, size)];  
            return c;
        }
        public char getSym2()
        {
            char sym1 = getSym1();
            int ind1 = Array.IndexOf(data, sym1);
            int sumW = SumWeights(ind1);
            Random rand = new Random();
            int weight = rand.Next(1, sumW);
            int ind2 = 0;
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += Weights[ind1, i];
                if (sum >= weight & Weights[ind1, i] != 0)
                {
                    ind2 = i;
                    break;
                }
            }
            char sym2 = data[ind2];
            return sym2;
        }
        public int SumWeights(int ind)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += Weights[ind, i];
            }
            return sum;
        }
        public void ReadFile()
        {
            //var list = new List<string>();
            string line;
            StreamReader sr = new StreamReader(filePath);
            line = sr.ReadLine();
            int i = 0;
            Weights = new int[syms.Length, syms.Length];
            while (line != null)
            {
                string[] buffer = line.Split('\t');              
                for (int j = 0; j < buffer.Length; j++)
                {
                    Weights[i, j] = int.Parse(buffer[j]);
                }
                line = sr.ReadLine();
                i++;
            }
            sr.Close();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator1 gen = new CharGenerator1();
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            gen.ReadFile(); 
            for (int i = 0; i < 500; i++)
            {
                char ch1 = gen.getSym1();
                char ch2 = gen.getSym2();
                string bi = "";
                bi += ch1;
                bi += ch2;
                if (stat.ContainsKey(bi))
                    stat[bi]++;
                else
                    stat.Add(bi, 1);
                Console.Write(bi);
                Console.Write(' ');
            }
            Console.Write('\n');
            foreach (KeyValuePair<string, int> entry in stat) 
            {
                 Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            }         
        }
    }
}
