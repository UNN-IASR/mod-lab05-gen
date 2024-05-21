using System;
using System.Collections.Generic;
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
    }

    public class TextGenerator {
        private string[] words;
        private double[] prefixSum;
        private Random random = new Random();

        public TextGenerator() {
            words = new string[0];
            prefixSum = new double[0];
        }

        public TextGenerator(string[] words, double[] values) {
            if (words.Length != values.Length) {
                Console.WriteLine("The number of words should be the same as the number of values.");
            }

            this.words = words;
            this.prefixSum = CalculatePrefixSum(values);
        }

        public void LoadFromFile(string filename) {
            string[] lines = File.ReadAllLines(filename);
            int length = lines.Length;

            this.words = new string[length];
            double[] values = new double[length];

            for (int i = 0; i < length; i++) {
                string[] parts = lines[i].Split(' ');
                this.words[i] = parts[0];
                values[i] = double.Parse(parts[1]);
            }

            this.prefixSum = CalculatePrefixSum(values);
        }

        private double[] CalculatePrefixSum(double[] values) {
            double[] result = new double[values.Length];
            double sum = 0;

            for (int i = 0; i < values.Length; i++) {
                sum += values[i];
                result[i] = sum;
            }

            return result;
        }

        public string GetSym() {
            double value = random.NextDouble() * prefixSum[prefixSum.Length - 1];
            int index = Array.BinarySearch(prefixSum, value);
            if (index < 0) {
                index = ~index;
            }

            return words[Math.Min(index, words.Length - 1)];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();
            for(int i = 0; i < 1000; i++) 
            {
                char ch = gen.getSym(); 
                if (dict.ContainsKey(ch))
                    dict[ch]++;
                else
                    dict.Add(ch, 1); Console.Write(ch);
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in dict) 
            {
                Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            }

            string result1, result2;
            result1 = result2 = "";
            TextGenerator generator = new TextGenerator();

            generator.LoadFromFile("../../../../ProjCharGenerator/data1.txt");
            for (int i = 0; i < 1000; i++) {
                result1 += generator.GetSym();
            }
            File.WriteAllText("gen1.txt", result1);

            generator.LoadFromFile("../../../../ProjCharGenerator/data2.txt");
            for (int i = 0; i < 1000; i++) {
                result2 += generator.GetSym();
                result2 += " ";
            }
            File.WriteAllText("gen2.txt", result2);

        }
    }
}

