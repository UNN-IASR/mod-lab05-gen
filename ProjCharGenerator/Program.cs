using System;
using System.Collections.Generic;
using System.IO;

namespace generator {
    class CharGenerator {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator() {
            size = syms.Length;
            data = syms.ToCharArray();
        }
        public char getSym() {
            return data[random.Next(0, size)];
        }
    }
    class Bigram
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private Random rand = new Random();
        private int[,] np;
        private int sum = 0;

        public Bigram(int[,] prob) {
            size = syms.Length;
            data = syms.ToCharArray();
            if (size != prob.GetLength(0) || size != prob.GetLength(1)) {
                Console.WriteLine("Error!");
                Environment.Exit(1);
            }
            for (int i = 0; i < prob.GetLength(0); i++)
                for (int j = 0; j < prob.GetLength(1); j++)
                    sum += prob[i, j];
            np = new int[size, size];
            int s2 = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++) {
                    s2 += prob[i, j];
                    np[i, j] = s2;
                }
        }
        public string getSym() {
            int m = rand.Next(0, sum);
            int i, j = 0;

            for (i = 0; i < size; i++) {
                for (j = 0; j < size; j++) {
                    if (m < np[i, j])
                        return data[i].ToString() + data[j].ToString();
                }
            }

            return data[i].ToString() + data[j].ToString();
        }
        public string getOutput(int steps) {
            string output = "";
            for (int i = 0; i < steps; i++) {
                output += getSym();
                if (i != steps - 1)
                    output += ' ';
            }

            return output;
        }
    }
    class WordFrequency {
        private string[] data;
        private int size;
        private Random rand = new Random();
        private int[] np;
        private int sum = 0;

        public WordFrequency(string[] words) {
            data = words;
            size = words.Length;
            np = new int[size];
            for (int i = 0; i < size; i++) {
                sum += i;
                np[i] = sum;
            }
        }
        public string getWord() {
            int m = rand.Next(0, sum);
            int j;

            for (j = 0; j < size; j++) {
                if (m < np[j])
                    break;
            }
            return data[j];
        }
        public string getOutput(int steps) {
            string output = "";
            for (int i = 0; i < steps; i++) {
                output += getWord();
                if (i != steps - 1)
                    output += ' ';
            }

            return output;
        }
    }
    class FrequencyOfTwoWords {
        private string[] data;
        private int size;
        private Random rand = new Random();
        private int[] np;
        private int sum = 0;

        public FrequencyOfTwoWords(string[] words) {
            data = words;
            size = words.Length;
            np = new int[size];
            for (int i = 0; i < size; i++) {
                sum += i;
                np[i] = sum;
            }
        }
        public string getWords() {
            int m = rand.Next(0, sum);
            int j;

            for (j = 0; j < size; j++) {
                if (m < np[j])
                    break;
            }
            return data[j];
        }
        public string getOutput(int steps) {
            string output = "";
            for (int i = 0; i < steps; i++) {
                output += getWords();
                if (i != steps - 1)
                    output += ' ';
            }

            return output;
        }
    }
    class Program {
        static void Main(string[] args) {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for (int i = 0; i < 1000; i++) {
                char ch = gen.getSym();
                if (stat.ContainsKey(ch))
                    stat[ch]++;
                else
                    stat.Add(ch, 1); Console.Write(ch);
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat) {
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
            }

            if (!File.Exists("Probability.txt") || !File.Exists("Words.txt") || !File.Exists("TwoWords.txt")) {
                Console.WriteLine("Error!");
                Environment.Exit(2);
            }
            string[] prop_temp = File.ReadAllLines("Probability.txt");
            int[,] probability = new int[prop_temp.Length, prop_temp[0].Split(' ').Length];
            for (int i = 0; i < prop_temp.Length; i++) {
                string[] temp = prop_temp[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    probability[i, j] = Convert.ToInt32(temp[j]);
            }

            string[] words = File.ReadAllLines("Words.txt");
            string[] twowords = File.ReadAllLines("TwoWords.txt");

            Bigram bigram = new Bigram(probability);
            string output1 = bigram.getOutput(1000);
            WordFrequency wordFrequency = new WordFrequency(words);
            string output2 = wordFrequency.getOutput(1000);
            FrequencyOfTwoWords frequencyOfTwoWords = new FrequencyOfTwoWords(twowords);
            string output3 = frequencyOfTwoWords.getOutput(1000);

            File.WriteAllText("bigram.txt", output1);
            File.WriteAllText("wordFrequency.txt", output2);
            File.WriteAllText("frequencyOfTwoWords.txt", output3);
        }
    }
}

