using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace generator
{
   public class CharGenerator
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private string[] bigrams;
        private string[] oneWords;
        private Dictionary<string, int> _oneWords = new Dictionary<string, int>();
        private int _oneWordsSum = 0;
        private string[] twoWords;
        private Dictionary<string, int> _twoWords = new Dictionary<string, int>();
        private int _twoWordsSum = 0;
        private string[] sixWords;
        private Dictionary<string, int> _sixWords = new Dictionary<string, int>();
        private int _sixWordsSum = 0;
        private int[,] massBigrams;
        private int lengths;
        private char[] data;
        private int size;
        private int weightOfBigrams = 0;
        private Random random = new Random();
        public CharGenerator()
        {
            size = syms.Length;
            data = syms.ToCharArray();
        }
        public void OneWordReader()
        {
            oneWords = File.ReadAllLines("Files/1word.txt");

            for (int i = 0; i < oneWords.Length; i++)
            {
                string[] temp = oneWords[i].Split('\t');
                _oneWords.Add(temp[0], Convert.ToInt32(temp[1]));
                _oneWordsSum += Convert.ToInt32(temp[1]);
            }



        }
        public string getStringFromOneWord()
        {
            string str;
            int curSum = 0;
            int choise = random.Next(0, _oneWordsSum);

            foreach (var pair in _oneWords)
            {
                curSum += pair.Value;
                if (curSum > choise)
                {
                    str = pair.Key;
                    return str;
                }
            }
            return "0";
        }
        public string createTextFromOneWord(int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str = String.Concat(str, getStringFromOneWord(), ' ');
            }
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public void sixWordReader()
        {
            sixWords = File.ReadAllLines("Files/6word.txt");

            for (int i = 0; i < sixWords.Length; i++)
            {
                string[] temp = sixWords[i].Split('\t');
                _sixWords.Add(temp[0], Convert.ToInt32(temp[1]));
                _sixWordsSum += Convert.ToInt32(temp[1]);
            }



        }
        public string getStringFromSixWord()
        {
            string str;
            int curSum = 0;
            int choise = random.Next(0, _sixWordsSum);

            foreach (var pair in _sixWords)
            {
                curSum += pair.Value;
                if (curSum > choise)
                {
                    str = pair.Key;
                    return str;
                }
            }
            return "0";
        }
        public string createTextFromSixWord(int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str = String.Concat(str, getStringFromSixWord(), ' ');
            }
            return str;
        }
        public void TwoWordReader()
        {
            twoWords = File.ReadAllLines("Files/2word.txt");
            for (int i = 0; i < twoWords.Length; i++)
            {
                string[] temp = twoWords[i].Split('\t');
                _twoWords.Add(temp[0], Convert.ToInt32(temp[1]));
                _twoWordsSum += Convert.ToInt32(temp[1]);
            }
        }
        public string getStringFromTwoWord()
        {
            string str;
            int curSum = 0;
            int choise = random.Next(0, _twoWordsSum);

            foreach (var pair in _twoWords)
            {
                curSum += pair.Value;
                if (curSum > choise)
                {
                    str = pair.Key;
                    return str;
                }
            }
            return "0";
        }
        public string createTextFromTwoWord(int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str = String.Concat(str, getStringFromTwoWord(), ' ');
            }
            return str;
        }
        public void BigramsReader()
        {
            bigrams = File.ReadAllLines("Files/Bigrams.txt");
            massBigrams = new int[bigrams.Length, bigrams[0].Split('\t').Length];
            for (int i = 0; i < bigrams.Length; i++)
            {
                string[] temp = bigrams[i].Split('\t');
                for (int j = 0; j < temp.Length; j++)
                {
                    massBigrams[i, j] = Convert.ToInt32(temp[j]);
                    weightOfBigrams += Convert.ToInt32(temp[j]);
                }
                lengths = temp.Length;
            }


        }
        public string getStringFromBigram()
        {
            string str;
            int curSum = 0;
            int choise = random.Next(0, weightOfBigrams);

            for (int i = 0; i < lengths; i++)
            {
                for (int j = 0; j < lengths; j++)
                {
                    if (curSum < choise)
                    {
                        curSum += massBigrams[i, j];
                    }
                    else
                    {
                        return str = string.Concat(syms[i], syms[j]);
                    }
                }
            }
            return "0";
        }
        public string createTextFromBigrams(int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str = string.Concat(str, getStringFromBigram());
            }
            return str;
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
            gen.BigramsReader();
            gen.OneWordReader();
            gen.TwoWordReader();
            gen.sixWordReader();

            Console.WriteLine(gen.createTextFromOneWord(100));
            Console.WriteLine();

            Console.WriteLine(gen.createTextFromTwoWord(100));
            Console.WriteLine();
            Console.WriteLine(gen.createTextFromSixWord(100));
            Console.WriteLine();

            Console.WriteLine(gen.createTextFromBigrams(100));


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

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

        }
    }
}
