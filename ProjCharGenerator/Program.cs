using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Generator
{
    class TextGenerator
    {
        private readonly string symbols = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private readonly char[] data;
        private readonly Random random = new Random();

        public TextGenerator()
        {
            data = symbols.ToCharArray();
        }

        public char GetSymbol()
        {
            return data[random.Next(0, data.Length)];
        }
    }

    public abstract class BaseGenerator
    {
        protected readonly Dictionary<string, long> weightsInfo;
        protected long weightsSum;
        private readonly Random random;

        protected BaseGenerator(string dataPath, Random random = null)
        {
            this.random = random ?? new Random();
            weightsInfo = new Dictionary<string, long>();
            weightsSum = 0;
            LoadWeightsInfo(dataPath);
        }

        public string Generate(int count)
        {
            if (count < 0)
                throw new ArgumentException($"Count must be positive, but was {count}", nameof(count));

            var sequence = Enumerable.Range(0, count).Select(_ => GetSymbol());
            return ConstructResultString(sequence);
        }

        protected abstract string ConstructResultString(IEnumerable<string> parts);

        protected string GetSymbol()
        {
            long selectedWeight = random.Next((int)weightsSum);
            return weightsInfo.FirstOrDefault(kv => selectedWeight < kv.Value).Key ?? "";
        }

        private void LoadWeightsInfo(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var splitted = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                if (splitted.Length < 2)
                    continue;

                string symbol = splitted[0];
                long weight = long.Parse(splitted[1]);
                weightsSum += weight;
                weightsInfo[symbol] = weightsSum;
            }
        }
    }

    public class BetterWordsGenerator : BaseGenerator
    {
        private const string DefaultDataPath = "bigrams.txt";

        public BetterWordsGenerator(string dataPath = DefaultDataPath, Random random = null) : base(dataPath, random) { }

        protected override string ConstructResultString(IEnumerable<string> parts)
        {
            return string.Concat(parts);
        }
    }

    public class WordsGenerator : BaseGenerator
    {
        private const string DefaultDataPath = "dictionary.txt";

        public WordsGenerator(string dataPath = DefaultDataPath, Random random = null) : base(dataPath, random) { }

        protected override string ConstructResultString(IEnumerable<string> parts)
        {
            return string.Join(' ', parts);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenerateAndSave(new BetterWordsGenerator(), "gen-1.txt");
            GenerateAndSave(new WordsGenerator(), "gen-2.txt");
        }

        static void GenerateAndSave(BaseGenerator generator, string fileName)
        {
            var generated = generator.Generate(1000);
            File.WriteAllText(fileName, generated);
        }
    }
}
