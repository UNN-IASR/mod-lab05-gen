using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace generator
{
    public class Balaboba
    {
        public string[] pairLetters { get; private set; }
        public int size { get; private set; }
        private Random random = new Random();
        public int[] weights { get; private set; }

        public int[] upperBoundsNumbers { get; private set; }
        public int sum { get; private set; }

        public Balaboba(string[] _pairLetters, int[] _weights)
        {
            pairLetters = _pairLetters;
            weights = _weights;
            sum = 0;
            size = pairLetters.Length;
            if (size != weights.Length)
            {
                Console.WriteLine("Error!");
                Environment.Exit(1);
            }

            for (int i = 0; i < size; i++)
                sum += weights[i];

            upperBoundsNumbers = new int[size];

            int s2 = 0;
            for (int i = 0; i < size; i++)
            {
                s2 += weights[i];
                upperBoundsNumbers[i] = s2;
            }
        }
        public string getPair()
        {
            int m = random.Next(0, sum);
            int j;

            for (j = 0; j < size; j++)
            {
                if (m < upperBoundsNumbers[j])
                    break;
            }
            return pairLetters[j];
        }
    }

    public class Balaboba2_0
    {
        public string[] words { get; private set; }
        public  int size { get; private set; }
        private Random random = new Random();
        public double[] weights { get; private set; }

        public double[] upperBoundsNumbers { get; private set; }
        public double sum { get; private set; }

        public Balaboba2_0(string[] _words, double[] _weights)
        {
            words = _words;
            weights = _weights;
            sum = 0;
            size = words.Length;
            if (size != weights.Length)
            {
                Console.WriteLine("Error!");
                Environment.Exit(1);
            }

            for (int i = 0; i < size; i++)
                sum += weights[i];

            upperBoundsNumbers = new double[size];

            double s2 = 0;
            for (int i = 0; i < size; i++)
            {
                s2 += weights[i];
                upperBoundsNumbers[i] = s2;
            }
        }
        public string getWord()
        {
            int m = random.Next(0, (int)sum);
            int j;

            for (j = 0; j < size; j++)
            {
                if (m < upperBoundsNumbers[j])
                    break;
            }
            return words[j];
        }
    }

    public class FileHandler
    {
        public static void SaveInFile(string filepath, string text)
        {

            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.Write(text);
            }
            
        }

        public static void DeleteIfExists(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        public static void BalabobaFromFile(string filepath, out Balaboba balaboba)
        {
            List<string> pairLetters = new List<string>();
            List<int> weights = new List<int>();
            using (TextFieldParser parser = new TextFieldParser(filepath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    pairLetters.Add(fields[0]);
                    weights.Add(int.Parse(fields[1]));
                }
            }
            balaboba = new Balaboba(pairLetters.ToArray(), weights.ToArray());
        }

        public static void Balaboba2_0FromFile(string filepath, out Balaboba2_0 balaboba2_0)
        {
            List<string> words = new List<string>();
            List<double> weights = new List<double>();
            using (TextFieldParser parser = new TextFieldParser(filepath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    words.Add(fields[0]);
                    weights.Add(double.Parse(fields[1], CultureInfo.InvariantCulture));
                }
            }
            balaboba2_0 = new Balaboba2_0(words.ToArray(), weights.ToArray());
        }
    }

    class Program
    {
        static string filepath1 = "..\\..\\..\\..\\gen-1.txt";
        static string filepath2 = "..\\..\\..\\..\\gen-2.txt";
        static string fileBigrams = "bigrams.csv";
        static string fileWords = "frequency_words.csv";
        static Balaboba balaboba;
        static Balaboba2_0 balaboba2_0;
 
        static void Main(string[] args)
        {
            FileHandler.DeleteIfExists(filepath1);
            FileHandler.BalabobaFromFile(fileBigrams, out balaboba);
            FileHandler.DeleteIfExists(filepath2);
            FileHandler.Balaboba2_0FromFile(fileWords, out balaboba2_0);
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            for (int i = 0; i < 20000; i++)
            {
                string pair = balaboba.getPair();
                if (stat.ContainsKey(pair))
                    stat[pair]++;
                else
                    stat.Add(pair, 1);

                Console.Write(pair);
                FileHandler.SaveInFile(filepath1, pair);
            }
            Console.Write('\n');
            foreach (KeyValuePair<string, int> entry in stat)
            {
                Console.WriteLine("{0} - {1:0.000}", entry.Key, entry.Value / 20000.0 * 10000);
            }

            Console.WriteLine();
            Console.WriteLine();

            stat = new SortedDictionary<string, int>();
            for (int i = 0; i < 10000; i++)
            {
                string word = balaboba2_0.getWord();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1);

                Console.Write(word + " ");
                FileHandler.SaveInFile(filepath2, word);
            }
            Console.Write('\n');
            foreach (KeyValuePair<string, int> entry in stat)
            {
                Console.WriteLine("{0} - {1:0.000}", entry.Key, entry.Value / 10000.0 * 10000);
            }
        }
    }
}
