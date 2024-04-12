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

    public class CharGenerator2 {
        private Tuple<string, int>[] symbols;
        private int sum;
        private Random random = new Random();
        public CharGenerator2(Tuple<string, int>[] _symbols) {
            symbols = _symbols;
            sum = _symbols[^1].Item2;
        }
        public string generate() {
            for (int i = 0; i < symbols.Length; i++) {
                if(random.Next(0, sum) < symbols[i].Item2) return symbols[i].Item1;
            }
            return "";
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

            string[] lines_b = File.ReadAllLines("../bigram.txt");
            Tuple<string, int>[] symbols = new Tuple<string, int>[lines_b.Length];
            int tt = 0;
            for (int i = 0; i < lines_b.Length; i++) {
                string[] line = lines_b[i].Split(' ');
                tt += int.Parse(line[1]);
                Tuple<string, int> t = Tuple.Create(line[0], tt);
                symbols[i] = t;
            }
            CharGenerator2 gen_b = new CharGenerator2(symbols);
            string res = "";
            for(int i = 0; i < 500; i++) res += gen_b.generate();
            File.WriteAllText("bigram_out.txt", res);

            string[] lines_w = File.ReadAllLines("../words.txt");
            Tuple<string, int>[] words = new Tuple<string, int>[lines_w.Length];
            tt = 0;
            for (int i = 0; i < lines_w.Length; i++) {
                string[] line = lines_w[i].Split(' ');
                tt += int.Parse(line[1]);
                Tuple<string, int> t = Tuple.Create(line[0], tt);
                words[i] = t;
            }
            CharGenerator2 gen_w = new CharGenerator2(words);
            res = "";
            for(int i = 0; i < 500; i++) res = res + gen_w.generate() + ' ';
            File.WriteAllText("words_out.txt", res);
        }
    }
}