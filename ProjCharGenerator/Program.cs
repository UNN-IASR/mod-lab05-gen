using System;
using System.Collections.Generic;
using System.IO;
namespace laba5
{
    public class CreatingText
    {
        public int sum;
        public List<int> Power;
        public List<string> words;
        
        public CreatingText(string file)
        {
            this.Power = new();
            string[] linesStr = File.ReadAllLines(file);
            this.words = new();
            sum = 0;
            for (int i = 0; i < linesStr.Length; i++)
            {
                string[] split = linesStr[i].Split(' ');
                if(int.TryParse(split[1],out int result))
                {
                    sum += result;
                }
                Power.Add(sum);
                words.Add(split[0]);
            }
            int h = 0;
        }
        public string GenerationText()
        {   
            Random Rnd = new();
            int rand = Rnd.Next(0, sum);
            for (int i = 0; i < words.Count; i++)
            {
                if(sum>0)
                {
                    if (rand < Power[i])
                    {
                        return words[i];
                    }
                    else
                    {
                        //Console.WriteLine(rand);
                    }
                }
                
            }
            return null;
        }
    }
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
            CreatingText generator = new CreatingText("Probability.txt");//
            string result_bigram = "";
            string result_words = "";
            for (int i = 0; i < 1000; i++)//1000
            {
                result_bigram += generator.GenerationText();
            }
            File.WriteAllText("1Text.txt", result_bigram);
            CreatingText generator1 = new CreatingText("ProbabilityWorld.txt");
            for (int i = 0; i < 1000; i++)
            {
                result_words += generator1.GenerationText();
                result_words += " ";
            }
            File.WriteAllText("2Text.txt", result_words);
        }
    }
}
