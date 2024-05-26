using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    class BigramGenerator
    {
        private Dictionary<char, List<(char, int)>> bigrams = new Dictionary<char, List<(char, int)>>();
        private Random random = new Random();

        public BigramGenerator(string filePath)
        {
            LoadBigrams(filePath);
        }

        private void LoadBigrams(string filePath)
        {
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                {
                    char firstChar = parts[0][0];
                    char secondChar = parts[0][1];
                    int frequency = int.Parse(parts[1]);

                    if (!bigrams.ContainsKey(firstChar))
                    {
                        bigrams[firstChar] = new List<(char, int)>();
                    }
                    bigrams[firstChar].Add((secondChar, frequency));
                }
            }
        }

        public string GenerateText(int length)
        {
            if (bigrams.Count == 0) return string.Empty;

            char currentChar = bigrams.Keys.ElementAt(random.Next(bigrams.Count));
            var outputText = new List<char> { currentChar };

            for (int i = 1; i < length; i++)
            {
                if (bigrams.ContainsKey(currentChar))
                {
                    var possibleNextChars = bigrams[currentChar];
                    char nextChar = GetWeightedRandomChar(possibleNextChars);
                    outputText.Add(nextChar);
                    currentChar = nextChar;
                }
                else
                {
                    break;
                }
            }

            return new string(outputText.ToArray());
        }

        private char GetWeightedRandomChar(List<(char, int)> charWeights)
        {
            int totalWeight = charWeights.Sum(cw => cw.Item2);
            int randomWeight = random.Next(totalWeight);
            int currentWeight = 0;

            foreach (var (ch, weight) in charWeights)
            {
                currentWeight += weight;
                if (randomWeight < currentWeight)
                {
                    return ch;
                }
            }

            return charWeights.Last().Item1; // Резервный вариант в случае ошибки округления
        }
    }
    class WordFrequencyGenerator
    {
        private Dictionary<string, double> wordFrequencies = new Dictionary<string, double>();
        private Random random = new Random();

        public WordFrequencyGenerator(string filePath)
        {
            LoadWordFrequencies(filePath);
        }

        private void LoadWordFrequencies(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1); // Заголовки пропускаем
            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                var parts = line.Split(';');
                //Console.WriteLine(parts.Length);
                if (parts.Length == 4)
                {
                    string word = parts[1];
                    double frequency = double.Parse(parts[2]);
                    wordFrequencies[word] = frequency;
                }
            }
        }

        public string GenerateText(int length)
        {
            if (wordFrequencies.Count == 0) return string.Empty;

            var words = wordFrequencies.Keys.ToList();
            var outputText = new List<string>();

            for (int i = 0; i < length; i++)
            {
                string nextWord = GetWeightedRandomWord(words);
                outputText.Add(nextWord);
            }
            //Console.WriteLine(outputText.ToString());

            return string.Join(" ", outputText);
        }

        private string GetWeightedRandomWord(List<string> words)
        {
            double totalWeight = wordFrequencies.Sum(wf => wf.Value);
            double randomWeight = random.Next(Convert.ToInt32(totalWeight));
            double currentWeight = 0;

            foreach (var word in words)
            {
                currentWeight += wordFrequencies[word];
                if (randomWeight < currentWeight)
                {
                    return word;
                }
            }

            return words.Last(); // Резервный вариант для ошибок округления
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
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
            */
            BigramGenerator bigramGenerator = new BigramGenerator("./bigrams.csv");
            //Console.WriteLine(bigramGenerator.bigrams.Values.ToString());
            string generatedText = bigramGenerator.GenerateText(1000);

            File.WriteAllText("generated_bigram_text.txt", generatedText);
            Console.WriteLine("Текст сгенерирован с помощью биграм и сохранен в generated_bigram_text.txt");

            // Генерация текста на основе частотных свойств слов
            WordFrequencyGenerator wordFrequencyGenerator = new WordFrequencyGenerator("./ruscorpora_content.csv");
            string wordFrequencyText = wordFrequencyGenerator.GenerateText(1000);
            File.WriteAllText("generated_word_frequency_text.txt", wordFrequencyText);
            Console.WriteLine("Текст сгенерирован с помощью частотности слов и сохранен в generated_word_frequency_text.txt");

        }
    }
}

