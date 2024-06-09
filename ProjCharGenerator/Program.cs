using System;
using System.Collections.Generic;
using System.IO;

namespace lab5
{
    public class CharGenerator
    {
        private string s = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] arr;
        private int count;
        private Random ran = new Random();

        public CharGenerator()
        {
            count = s.Length;
            arr = s.ToCharArray();
        }

        public char getSum()
        {
            return arr[ran.Next(0, count)];
        }
    }

    public class TextGenerator
    {
        private string[] letters;
        private double[] wS;
        private Random ran = new Random();

        public TextGenerator() { }

        public TextGenerator(string[] w, double[] val)
        {
            this.letters = w;
            wS = new double[w.Length];
            wS[0] = val[0];
            for (int i = 1; i < w.Length; i++)
            {
                wS[i] = wS[i - 1] + val[i];
            }
        }

        public void FileLoading(string name)
        {
            string[] str = File.ReadAllLines(name);
            letters = new string[str.Length];
            wS = new double[str.Length];
            string[] parseParts = str[0].Split(' ');
            letters[0] = parseParts[0];
            wS[0] = double.Parse(parseParts[1]);

            for (int i = 1; i < str.Length; i++)
            {
                parseParts = str[i].Split(' ');
                letters[i] = parseParts[0];
                wS[i] = wS[i - 1] + double.Parse(parseParts[1]);
            }
        }

        public string getSum()
        {
            int count = wS.Length;
            double value = ran.NextDouble() * wS[count - 1];

            for (int i = 0; i < count; i++)
            {
                if (value < wS[i])
                {
                    return letters[i];
                }
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gener = new CharGenerator();
            SortedDictionary<char, int> stats = new SortedDictionary<char, int>();

            for (int i = 0; i < 100; i++)
            {
                char ch = gener.getSum();
                if (stats.ContainsKey(ch))
                    stats[ch]++;
                else
                    stats.Add(ch, 1);
                Console.WriteLine(ch);
            }

            foreach (KeyValuePair<char, int> entry in stats)
            {
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
            }

            string resultLines1, resultLines2;
            resultLines1 = resultLines2 = "";

            TextGenerator generator = new TextGenerator();
            generator.FileLoading("Data1.txt");

            for (int i = 0; i < 1000; i++)
            {
                resultLines1 += generator.getSum();
            }

            File.WriteAllText("gen-1.txt", resultLines1, System.Text.Encoding.Unicode);
            generator.FileLoading("Data2.txt");

            for (int i = 0; i < 1000; i++)
            {
                resultLines2 += generator.getSum();
            }

            File.WriteAllText("gen-2.txt", resultLines2, System.Text.Encoding.UTF8);
        }
    }
}
