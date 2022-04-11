using System;
using System.Collections.Generic;
using System.IO;


namespace generator
{
    // Разработать генератор текста на основе пар букв (биграмм). Используются вероятностные свойства сочетаний пар символов
    public class BigrammGenerator
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя"; 
        private char[] data;
        string inputfile;
        string outputfile;

        public BigrammGenerator(string file1, string file2)
        {
            inputfile = file1;
            outputfile = file2;
        }

        public int[][] GetBG()
        {
            string[] s = File.ReadAllLines(inputfile);
            int[][] array = new int[s.Length][];
            for (int i = 0; i < array.Length; i++)
            {       
                string[] str = s[i].Split('\t');
                array[i] = new int[str.Length];
                for (int j = 0; j < str.Length; j++ )
                {
                    array[i][j] = int.Parse(str[j]);
                }
            }
            return array;
        }

        public char GetSym(char ch) 
        {
            int index = syms.IndexOf(ch);
            int[][] chars = GetBG();
            Random random = new Random();
            int[] data = new int[31];
            for (int j = 0; j < chars[index].Length; j++)
            {
                data[j] = chars[index][j];
            }
            int value_index = random.Next(0, data.Length-1);
            return syms[random.Next(0, data.Length-1)];
        }

        public string GetCharsUsingBG()
        {
            Random random = new Random();
            char[] symbols = new char[1000];
            data = syms.ToCharArray();
            char symbol = data[random.Next(0, data.Length)];
            symbols[0] = symbol;
            for (int i = 1; i < 1000; i++)
            {
                symbols[i] = GetSym(symbol);
                symbol = symbols[i];
            }
            string str = new string(symbols);
            File.Create(outputfile).Close();
            File.WriteAllText(outputfile, str);
            return str;
        }
    }

    // Разработать генератор текста на основе частотных свойств слов
    public class FreqGenerator
    {
        string inputfile;
        string outputfile;

        public FreqGenerator(string file1, string file2)
        {
            inputfile = file1;
            outputfile = file2;
        }

        public (string[], int[]) GetFG()
        {
            string[] words = new string[100];
            string[] s = File.ReadAllLines(inputfile);
            int[] values = new int[100];
            for (int i = 0; i < 100; i++)
            { 
                words[i] = s[i].Split(" ")[0];
                values[i] = int.Parse(s[i].Split(" ")[1]);
            }
            return (words, values);
        }

        public string GetWord(string word) 
        {
            (string[] words, int[] vals) = GetFG();
            int index = Array.IndexOf(words, word);
            Random random = new Random();
            int rand_ind = random.Next(95, 100);
            if (index <= rand_ind)
            {
                return words[index];
            }
            else
            {
                return words[rand_ind];
            }
        }

        public string GetTextUsingFG()
        {
            (string[] words, int[] vals) = GetFG();
            Random random = new Random();
            string[] all_words = new string[1000];
            string word;
            for (int i = 0; i < 1000; i++)
            {
                word = words[random.Next(0, words.Length)];
                all_words[i] = GetWord(word);
            }
            string str = string.Join(' ', all_words);
            File.Create(outputfile).Close();
            File.WriteAllText(outputfile, str);
            return str;
        }
    }

    // Разработать генератор текста на основе частотных свойств пар слов
    public class BiFreqGenerator
    {
        string inputfile;
        string outputfile;

        public BiFreqGenerator(string file1, string file2)
        {
            inputfile = file1;
            outputfile = file2;
        }
        public (string[], int[]) GetBFG()
        {
            string[] words = new string[100];
            string[] s = File.ReadAllLines(inputfile);
            int[] values = new int[100];
            for (int i = 0; i < 100; i++)
            { 
                words[i] = s[i].Split("  ")[0];
                values[i] = int.Parse(s[i].Split("  ")[1]);
            }
            return (words, values);
        }

        public string GetWords(string word) 
        {
            (string[] words, int[] vals) = GetBFG();
            int index = Array.IndexOf(words, word);
            Random random = new Random();
            int rand_ind = random.Next(95, 100);
            if (index <= rand_ind)
            {
                return words[index];
            }
            else
            {
                return words[rand_ind];
            }
        }

        public string GetTextUsingBFG()
        {
            (string[] words, int[] vals) = GetBFG();
            Random random = new Random();
            string[] all_words = new string[1000];
            string word;
            for (int i = 0; i < 1000; i++)
            {
                word = words[random.Next(0, words.Length)];
                all_words[i] = GetWords(word);
            }
            string str = string.Join(' ', all_words);
            File.Create(outputfile).Close();
            File.WriteAllText(outputfile, str);
            return str;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BigrammGenerator bg = new BigrammGenerator("mod-lab05-gen/tables/BG.txt", "mod-lab05-gen/outputs/result1.txt");
            bg.GetCharsUsingBG();

            FreqGenerator fg = new FreqGenerator("mod-lab05-gen/tables/FG.txt", "mod-lab05-gen/outputs/result2.txt");
            fg.GetTextUsingFG();

            BiFreqGenerator bfg = new BiFreqGenerator("mod-lab05-gen/tables/BFG.txt", "mod-lab05-gen/outputs/result3.txt");
            bfg.GetTextUsingBFG();
        }
    }
}

