using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace generator
{
    public class CharGenerator 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        protected char[] data;
        protected int size;
        protected Random random = new Random();
        public CharGenerator() 
        {
           size = syms.Length;
           data = syms.ToCharArray(); 
        }
        public char GetSym() 
        {
           return data[random.Next(0, size)];
        }
    }

    public class BigramGenerator : CharGenerator {

        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";

        private int[,] BigramTable;
        private int[] LineWeightSum;

        private int LastCharIndex;

        public BigramGenerator(string filename) : base()
        {
            data = syms.ToCharArray();
            size = syms.Length;

            BigramTable = new int[this.size, this.size];

            using (var parser = new TextFieldParser(filename)) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                for (int i = 0; i < this.size; i++)
                {
                    //Process row
                    string[] fields = parser.ReadFields();

                    for (int j = 0; j < this.size; j++) {
                        string field = fields[j];

                        if (field != "")
                        {
                            BigramTable[i, j] = int.Parse(field);
                        }
                        else
                        {
                            BigramTable[i, j] = 0;
                        }
                    }
                }
            }

            LineWeightSum = new int[this.size];

            for (int i = 0; i < this.size; i++)
            {
                LineWeightSum[i] = 0;

                for (int j = 0; j < this.size; j++)
                {
                    LineWeightSum[i] += BigramTable[i, j];
                }
            }

            LastCharIndex = 0;
        }

        public BigramGenerator() : this("../../../../data/bigram.csv") { }

        new public char GetSym()
        {
            int i = LastCharIndex;

            int sourced_random_number = random.Next(0, this.LineWeightSum[i]);

            int chosen_index = 0;

            for (int j = 0; j < this.size; j++) {

                chosen_index = j;

                if (sourced_random_number - BigramTable[i, j] < 0)
                {
                    break;
                }
                else
                {
                    sourced_random_number -= BigramTable[i, j];
                }
            }

            return data[chosen_index];
        }
    }

    public class WordGenerator : CharGenerator
    {
        private string[] words;
        private int[] weights;

        bool inWord;

        int current_word_index;
        int current_letter_index;

        int TotalWeightSum;

        const int WordCount = 100;

        public WordGenerator(string filename) : base()
        {
            words = new string[WordCount];
            weights = new int[WordCount];

            this.size = WordCount;

            using (var parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                for (int i = 0; i < this.size; i++)
                {
                    //Process row
                    string[] fields = parser.ReadFields();

                    words[i] = fields[0] == null ? "" : fields[0];
                    weights[i] = int.Parse(fields[1]);
                }
            }

            inWord = false;

            current_word_index = 0;
            current_letter_index = 0;

            TotalWeightSum = 0;

            foreach (var elem in weights)
            {
                TotalWeightSum += elem;
            }
        }

        public WordGenerator() : this("../../../../data/words.csv")
        {
            
        }

        private void ChooseOutputString() {
            int sourced_random_number = random.Next(0, this.TotalWeightSum);

            int chosen_index = 0;

            for (int i = 0; i < WordCount; i++)
            {
                chosen_index = i;

                if (sourced_random_number - weights[i] < 0)
                {
                    break;
                }
                else
                {
                    sourced_random_number -= weights[i];
                }
            }

            current_word_index = chosen_index;
            current_letter_index = 0;
            inWord = true;
        }

        new public char GetSym()
        {
            if (!inWord)
            {
                ChooseOutputString();
                return words[current_word_index][current_letter_index++];
            }
            else
            {
                int word_length = words[current_word_index].Length;

                if (current_letter_index < word_length)
                {
                    char ch = words[current_word_index][current_letter_index++];
                    return ch;
                }
                else if (current_letter_index == word_length)
                {
                    current_letter_index++;
                    return ' ';
                }
                else 
                {
                    inWord = false;
                    current_word_index = 0;
                    current_letter_index = 0;

                    return GetSym();
                }
            }
        }
    }

    public class WordPairGenerator : WordGenerator 
    {
        public WordPairGenerator(string filename) : base(filename)
        {

        }
        public WordPairGenerator() : base("../../../../data/word_pairs.csv") {
        
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BigramGenerator b_gen = new BigramGenerator();
            WordGenerator w_gen = new WordGenerator();
            WordPairGenerator p_gen = new WordPairGenerator();

            using (StreamWriter sw = new StreamWriter("BigramGeneratedText.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    sw.Write(b_gen.GetSym());
                }
            }

            using (StreamWriter sw = new StreamWriter("WordGeneratedText.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    sw.Write(w_gen.GetSym());
                }
            }

            using (StreamWriter sw = new StreamWriter("WordPairGeneratedText.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    sw.Write(p_gen.GetSym());
                }
            }
        }
    }
}

