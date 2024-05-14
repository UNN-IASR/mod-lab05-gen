using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

    public class Generator_BIgramm
    {
        private string alphabet = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] characters;
        private int sequenceLength;
        private Random generator = new Random();
        private int[,] boundaries;
        private int[,] probabilities;

        public Generator_BIgramm()
        {
            sequenceLength = alphabet.Length;
            characters = alphabet.ToCharArray();
            boundaries = new int[sequenceLength, sequenceLength];
            probabilities = new int[sequenceLength, sequenceLength];

            string fileContent = File.ReadAllText(@"BI.txt");
            string[] lines = fileContent.Split('\n');
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] parts = line.Split(' ');
                    int weight = int.Parse(parts[2]);
                    probabilities[alphabet.IndexOf(parts[1][0]), alphabet.IndexOf(parts[1][1])] = weight;
                }
            }

            int totalWeight = 0;
            for (int i = 0; i < sequenceLength; i++)
            {
                for (int j = 0; j < sequenceLength; j++)
                {
                    totalWeight += probabilities[i, j];
                    boundaries[i, j] = totalWeight;
                }
            }
        }

        public char GetSymbol(char input)
        {
            int index = 0;
            if (alphabet.Contains(input))
            {
                int lowerBound;
                if (input != alphabet[0])
                {
                    lowerBound = boundaries[alphabet.IndexOf(input) - 1, sequenceLength - 1];
                }
                else
                {
                    lowerBound = 0;
                }
                int upperBound = boundaries[alphabet.IndexOf(input), sequenceLength - 1];
                int randomIndex = generator.Next(lowerBound, upperBound + 1);

                for (int i = 0; i < sequenceLength; i++)
                {
                    for (int j = 0; j < sequenceLength; j++)
                    {
                        if (randomIndex <= boundaries[i, j])
                        {
                            return characters[j];
                        }
                    }
                }
            }
            else
            {
                return characters[generator.Next(0, sequenceLength)];
            }

            return characters[index];
        }
    }

    public class Generator_Words_Text
    {
        private const int maxWordsCount = 100;
        private string alphabet = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private int sequenceLength;
        private Random generator = new Random();
        public string[] wordList;
        public int[] wordFrequencies;
        public int[] upperBounds;
        public int totalSum = 0;

        public Generator_Words_Text()
        {
            sequenceLength = alphabet.Length;
            upperBounds = new int[maxWordsCount];
            wordList = new string[maxWordsCount];
            wordFrequencies = new int[maxWordsCount];

            string freqWordsPath = @"frequency_properties_of_words.txt";
            using (StreamReader streamReader = new StreamReader(freqWordsPath))
            {
                string? line = streamReader.ReadLine();
                int currentIndex = 0;
                while (line != null)
                {
                    string[] splitLine = line.Split('\t');
                    wordList[currentIndex] = splitLine[1];
                    wordFrequencies[currentIndex] = int.Parse(splitLine[3]);
                    currentIndex++;
                    line = streamReader.ReadLine();
                }
            }
        }

        public void CalculateAndMinimizeSum()
        {
            int minValue = wordFrequencies[maxWordsCount - 1];
            for (int i = 0; i < maxWordsCount; i++)
            {
                wordFrequencies[i] -= minValue;
            }
            upperBounds[0] = wordFrequencies[0];
            for (int i = 1; i < maxWordsCount; i++)
            {
                upperBounds[i] = upperBounds[i - 1] + wordFrequencies[i];
            }
            totalSum = upperBounds[maxWordsCount - 1];
        }

        public string GetRandomWord()
        {
            int randomIndex = generator.Next(0, totalSum);
            int index = 0;
            for (; index < sequenceLength; index++)
            {
                if (randomIndex < upperBounds[index])
                {
                    break;
                }
            }
            return wordList[index];
        }
    }

    class Program
    {
        static void funtion_for_gen_0_txt()
        {
            //Записываем путь файла gen-0.txt для удобства работы с ним
            //C:\Users\wizze\source\repos\ProjCharGenerator
            string File_Name = @"C:\Users\wizze\source\repos\ProjCharGenerator\gen-0.txt";
            //Записываем всё в файл gen-0.txt в результате работы CharGenerator
            CharGenerator gen = new CharGenerator();
            using (StreamWriter Stream_Writer = new StreamWriter(File_Name))
            {
                SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
                for (int i = 0; i < 1000; i++)
                {
                    char ch = gen.getSym();
                    if (stat.ContainsKey(ch))
                    {
                        stat[ch]++;
                    }
                    else
                    {
                        stat.Add(ch, 1);
                    }
                    Stream_Writer.Write(ch);
                }
                Stream_Writer.WriteLine();
                foreach (KeyValuePair<char, int> entry in stat)
                {
                    Stream_Writer.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
                }
            }
        }

        static void funtion_for_gen_1_txt()
        {
            //Записываем путь файла gen-0.txt для удобства работы с ним
            string File_Name = @"C:\Users\wizze\source\repos\ProjCharGenerator\gen-1.txt";
            //Записываем всё в файл gen-0.txt в результате работы CharGenerator
            Generator_BIgramm gen1 = new Generator_BIgramm();
            //Первое вхождение для того чтобы оно работало 
            char letter = 'а';
            using (StreamWriter Stream_Writer = new StreamWriter(File_Name))
            {
                SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
                for (int i = 0; i < 1000; i++)
                {
                    char ch = gen1.GetSymbol(letter);
                    if (stat.ContainsKey(ch))
                    {
                        stat[ch]++;
                    }
                    else
                    {
                        stat.Add(ch, 1);
                    }
                    letter = ch;
                    Stream_Writer.Write(ch);
                }
                Stream_Writer.WriteLine();
                foreach (KeyValuePair<char, int> entry in stat)
                {
                    Stream_Writer.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
                }
            }
        }

        static void funtion_for_gen_2_txt()
        {
            //Записываем путь файла gen-0.txt для удобства работы с ним
            string File_Name = @"C:\Users\wizze\source\repos\ProjCharGenerator\gen-2.txt";
            //Записываем всё в файл gen-0.txt в результате работы CharGenerator
            Generator_Words_Text gen2 = new Generator_Words_Text();
            gen2.CalculateAndMinimizeSum();
            using (StreamWriter Stream_Writer = new StreamWriter(File_Name))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string ch = String.Concat(gen2.GetRandomWord(), " ");
                    Stream_Writer.Write(ch);
                }
            }
        }

        static void Main(string[] args)
        {
            funtion_for_gen_0_txt();

            funtion_for_gen_1_txt();

            funtion_for_gen_2_txt();
        }
    }

}
