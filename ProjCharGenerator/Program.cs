using System;
using System.Collections.Generic;

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
    public class Generator
    {
        private Random random = new Random();
        private int[] weight;
        private string[] words;
        private int sum;
        public Generator(string file)
        {
            sum = 0;
            string[] linesStr=File.ReadAllLines(file);
            int len=linesStr.Length;
            this.words = new string[len];
            this.weight = new int[len];
            for(int i = 0; i < len; i++)
            {
                string[] split = linesStr[i].Split(' ');
                this.words[i] = split[0];
                sum += int.Parse(split[1]);
                this.weight[i] = sum;
            }
        }
        public string ResultText()
        {
            int rand = random.Next(0, sum);
            for(int i = 0;i < words.Length;i++)
            {
                if (rand < weight[i])return words[i];
            }
            return "";
        }
        public int getSum()
        {
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for(int i = 0; i < 1000; i++) 
            {
               char ch = gen.getSym(); 
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
            Generator generator=new Generator("bigram_in.txt");
            string result_bigram = "";
            string result_words = "";
            for(int i = 0; i < 500; i++)
            {
                result_bigram += generator.ResultText();
            }
            File.WriteAllText("gen-1.txt", result_bigram);
            Generator generator1 = new Generator("words_in.txt");
            for(int i = 0;i < 1000; i++)
            {
                result_words += generator1.ResultText();
                result_words += " ";
            }
            File.WriteAllText("gen-2.txt", result_words);
        }
    }
}

