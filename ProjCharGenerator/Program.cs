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
    public class TextGenerator
    {
        private string[] words;
        private double[] weightSum;
        private Random random= new Random();

        public TextGenerator() { }

        public TextGenerator(string[] words, double[] values)
        {
            this.words = words;
            weightSum = new double[words.Length];
            weightSum[0] = values[0];
            for (int i = 1; i < words.Length; i++)
            {
                weightSum[i] = weightSum[i - 1] + values[i];
            }
        }

        public void FileLoading(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            words = new string[lines.Length];
            weightSum = new double[lines.Length];
            string[] parseParts = lines[0].Split(' ');
            words[0] = parseParts[0];
            weightSum[0] = double.Parse(parseParts[1]);

            for(int i = 1; i < lines.Length; i++)
            {
                parseParts = lines[i].Split(' ');
                words[i] = parseParts[0];
                weightSum[i] = weightSum[i - 1] + double.Parse(parseParts[1]);
            }
        }

        public string getSum()
        {
            int size = weightSum.Length;
            double value = random.NextDouble() * weightSum[size - 1];

            for (int i = 0; i < size; i++)
            {
                if (value < weightSum[i])
                {
                    return words[i];
                }
            }
            return null;
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

