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

    public abstract class BaseGenerator
    { 
        
        protected Dictionary<string, long> weightsInfo;
        protected long weightsSum;

        private Random random = Random.Shared;

        public BaseGenerator(string dataPath, Random random = null)
        {
            weightsInfo = new Dictionary<string, long>();
            weightsSum = 0;

            if(random is not null)
            {
                this.random = random;
            }    

            GetInfo(dataPath);
        }

        public string Generate(int count)
        {
            if(count < 0)
            {
                var ex = new ArgumentException($"Count must be positive, but was {count}");
                ex.Data.Add("Count", count);
                throw ex;
            }

            var sequence = GetSymbols(count);
            string result = ConstructResultString(sequence);

            return result;
        }

        protected abstract string ConstructResultString(IEnumerable<string> parts);

        protected IEnumerable<string> GetSymbols(int count)
        {
            var result = new List<string>();
            for(int i = 0; i < count; i++)
            {
                result.Add(GetSymbol());
            }

            return result;
        }
        
        protected string GetSymbol()
        {
            long el = random.NextInt64(weightsSum);
            foreach (var bi in weightsInfo)
            {
                if (el < bi.Value)
                {
                    return bi.Key;
                }
            }

            return "";
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
                weightsInfo[splitted[0]] = weightsSum;
            }
        }
    }

    public class BetterCharGenerator : BaseGenerator
    {
        private const string info = "bigrams.txt";

        public BetterCharGenerator(string dataPath = info, Random random = null) : base(dataPath,random)
        {
        }

        protected override string ConstructResultString(IEnumerable<string> parts)
        {
            return String.Concat(parts);
        }
    }

    public class WordsGenerator : BaseGenerator
    {
        private const string info = "wordsInfo.txt";

        public WordsGenerator(string dataPath = info, Random random = null) : base(dataPath, random) 
        {
        }

        protected override string ConstructResultString(IEnumerable<string> parts)
        {
            return String.Join(' ', parts);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //CharGenerator gen = new CharGenerator();
            //SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            //for(int i = 0; i < 1000; i++) 
            //{
            //   char ch = gen.getSym(); 
            //   if (stat.ContainsKey(ch))
            //      stat[ch]++;
            //   else
            //      stat.Add(ch, 1); Console.Write(ch);
            //}
            //Console.Write('\n');
            //foreach (KeyValuePair<char, int> entry in stat) 
            //{
            //     Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            //}

            var generator = new BetterCharGenerator();
            var generatedString = generator.Generate(1000);
            using (var fs = new StreamWriter("gen-1.txt", false, System.Text.Encoding.UTF8))
            {
                fs.Write(generatedString);
            }

            var wordGenerator = new WordsGenerator();
            var generated = wordGenerator.Generate(1000);
            using (var fs = new StreamWriter("gen-2.txt", false, System.Text.Encoding.UTF8))
            {
                fs.Write(generated);
            }
        }
    }
}

