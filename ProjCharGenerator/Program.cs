using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace generator
{
    public abstract class Generator
    {
        protected Dictionary<string, long> bigramsInfo;
        protected long weightsSum;

        public Generator(string dataPath)
        {
            bigramsInfo = new Dictionary<string, long>();
            weightsSum = 0;

            GetInfo(dataPath);
        }

        private void GetInfo(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var splitted = line
                    .Split('\t')
                    .Where(s => s.Length > 0)
                    .ToArray();
                weightsSum += long.Parse(splitted[1]);
                bigramsInfo[splitted[0]] = weightsSum;
            }
        }

        public string StartGenerator(int count)
        {
            Random random = new Random();
            var res_gen = new List<string>();
            long number;

            for (int i = 0; i < count; i++)
            {
                number = random.NextInt64(weightsSum);
                foreach (var item in bigramsInfo)
                {
                    if (number < item.Value)
                    {
                        res_gen.Add(item.Key);
                        break;
                    }
                }
            }

            string result = outputResult(res_gen);
            return result;
        }

        protected abstract string outputResult(List<string> res);
    }

    public class BigramsGenerator : Generator
    {
        private const string nameFile = "bigrams.txt";

        public BigramsGenerator(string dataPath = nameFile) : base(dataPath) { }

        protected override string outputResult(List<string> res)
        {
            return String.Concat(res);
        }
    }

    public class WordsGenerator : Generator
    {
        private const string nameFile = "words.txt";

        public WordsGenerator(string dataPath = nameFile) : base(dataPath) { }

        protected override string outputResult(List<string> res)
        {
            return String.Join(' ', res);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bigramsGen = new BigramsGenerator();
            var res = bigramsGen.StartGenerator(1000);

            //Console.WriteLine(res);

            using (var fileBigrams = new StreamWriter("gen-1.txt", false, System.Text.Encoding.UTF8))
            {
                fileBigrams.Write(res);
            }

            var wordsGen = new WordsGenerator();
            res = wordsGen.StartGenerator(1000);

            //Console.WriteLine(res);

            using (var fileWords = new StreamWriter("gen-2.txt", false, System.Text.Encoding.UTF8))
            {
                fileWords.Write(res);
            }
        }
    }
}