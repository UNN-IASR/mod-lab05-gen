using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace generator
{
    public class BigramGenerator
    {
        public string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя";
        public int[,] chWeights { get; set; }

        public BigramGenerator(string fileWithBG)
        {
            StreamReader reader = new StreamReader(fileWithBG);
            string str = reader.ReadLine();
            chWeights = new int[syms.Length, syms.Length];
            int i = 0;
            while (str != null)
            {
                string[] buffer = str.Split('\t');

                for (int j = 0; j < buffer.Length; j++)
                {
                    chWeights[i, j] = int.Parse(buffer[j]);
                }
                str = reader.ReadLine();
                i++;
            }
            reader.Close();
        }
        public int getSumOfWeightOfCurrentCh(char ch) {
            int index = syms.IndexOf(ch);
            int sum = 0;
            for (int i = 0; i < syms.Length; i++)
            {
                sum += chWeights[index, i];
            }
            return sum;
        }
        public char getNextCh(char previous)
        {
            int sumOfPrevious = getSumOfWeightOfCurrentCh(previous);
            int indexOfPrevious = syms.IndexOf(previous);
            Random random = new Random();
            int valueOfNext = random.Next(0, sumOfPrevious);
            int sum = 0;
            for (int i = 0; i < syms.Length; i++)
            {
                sum += chWeights[indexOfPrevious, i];
                if (sum >= valueOfNext)
                {
                    return syms[i];
                }
            }
            return '*';
        }
        public string getRecording()
        {
            List<char> futureEntry = new List<char>();
            Random random = new Random();
            char startChar = syms[random.Next(0, syms.Length - 1)];
            futureEntry.Add(startChar);
            while (futureEntry.Count != 1000)
            {
                char nextChar = getNextCh(futureEntry[futureEntry.Count - 1]);
                futureEntry.Add(nextChar);
            }
            return new string(futureEntry.ToArray());
        }
    }
    public class Word
    {
        public string word { get; set; }
        public int weight { get; set; }
        public Word(string[] strAfterSplit)
        {
            this.word = strAfterSplit[0];
            this.weight = int.Parse(strAfterSplit[1]);
        }
    }
    public class WordBigram
    {
        public string firstWord { get; set; }
        public string secondWord { get; set; }
        public int weight { get; set; }
        public WordBigram(string[] strAfterSplit)
        {
            firstWord = strAfterSplit[0];
            secondWord = strAfterSplit[1];
            weight = int.Parse(strAfterSplit[2]);
        }
    }
    public class WordGenerator
    {
        public List<Word> wordsInSample { get; set; }
        public int sumWeightOfWordsInSample { get; set; }
        public WordGenerator(string filename)
        {
            wordsInSample = new List<Word>();
            StreamReader reader = new StreamReader(filename);
            string str = reader.ReadLine();
            while (str != null)
            {
                Word word = new Word(str.Split(' '));
                wordsInSample.Add(word);
                sumWeightOfWordsInSample += word.weight;
                str = reader.ReadLine();
            }
            reader.Close();
        }
        private string getNextWord()
        {
            Random random = new Random();
            int point = random.Next(0, sumWeightOfWordsInSample);
            int currentSum = 0;
            foreach (Word currentWord in wordsInSample)
            {
                currentSum += currentWord.weight;
                if (currentSum >= point)
                {
                    return currentWord.word;
                }
            }
            return null;
        }
        public string getRecording()
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            while (true)
            {
                string nextStr = getNextWord();
                sb.Append(nextStr);
                count++;
                if (count == 1000)
                {
                    return sb.ToString();
                }
                else
                {
                    sb.Append(" ");
                }
            }
        }
    }
    public class WordBigramGenerator
    {
        public List<WordBigram> wordsInSample { get; set; }
        public int sumOfWeightOfWordsInSample { get; set; }
        public WordBigramGenerator(string filename)
        {
            wordsInSample = new List<WordBigram>();
            StreamReader reader = new StreamReader(filename);
            string str = reader.ReadLine();
            while (str != null)
            {
                string[] strAfterSplit = str.Split(' ');
                WordBigram currentWB = new WordBigram(strAfterSplit);
                wordsInSample.Add(currentWB);
                sumOfWeightOfWordsInSample += currentWB.weight;
                str = reader.ReadLine();
            }
            reader.Close();
        }
        public void getWordsWhichStartsWithLastWord(string lastWord, out List<WordBigram> wordsWhichStartsWithLastWord, out int sumOfList)
        {
            sumOfList = 0;
            wordsWhichStartsWithLastWord = new List<WordBigram>();
            foreach (WordBigram wb in wordsInSample)
            {
                if(wb.firstWord == lastWord)
                {
                    wordsWhichStartsWithLastWord.Add(wb);
                    sumOfList += wb.weight;
                }
            }
        }
        public WordBigram getWBByRandom(List<WordBigram> words, int point)
        {
            int currentSum = 0;
            foreach(WordBigram wb in words)
            {
                currentSum += wb.weight;
                if(currentSum >= point)
                {
                    return wb;
                }
            }
            return null;
        }
        private string convertWBListToString(List<String> wb)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < wb.Count - 1; i++)
            {
                sb.Append(wb[i]);
                sb.Append(" ");
            }
            sb.Append(wb[wb.Count - 1]);
            return sb.ToString();
        }
        private string[] getWBWithoutPrevious() 
        {
            string[] result = new string[2];
            Random random = new Random();
            int valueOfRandom = random.Next(0, sumOfWeightOfWordsInSample);
            WordBigram resultOfRandom = getWBByRandom(wordsInSample, valueOfRandom);
            result[0] = resultOfRandom.firstWord;
            result[1] = resultOfRandom.secondWord;
            return result;
        }
        public string getRecording()
        {
            List<string> text = new List<string>();
            text.AddRange(getWBWithoutPrevious());
            while(text.Count != 1000)
            {
                List<WordBigram> wordsStartWithLastWord;
                int sumOfListStartWithLastWord;
                getWordsWhichStartsWithLastWord(text[text.Count - 1], out wordsStartWithLastWord, out sumOfListStartWithLastWord);
                if (wordsStartWithLastWord.Count != 0)
                {
                    Random random = new Random();
                    text.Add(getWBByRandom(wordsStartWithLastWord, random.Next(0, sumOfListStartWithLastWord)).secondWord);
                }
                else
                {
                    text.AddRange(getWBWithoutPrevious());
                }
            }
            return convertWBListToString(text);
        }
    }
    public class Program
    {
        public static void writeToFile(string filename, Object generator)
        {
            string resultOfWork = "";
            switch (generator.GetType().Name)
            {
                case "BigramGenerator":
                    resultOfWork = (generator as BigramGenerator).getRecording();
                    break;
                case "WordGenerator":
                    resultOfWork = (generator as WordGenerator).getRecording();
                    break;
                case "WordBigramGenerator":
                    resultOfWork = (generator as WordBigramGenerator).getRecording();
                    break;
            }
            filename = "../../../../work_results/" + filename;
            File.WriteAllText(filename, resultOfWork);
        }
        static void Main(string[] args)
        {
            BigramGenerator generator = new BigramGenerator("../../../../sources/BG.txt");
            writeToFile("BigramGenerator.txt", generator);

            WordGenerator generator1 = new WordGenerator("../../../../sources/Words.txt");
            writeToFile("WordGenerator.txt", generator1);

            WordBigramGenerator generator2 = new WordBigramGenerator("../../../../sources/WB.txt");
            writeToFile("WordBigramGenerator.txt", generator2);
        }
    }
}

