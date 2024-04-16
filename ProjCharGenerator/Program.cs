using generator;
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
    public class Generator1
    {

        public string[] letters; // пары букв
        public int[] summ; //массив сумм 
        public int current_sum; //текущая сумма
        public Generator1(string[] letters_1, int[] summ_1)
        {
            letters = letters_1;
            summ = summ_1;
        }
        public string getStr()
        {
            Random random = new Random();
            int randnum = random.Next(0, summ[^1]);
            string res = "";
            for (int i = 0; i < letters.Length; i++)
            {
                if (randnum < summ[i])
                {
                    res = letters[i];
                    break;
                }
            }
            return res;
        }
    }

    public class Generator2
    {

        public string[] letters; // пары букв
        public double[] summ; //массив сумм 
        public int currentSum; //текущая сумма
        public Generator2(string[] letters_1, double[] summ_1)
        {
            letters = letters_1;
            summ = summ_1;
        }
        public string getStr()
        {
            Random random = new Random();
            double randnum = random.Next(0, Convert.ToInt32(summ[^1]));
            string res = "";
            for (int i = 0; i < letters.Length; i++)
            {
                if (randnum < summ[i])
                {
                    res = letters[i];
                    break;
                }
            }
            return res;
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

        string[] letters; // пары букв
        int[] summ; //массив сумм 
        int current_sum = 0; //текущая сумма
        string[] lines = File.ReadAllLines("words1.txt");
        letters = new string[lines.Length];
        summ = new int[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] strings = lines[i].Split(' ');
            letters[i] = strings[0];
            current_sum += int.Parse(strings[1]);
            summ[i] = current_sum;
        }
        Generator1 Gen1 = new Generator1(letters, summ);
        string res1 = "";
        for (int i = 0; i < 1000; i++)
        {
            res1 += Gen1.getStr();
        }
        File.WriteAllText("Gen1.txt", res1);

        string[] letters1; // пары букв
        double[] summ1; //массив сумм 
        double current_sum1 = 0; //текущая сумма
        string[] lines1 = File.ReadAllLines("words2.txt");
        letters1 = new string[lines1.Length];
        summ1 = new double[lines1.Length];
        for (int i = 0; i < lines1.Length; i++)
        {
            string[] strings1 = lines1[i].Split(' ');
            letters1[i] = strings1[0];
            current_sum1 += double.Parse(strings1[1]);
            summ1[i] = current_sum1;
        }
        Generator2 Gen2 = new Generator2(letters1, summ1);
        string res2 = "";
        for (int i = 0; i < 1000; i++)
        {
            res2 += Gen2.getStr();
        }
        File.WriteAllText("Gen2.txt", res2);
    }
}