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
    public class DzGenerator1
    {
        private int[] data; // массив сумм предыдущие+ текущий
        private string[] pairs; // пары символов
        private int CurrentSum; //тек сумма
        private Random random = new Random();
        public DzGenerator1()  
        {
            CurrentSum = 0;
        }
        public string Complete()
        {
            int CurrId = 0;
            for (int i = 0; i < pairs.Length; i++)
            {
                if (random.Next(0, CurrentSum) < data[i])
                {
                    CurrId = i;
                    break;
                }
            }
            return pairs[CurrId];
        }
        public void ReadFile(string name)
        {
            string[] lines = File.ReadAllLines(name);
            pairs = new string[lines.Length];
            data = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] strings = lines[i].Split(' ');
                pairs[i] = strings[0];
                CurrentSum += int.Parse(strings[1]);
                data[i] = CurrentSum;
            }
        }
    }
    public class DzGenerator2
    {
        private double[] data; // массив сумм предыдущие+ текущий
        private string[] pairs; // пары символов
        private double CurrentSum; //тек сумма
        private Random random = new Random();
        public DzGenerator2()  
        {
            CurrentSum = 0;
        }
        public string Complete()
        {
            int CurrId = 0;
            for (int i = 0; i < pairs.Length; i++)
            {
                if (random.Next(0, Convert.ToInt32(CurrentSum)) < data[i])
                {
                    CurrId = i;
                    break;
                }
            }
            return pairs[CurrId];
        }
        public void ReadFile(string name)
        {
            string[] lines = File.ReadAllLines(name);
            pairs = new string[lines.Length];
            data = new double[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] strings = lines[i].Split(' ');
                pairs[i] = strings[0];
                CurrentSum += double.Parse(strings[1]);
                data[i] = CurrentSum;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for (int i = 0; i < 1000; i++)
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
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
            }

            DzGenerator1 Dz1 = new DzGenerator1();
            DzGenerator2 Dz2 = new DzGenerator2();
            string res1 = "", res2 = "";
            Dz1.ReadFile("words1.txt");
            for (int i = 0; i < 1000; i++)
            {
                res1 += Dz1.Complete();
            }
            File.WriteAllText("gen-1.txt", res1);
            Dz2.ReadFile("words2.txt");
            for (int i = 0; i < 1000; i++)
            {
                res2 += Dz2.Complete();
                res2 += " ";
            }
            File.WriteAllText("gen-2.txt", res2);
        }
    }
}