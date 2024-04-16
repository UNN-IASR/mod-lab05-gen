using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    public class CharGenerator
    {
        public string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
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
        public string[] combinations;
        public int[] Summ;
        private int size;
        private Random rand = new Random();
        public Generator1() { int size = 0; }
        public Generator1(string[] combinations, int[] values)
        {
            this.combinations = combinations;
            Summ = new int[combinations.Length];
            Summ[0] = values[0];
            for (int i = 0; i < combinations.Length; i++)
            {
                Summ[i] = Summ[i - 1] + values[i];
            }

        }

        public void read_file(string name)
        {
            string[] str = File.ReadAllLines(name);
            combinations = new string[str.Length];
            Summ = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                string[] strr = str[i].Split(' ');
                combinations[i] = strr[0];
                size += int.Parse(strr[1]);
                Summ[i] = size;
            }
        }
        public string getSymm()
        {
            int sym = 0;
            for (int i = 0; i < combinations.Length; i++)
            {
                if (rand.Next(0, size) < Summ[i])
                {
                    sym = i;
                    break;
                }
            }
            return combinations[sym];
        }

    }
    public class Generator2
    {
        private string[] combinations;
        private double[] Summ;
        private double size = 0;
        private Random rand = new Random();
        public Generator2() { int size = 0; }
        public Generator2(string[] combinations, double[] values)
        {
            this.combinations = combinations;
            Summ = new double[combinations.Length];
            Summ[0] = values[0];
            for (int i = 0; i < combinations.Length; i++)
            {
                Summ[i] = Summ[i - 1] + values[i];
            }

        }

        public void read_file(string name)
        {
            string[] str = File.ReadAllLines(name);
            combinations = new string[str.Length];
            Summ = new double[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                string[] strr = str[i].Split(' ');
                combinations[i] = strr[0];
                size += double.Parse(strr[1]);
                Summ[i] = size;
            }
        }
        public string getSymm()
        {
            int sym = 0;
            for (int i = 0; i < combinations.Length; i++)
            {
                if (rand.Next(0, Convert.ToInt32(size)) < Summ[i])
                {
                    sym = i;
                    break;
                }
            }
            return combinations[sym];
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

            Generator1 gen1 = new Generator1();
            Generator2 gen2 = new Generator2();
            string gen_res1 = " ";
            gen1.read_file("file1.txt");
            for (int i = 0; i < 1000; i++)
            {
                gen_res1 += gen1.getSymm();
            }
            File.WriteAllText("gen-1.txt", gen_res1);
            string gen_res2 = " ";
            gen2.read_file("file2.txt");
            for (int j = 0; j < 1000; j++)
            {
                gen_res2 += gen2.getSymm();
                gen_res2 += " ";
            }
            File.WriteAllText("gen-2.txt", gen_res2);
        }
    }
}