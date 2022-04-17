using System;
using System.IO;

namespace generator
{
    public class BigrammGenerator
    {
        const string Alphabet = "абвгдежзийклмнопрстуфхцчшщыьэюя";
        private char[] Letters;
        private string PathToTable { get; }

        public BigrammGenerator(string path)
        {
            PathToTable = path;
            Letters = Alphabet.ToCharArray();
        }

        public int[][] PullBigrammFromFile(string path)
        {
            string[] RawBigramm = File.ReadAllLines(path);
            int[][] CookedBigramm = new int[RawBigramm.Length][];
            for (int i = 0; i < CookedBigramm.Length; i++)
            {
                string[] str = RawBigramm[i].Split('\t');
                CookedBigramm[i] = new int[str.Length];
                for (int j = 0; j < str.Length; j++)
                    CookedBigramm[i][j] = Convert.ToInt32(str[j]);
            }
            return CookedBigramm;
        }
        public char GetNextSymbol(char PrevSymbol)
        {
            int[][] Bigramm = PullBigrammFromFile(PathToTable);
            int[] BigrammRow = new int[31];
            int i = Alphabet.IndexOf(PrevSymbol);
            for (int j = 0; j < Bigramm[i].Length; j++)
                BigrammRow[j] = Bigramm[i][j];
            Random rnd = new Random();
            return Alphabet[rnd.Next(0, BigrammRow.Length - 1)];
        }

        public string GenerateText()
        {
            char[] Text = new char[1000];
            Random rnd = new Random();
            char PrevSymbol = Letters[rnd.Next(0, Letters.Length)];
            Text[0] = PrevSymbol;
            for (int i = 1; i < 1000; i++)
            {
                Text[i] = GetNextSymbol(PrevSymbol);
                PrevSymbol = Text[i];
            }
            return new string(Text);
        }
    }

    public class FreqGenerator
    {
        private string PathToTable { get; }

        public FreqGenerator(string path)
        {
            PathToTable = path;
        }

        public (string[], int[]) PullFreqFromFile(string path)
        {
            string[] Words = new string[100];
            string[] RawTable = File.ReadAllLines(path);
            int[] Weights = new int[100];
            for (int i = 0; i < 100; i++)
            {
                Words[i] = RawTable[i].Split(" ")[0];
                Weights[i] = int.Parse(RawTable[i].Split(" ")[1]);
            }
            return (Words, Weights);
        }
        public string GetNextWord(string PrevWord)
        {
            (string[] Words, int[] Weights) = PullFreqFromFile(PathToTable);
            int i = Array.IndexOf(Words, PrevWord);
            Random rnd = new Random();
            int rnd_i = rnd.Next(95, 100);
            if (i <= rnd_i)
                return Words[i];
            return Words[rnd_i];
        }

        public string GenerateText()
        {
            (string[] Words, int[] Weights) = PullFreqFromFile(PathToTable);
            string[] Text = new string[1000];
            string PrevWord = "";
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                PrevWord = Words[rnd.Next(0, Words.Length)];
                Text[i] = GetNextWord(PrevWord);
            }
            return string.Join(' ', Text);
        }
    }

    public class BigrammFreqGenerator
    {
        private string PathToTable { get; }

        public BigrammFreqGenerator(string path)
        {
            PathToTable = path;
        }

        public (string[], int[]) PullBigrammFromFile(string path)
        {
            string[] Words = new string[100];
            string[] RawBigramm = File.ReadAllLines(path);
            int[] Weights = new int[100];
            for (int i = 0; i < 100; i++)
            {
                Words[i] = RawBigramm[i].Split("  ")[0];
                Weights[i] = int.Parse(RawBigramm[i].Split("  ")[1]);
            }
            return (Words, Weights);
        }
        public string GetNextWord(string PrevWord)
        {
            (string[] Words, int[] Weights) = PullBigrammFromFile(PathToTable);
            int i = Array.IndexOf(Words, PrevWord);
            Random rnd = new Random();
            int rnd_i = rnd.Next(95, 100);
            if (i <= rnd_i)
                return Words[i];
            return Words[rnd_i];
        }

        public string GenerateText()
        {
            (string[] Words, int[] Weigths) = PullBigrammFromFile(PathToTable);
            Random rnd = new Random();
            string[] Text = new string[1000];
            string PrevWord = "";
            for (int i = 0; i < 1000; i++)
            {
                PrevWord = Words[rnd.Next(0, Words.Length)];
                Text[i] = GetNextWord(PrevWord);
            }
            return string.Join(' ', Text);
        }
    }

    class Program
    {
        private static void PushTextToFile(string path, string str)
        {
            File.Create(path).Close();
            File.WriteAllText(path, str);
        }

        static void Main(string[] args)
        {
            BigrammGenerator bg = new BigrammGenerator("../../../../Tables/SymbolsBigramm.txt");
            PushTextToFile("../../../../Results/result1.txt", bg.GenerateText());

            FreqGenerator fg = new FreqGenerator("../../../../Tables/FreqGramm.txt");
            PushTextToFile("../../../../Results/result2.txt", fg.GenerateText());

            BigrammFreqGenerator bfg = new BigrammFreqGenerator("../../../../Tables/BiFreqGramm.txt");
            PushTextToFile("../../../../Results/result3.txt", bfg.GenerateText());
        }
    }
}