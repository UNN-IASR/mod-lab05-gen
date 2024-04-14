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
    public class BigramGenerator
    {
        public Dictionary<string, int> data = new Dictionary<string, int>();
        private Random random = new Random();
        private int sum = 0;
        public BigramGenerator(string[] syms, int[] rate)
        {
            if (syms.Length != rate.Length) throw new Exception("wrong length");
            for (int i = 0; i < syms.Length; i++)
            {
                sum += rate[i];
                data.Add(syms[i], sum);
            }
        }
        public string getBigram()
        {
            if (data.Count == 0) throw new Exception("empty data");
            int rand = random.Next(sum);
            string result = "";
            foreach (var pair in data)
                if (rand < pair.Value)
                {
                    result = pair.Key;
                    break;
                }
            return result;
        }
    }
    public class WordGenerator
    {
        public Dictionary<string, double> data = new Dictionary<string, double>();
        private Random random = new Random();
        private double sum = 0;
        public WordGenerator(string[] syms, double[] ipm)
        {
            if (syms.Length != ipm.Length) throw new Exception("wrong length");
            for (int i = 0; i < syms.Length; i++)
            {
                sum += ipm[i];
                data.Add(syms[i], sum);
            }
        }
        public string getWord()
        {
            if (data.Count == 0) throw new Exception("empty data");
            double rand = random.NextDouble() * sum;
            string result = "";
            foreach (var pair in data)
                if (rand < pair.Value)
                {
                    result = pair.Key;
                    break;
                }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // CharGenerator gen = new CharGenerator();
            // SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            // for(int i = 0; i < 1000; i++) 
            // {
            //    char ch = gen.getSym(); 
            //    if (stat.ContainsKey(ch))
            //       stat[ch]++;
            //    else
            //       stat.Add(ch, 1); Console.Write(ch);
            // }
            // Console.Write('\n');
            // foreach (KeyValuePair<char, int> entry in stat) 
            // {
            //      Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            // }

            string[] biLines = File.ReadAllLines("files/bigrams.txt");
            string[] biSyms = new string[biLines.Length];
            int[] biRate = new int[biLines.Length];
            for (int i = 0; i < biLines.Length; i++)
            {
                biSyms[i] = biLines[i].Split()[0];
                biRate[i] = int.Parse(biLines[i].Split()[1]);
            }
            BigramGenerator biGen = new BigramGenerator(biSyms, biRate);
            string result = "";
            for (int i = 0; i < 500; i++)
            {
                result += biGen.getBigram();
            }
            File.WriteAllText("gen-1.txt", result);

            string[] wordLines = File.ReadAllLines("files/words.txt");
            string[] wordSyms = new string[wordLines.Length];
            double[] wordIpm = new double[wordLines.Length];
            for (int i = 0; i < wordLines.Length; i++)
            {
                wordSyms[i] = wordLines[i].Split()[0];
                wordIpm[i] = double.Parse(wordLines[i].Split()[1]);
            }
            WordGenerator wordGen = new WordGenerator(wordSyms, wordIpm);
            result = "";
            for (int i = 0; i < 500; i++)
            {
                result += wordGen.getWord() + " ";
            }
            File.WriteAllText("gen-2.txt", result);
        }
    }
}
