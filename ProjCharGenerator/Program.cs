using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;

namespace generator
{
    public class CharGenerator
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
        public int getSize()
        {
            return size;
        }
        public bool isCharInData(char sym)
        {
            return Array.IndexOf(data, sym) != -1;
        }
    }

    public class BinGenerator
    {
        private Dictionary<string, int> data;
        private int size;
        private int summa;
        private int[] np;
        private Random random = new Random();
        public BinGenerator()
        {
            string[] linearr;
            data = new Dictionary<string, int>();
            foreach (string line in File.ReadLines("data.csv"))
            {
                linearr = line.Split(',');
                data.Add(linearr[0], Convert.ToInt32(linearr[1]));
            }
            size = data.Count;
            summa = 0;
            np = new int[size]; //верхние границы
            int i = 0;
            foreach (string key in data.Keys)
            {
                summa += data[key];
                np[i] = summa;
                i++;
            }
        }
        public string getBigram()
        {
            int num = random.Next(0, summa);
            int j = 0;
            string answkey = "";
            foreach (string key in data.Keys)
            {
                if (num < np[j])
                {
                    answkey = key;
                    break;
                }
                j++;
            }
            return answkey;
        }
        public int getSize()
        {
            return size;
        }
        public bool isBigramInData(string s)
        {
            return data.ContainsKey(s);
        }
    }

    public class WordGenerator
    {
        private Dictionary<string, int> data;
        private int size;
        private int summa;
        private int[] np;
        private Random random = new Random();
        public WordGenerator()
        {
            string[] linearr;
            data = new Dictionary<string, int>();
            foreach (string line in File.ReadLines("data2.csv"))
            {
                linearr = line.Split(';');
                data.Add(linearr[1], Convert.ToInt32(linearr[2]));
            }
            size = data.Count;
            summa = 0;
            np = new int[size]; //верхние границы
            int i = 0;
            foreach (string key in data.Keys)
            {
                summa += data[key];
                np[i] = summa;
                i++;
            }
        }
        public string getWord()
        {
            int num = random.Next(0, summa);
            int j = 0;
            string answkey = "";
            foreach (string key in data.Keys)
            {
                if (num < np[j])
                {
                    answkey = key;
                    break;
                }
                j++;
            }
            return answkey;
        }
        public int getSize()
        {
            return size;
        }
        public bool isWordInData(string s)
        {
            return data.ContainsKey(s);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            BinGenerator bingen = new BinGenerator();
            WordGenerator wgen = new WordGenerator();

            StreamWriter writer1 = new StreamWriter("../Data/out1.txt", false);
            for (int i = 1; i < 1001; i++)
            {
                char ch = gen.getSym();
                writer1.Write(ch);
                if (i % 50 == 0) writer1.Write("\n");
            }
            writer1.Close();

            StreamWriter writer2 = new StreamWriter("../gen-1.txt", false);
            for (int i = 1; i < 1001; i++)
            {
                string bin = bingen.getBigram();
                writer2.Write(bin);
                if (i % 100 == 0) writer2.Write("\n");
            }
            writer2.Close();

            StreamWriter writer3 = new StreamWriter("../gen-2.txt", false);
            for (int i = 1; i < 1001; i++)
            {
                string word = wgen.getWord();
                writer3.Write(word);
                if (i % 100 == 0) writer3.Write("\n");
            }
            writer3.Close();

        }
    }
}
