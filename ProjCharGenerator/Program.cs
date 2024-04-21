using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

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
    public class BigramGenerator
    {
        public string[] words;
        public int[] weights;
        public int total;
        private Random random = new Random();
        public BigramGenerator(string inputFile)
        {
            string[] lines = File.ReadAllLines(inputFile);
            words = new string[lines.Length];
            weights = new int[lines.Length];
            for (var i = 0; i < words.Length; i++)
            {
                var fff = lines[i].Split('\t');
                words[i] = fff[0];
                int weight = Convert.ToInt32(fff[1]);
                total += weight;
                weights[i] = total;
            }
        }
        virtual public string Result()
        {
            string result = "";
            while(result.Length < 1000)
            {
                string word = GenerateWord();
                result += word;
            }
            return result;
        }
        public string GenerateWord()
        {
            int rand = random.Next(0, total);
            for (int i = 0; i < words.Length; i++)
            {
                if (rand < weights[i]) return words[i];
            }
            return "";
        }
    }
    public class WordsGenerator : BigramGenerator
    {
        public WordsGenerator(string inputFile): base(inputFile) { }
        public override string Result()
        {
            string result = "";
            while (result.Length < 1000)
            {
                string word = GenerateWord();
                result += word;
                result += " ";
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            string result = "";
            for (int i = 0; i < 1000; i++)
            {
                result += gen.getSym();
            }
            File.WriteAllText("../../../../gen.txt", result);
            
            BigramGenerator gen1 = new BigramGenerator("../../../../bigrams.txt");
            File.WriteAllText("../../../../gen-1.txt", gen1.Result());

            WordsGenerator gen2 = new WordsGenerator("../../../../words.txt");
            File.WriteAllText("../../../../gen-2.txt", gen2.Result());
        }
    }
}

