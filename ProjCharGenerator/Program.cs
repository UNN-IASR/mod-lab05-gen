using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace generator
{
    public class FirstGenerator
    {
        Dictionary<char, SortedList<int, char>> map;
        string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        public FirstGenerator(string fileName) 
        {
            string[] text = File.ReadAllLines(fileName);
            map = new();
            foreach (string line in text) 
            {
                string[] s = line.Split();
                char first_letter = s[1][0];
                char second_letter = s[1][1];
                if (!map.ContainsKey(first_letter)) map.Add(first_letter, new SortedList<int, char>());
                map[first_letter].Add(int.Parse(s[3]), second_letter);
            }
        }
        public string generateString(int length)
        {
            string output = "";
            Random rnd = new Random();
            char previous = 'а';
            for (int i = 0; i < length; i++)
            {
                if (previous == ' ' || !map.ContainsKey(previous))
                {
                    char c = syms[rnd.Next(33)];
                    output = String.Concat(output, c.ToString());
                    previous = c;
                    continue;
                }
                if (rnd.Next(7) == 0 && i != 0)
                {
                    output = String.Concat(output, " ");
                    previous = ' ';
                    continue;
                }
                bool found = false;
                for (int index = 0; index < map[previous].Count; index++)
                {
                    if (rnd.Next(100) < 30)
                    {
                        output = String.Concat(output, map[previous].Values[index].ToString());
                        found = true;
                        previous = map[previous].Values[index];
                        break;
                    }
                }
                if (!found)
                {
                    char c = syms[rnd.Next(33)];
                    output = String.Concat(output, c.ToString());
                    previous = c;
                }
            }
            return output;
        }
    }
    public class SecondGenerator
    {
        struct Data
        {
            public float frequency;
            public string word;
        }
        List<Data> data = new List<Data>();
        float sum;
        public SecondGenerator(string fileName)
        {
            string[] text = File.ReadAllLines(fileName);
            data = new();
            for (int i = 0; i < text.Length; i++)
            {

                string[] s = text[i].Split();
                Data d;
                d.word = s[1];
                float freq = (float)double.Parse(s[3]);
                d.frequency = freq;
                sum += freq;
                data.Add(d);
            }
        }
        public string generateString(int length)
        {
            string output = String.Empty;
            Random rnd = new Random();
            while (output.Length < length)
            {
                bool found = false;
                float current = (float)rnd.NextDouble() * sum;
                for (int i = 0; i < data.Count; i++)
                {
                    current -= data[i].frequency;
                    if (current <= 0)
                    {
                        output += data[i].word + " ";
                        found = true;
                        break;
                    }
                }
                if (!found) throw new Exception("incorrect rnd processing");
            }
            return output;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            {
                FirstGenerator gen = new("../../../freq2.txt");
                string str = gen.generateString(1500);
                byte[] info = new UTF8Encoding(true).GetBytes(str);
                FileStream stream = File.Create("gen-1.txt");
                if (!stream.CanWrite) throw new Exception("cannot write");
                stream.Write(info);
                stream.Close();
            }
            {
                SecondGenerator gen = new("../../../freqwords.txt");
                string str = gen.generateString(1500);
                byte[] info = new UTF8Encoding(true).GetBytes(str);
                FileStream stream = File.Create("gen-2.txt");
                if (!stream.CanWrite) throw new Exception("cannot write");
                stream.Write(info);
                stream.Close();
            }
        }
    }
}

