using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    //генератор текста на основе пар букв (биграмм)
    public class BigramsGenerator
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        private int[,] weights;
        //Массив верхних границ диапазона целых чисел для каждого из символов
        int[,] np;
        int[] summa;
        int lastSym = -1;
        public BigramsGenerator()
        {
            size = syms.Length;
            data = syms.ToCharArray();
            weights = new int[size, size];
            summa = new int[size];

            using (StreamReader reader = new StreamReader("inputs/bigrams.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    string str = reader.ReadLine();
                    string ch = "";
                    int j = 0;
                    foreach (char s in str)
                    {
                        if (s != '\t')
                        {
                            ch = ch + s;
                        }
                        else
                        {
                            weights[i, j] = Int32.Parse(ch);
                            ch = "";
                            j++;

                        }
                    }
                    weights[i, size - 1] = Int32.Parse(ch);
                }

            }

            data = syms.ToCharArray();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    summa[i] += weights[i, j];
                }
            }
            np = new int[size, size];
            //заполнение массива верхних границ символов
            int s2 = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    s2 += weights[i, j];
                    np[i, j] = s2;
                }
            }
        }

        public char getBinSym()
        {
            int m;
            if (lastSym == -1)
            {
                m = random.Next(0, summa[random.Next(0, size)]);
                lastSym = 0;
            }
            else
            {
                m = random.Next(0, summa[lastSym]);
            }
            //поиск символа по его диапазону случайных значений
            int j;
            for (j = 0; j < size; j++)
            {
                if (m < np[lastSym, j])
                    break;
            }
            lastSym = j;
            return data[j];
        }

        public SortedDictionary<char, int> saveToFile(string path)
        {
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();

            File.WriteAllText(path, string.Empty);
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                for (int i = 0; i < 1000; i++)
                {
                    char ch = getBinSym();
                    if (stat.ContainsKey(ch))
                        stat[ch]++;
                    else
                        stat.Add(ch, 1);

                    writer.Write(ch + " ");
                }
            }

            return stat;
        }
    }


        //генератор текста на основе частотных свойств слов

        public class WordsGenerator
        {
            private string[] words;
            private int size = 100;
            private Random random = new Random();
            private int[] weights;
            //Массив верхних границ диапазона целых чисел для каждого из символов
            int[] np;
            int summa;
            public WordsGenerator()
            {
                weights = new int[size];
                words = new string[size];
                summa = 0;
                int space;

                using (StreamReader reader = new StreamReader("inputs/words.txt"))
                {
                    for (int i = 0; i < size; i++)
                    {
                        string str = reader.ReadLine();
                        space = str.IndexOf('\t');
                        words[i] = str.Substring(0, space);
                        weights[i] = Int32.Parse(str.Substring(space + 1));
                    }

                }

                for (int i = 0; i < size; i++)
                {
                    summa += weights[i];
                }
                np = new int[size];
                //заполнение массива верхних границ символов
                int s2 = 0;
                for (int i = 0; i < size; i++)
                {
                    s2 += weights[i];
                    np[i] = s2;
                }

            }

            public string getWord()
            {
                int m = random.Next(0, summa);
                int j;
                //поиск символа по его диапазону случайных значений
                for (j = 0; j < size; j++)
                {
                    if (m < np[j])
                        break;
                }
                return words[j];
            }

            public SortedDictionary<string, int> saveToFile(string path)
            {
                SortedDictionary<string, int> stat = new SortedDictionary<string, int>();

                File.WriteAllText(path, string.Empty);
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        string s = getWord();
                        if (stat.ContainsKey(s))
                            stat[s]++;
                        else
                            stat.Add(s, 1);

                        writer.Write(s + " ");
                    }
                }

                return stat;
            }
        }


        //генератор текста на основе частотных свойств пар слов

        public class BiWordsGenerator
        {
            private string[] words;
            private int size = 100;
            private Random random = new Random();
            private int[] weights;
            //Массив верхних границ диапазона целых чисел для каждого из символов
            int[] np;
            int summa;
            public BiWordsGenerator()
            {
                weights = new int[size];
                words = new string[size];
                summa = 0;
                int space;

                using (StreamReader reader = new StreamReader("inputs/biWords.txt"))
                {
                    for (int i = 0; i < size; i++)
                    {
                        string str = reader.ReadLine();
                        space = str.IndexOf('\t');
                        words[i] = str.Substring(0, space);
                        weights[i] = Int32.Parse(str.Substring(space + 1));
                    }

                }

                for (int i = 0; i < size; i++)
                {
                    summa += weights[i];
                }
                np = new int[size];
                //заполнение массива верхних границ символов
                int s2 = 0;
                for (int i = 0; i < size; i++)
                {
                    s2 += weights[i];
                    np[i] = s2;
                }

            }

            public string getBiWord()
            {
                int m = random.Next(0, summa);
                int j;
                //поиск символа по его диапазону случайных значений
                for (j = 0; j < size; j++)
                {
                    if (m < np[j])
                        break;
                }
                return words[j];
            }

            public SortedDictionary<string, int> saveToFile(string path)
            {
                SortedDictionary<string, int> stat = new SortedDictionary<string, int>();

                File.WriteAllText(path, string.Empty);
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        string s = getBiWord();
                        if (stat.ContainsKey(s))
                            stat[s]++;
                        else
                            stat.Add(s, 1);

                        writer.Write(s + " ");
                    }
                }

                return stat;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                //генератор текста на основе пар букв (биграмм)
                BigramsGenerator gen1 = new BigramsGenerator();
                gen1.saveToFile("results/first.txt");

                //генератор текста на основе частотных свойств слов

                WordsGenerator gen2 = new WordsGenerator();
                gen2.saveToFile("results/second.txt");

                //генератор текста на основе частотных свойств пар слов

                BiWordsGenerator gen3 = new BiWordsGenerator();
                gen3.saveToFile("results/third.txt");
            }
        }
    }


