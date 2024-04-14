using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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

    public class BiCharGenerator
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        private int[,] weights;
        private int[,] np;

        public BiCharGenerator()
        {
            size = syms.Length;
            weights = new int[size, size];
            string path = "bi.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                #nullable enable
                string? line;
                while ((line = reader.ReadLine()) != null){
                    string[] input = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int first = syms.IndexOf(input[1][0]);
                    int second = syms.IndexOf(input[1][1]);
                    weights[first, second] = int.Parse(input[2]);
                }
                #nullable disable
            }
            data = syms.ToCharArray();
            np = new int[size, size];
            int s2 = 0;
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++){
                    s2 += weights[i, j];
                    np[i, j] = s2;
                }
            }
        }

        public char getSym(char prev)
        {
            int m = 0;
            if (syms.Contains(prev)) {
                int left;
                if (prev == syms[0])
                    left = 0;
                else
                    left = np[syms.IndexOf(prev) - 1, size - 1];
                int right = np[syms.IndexOf(prev), size - 1];
                m = random.Next(left, right + 1);
            }
            else
                return syms[random.Next(0, size)];
            int j = 0;
            for (int i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                {
                    if (m <= np[i, j]){
                        return data[j];
                    } 
                }
            return data[j];
        }
    }

    public class WordGenerator
    {
        const int ACCURACY = 100;
        private List<string> words;
        private int size;
        private Random random = new Random();
        private List <int> weights;
        private List <int> np;
        private int summa = 0;

        public WordGenerator()
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            size = 0;
            weights = new List<int>();
            words = new List<string>();
            string path = "word.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                #nullable enable
                string? line;
                while ((line = reader.ReadLine()) != null){
                    string[] input = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    words.Add(input[1]);
                    weights.Add(Convert.ToInt32(Double.Parse(input[2], formatter) * ACCURACY));
                    size ++;
                }
                #nullable disable
            }
            np = new List<int>();
            int s2 = 0;
            for (int i = 0; i < size; i++) {
                s2 += weights[i];
                np.Add(s2);
                summa += weights[i];
            }
        }

        public string getWord()
        {
            int m  = random.Next(0, summa);
            int j = 0;
            for (j = 0; j < size; j++)
            {
                if (m < np[j]){
                    break;
                } 
            }
            return words[j];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "gen-1.txt";
            StreamWriter writer = new StreamWriter(path);
            CharGenerator gen1 = new CharGenerator();
            SortedDictionary<char, int> stat1 = new SortedDictionary<char, int>();
            for(int i = 0; i < 1000; i++) 
            {
                char ch = gen1.getSym(); 
                if (stat1.ContainsKey(ch))
                    stat1[ch]++;
                else
                    stat1.Add(ch, 1);
                writer.Write(ch);
            }
            writer.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat1) 
            {
                 writer.Write("{0} - {1}\n",entry.Key,entry.Value/1000.0); 
            }
            writer.Close();

            path = "gen-2.txt";
            BiCharGenerator gen2 = new BiCharGenerator();
            SortedDictionary<char, int> stat2 = new SortedDictionary<char, int>();
            writer = new StreamWriter(path);
            char prev = '$';
            for(int i = 0; i < 1000; i++) 
            {
                char ch = gen2.getSym(prev); 
                if (stat2.ContainsKey(ch))
                    stat2[ch]++;
                else
                    stat2.Add(ch, 1);
                prev = ch;
                writer.Write(ch);
            }
            writer.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat2) 
            {
                 writer.Write("{0} - {1}\n",entry.Key,entry.Value/1000.0); 
            }
            writer.Close();

            path = "gen-3.txt";
            writer = new StreamWriter(path);
            WordGenerator gen3 = new WordGenerator();
            SortedDictionary<string, int> stat3 = new SortedDictionary<string, int>();
            for(int i = 0; i < 1000; i++) 
            {
                string word = gen3.getWord(); 
                if (stat3.ContainsKey(word))
                    stat3[word]++;
                else
                    stat3.Add(word, 1); 
                writer.Write(word + " ");
            }
            writer.Write('\n');
            foreach (KeyValuePair<string, int> entry in stat3) 
            {
                 writer.Write("{0} - {1}\n",entry.Key,entry.Value/1000.0); 
            }
            writer.Close();
        }
    }
}

