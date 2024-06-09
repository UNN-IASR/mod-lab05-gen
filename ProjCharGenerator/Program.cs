using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    public class Generator_char
    {
        private string syms = "абвгдёежзийклмнопростуфхцчшщъыьэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public Generator_char()
        {
            size = syms.Length;
            data = syms.ToCharArray();
        }
        public char Get_symb()
        {
            return data[random.Next(0, size)];
        }
    }

    public class Generator_text
    {
        private double[] sum;
        private string[] words;

        private Random random = new Random();
        public Generator_text()
        {

        }
        public Generator_text(string[] words, double[] values)
        {
            this.words = words;
            sum = new double[words.Length];
            sum[0] = values[0];
            for (int i = 1; i < words.Length; i++)
            {
                sum[i] = sum[i - 1] + values[i];
            }
        }

        public string Get_symb()
        {
            int size = sum.Length;
            double value = random.NextDouble() * sum[size - 1];
            for (int i = 0; i < size; i++)
            {
                if (value < sum[i])
                {
                    return words[i];
                }
            }
            return null;
        }

        public void Data_loading(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            words = new string[lines.Length];
            sum = new double[lines.Length];
            string[] parseParts = lines[0].Split(' ');
            words[0] = parseParts[0];
            sum[0] = double.Parse(parseParts[1]);
            for (int i = 1; i < lines.Length; i++)
            {
                parseParts = lines[i].Split(' ');
                words[i] = parseParts[0];
                sum[i] = sum[i - 1] + double.Parse(parseParts[1]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Generator_char gen = new Generator_char();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for (int i = 0; i < 1000; i++)
            {
                char ch = gen.Get_symb();
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

            string result_1, result_2;
            result_1 = result_2 = "";
            Generator_text generator = new Generator_text();
            generator.Data_loading("Data_1.txt");
            for (int i = 0; i < 1000; i++)
            {
                result_1 += generator.Get_symb();
            }
            File.WriteAllText("gen_1.txt", result_1, System.Text.Encoding.UTF8);
            generator.Data_loading("Data_2.txt");
            for (int i = 0; i < 1000; i++)
            {
                result_2 += generator.Get_symb();
            }
            File.WriteAllText("gen_2.txt", result_2, System.Text.Encoding.UTF8);
        }
    }
}
