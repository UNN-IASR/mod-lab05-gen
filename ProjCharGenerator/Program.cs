using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace generator
{
    class Program
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
        
        
        public class Generator_BIgramm
        {
            private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
            private char[] data;
            private int size;
            private Random random = new Random();
            //Массив верхних границ диапазона целых чисел для каждого из символов
            private int[,] np;
            // Массив весов
            private int[,] weights;
            public Generator_BIgramm()
            {
                size = syms.Length;
                data = syms.ToCharArray();
                np = new int[size, size];
                weights = new int[size, size];
        
                string BItxt = @"C:\Users\wizze\source\repos\lab5MIPS\txt files for generate\BI.txt";
                StreamReader Stream_Reader = new StreamReader(BItxt, Encoding.GetEncoding(1251));
        
                //Считываем первую строку из файла BI.txt
                #nullable enable
                string? line = Stream_Reader.ReadLine();
                //Продолжаем читать файл BI.txt пока не закончится 
                while (line != null)
                {
                    string[] Split_line = line.Split(new char[] { '\t' });
                    int W = int.Parse(Split_line[2]);
                    weights[syms.IndexOf(Split_line[1][0]), syms.IndexOf(Split_line[1][1])] = W;
                    line = Stream_Reader.ReadLine();
                }
        
                int summary_weigt = 0;
                //Заполнение массива верхних границ символов
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        summary_weigt += weights[i, j];
                        np[i, j] = summary_weigt;
                    }
                }
            }
        
            public char getSym(char letter)
            {
                //m - это случайное число получаемое в диапазоне от l до r
                int m = 0;
                if (syms.Contains(letter))
                {
                    int l;
                    if (letter != syms[0])
                    {
                        l = np[syms.IndexOf(letter) - 1, size - 1];
                    }
                    else
                    {
                        l = 0;
                    }
                    int r = np[syms.IndexOf(letter), size - 1];
                    m = random.Next(l, r + 1);
                }
                else
                {
                    return syms[random.Next(0, size)];
                }
        
                int j = 0;
                //Поиск символа по его диапазону случайных значений
                for (int i = 0; i < size; i++)
                {
                    for (j = 0; j < size; j++)
                    {
                        if (m <= np[i, j])
                        {
                            return data[j];
                        }
                    }
                }
                return data[j];
            }
        }
        
        public class Generator_Words_Text
        {
            private const int limit = 100;
            //По заданию разрешено взять 100 слов и их частотных свойств
            private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
            private int size;
            private Random random = new Random();
            //Слова
            public string[] words;
            //Частоты использования слов
            public int[] frequency;
            //Массив верхних границ диапазона целых чисел
            public int[] np;
            public int Summa = 0;
        
            public Generator_Words_Text()
            {
                size = syms.Length;
                np = new int[limit];
                words = new string[limit];
                frequency = new int[limit];
        
                string FreqWords = @"C:\Users\wizze\source\repos\lab5MIPS\txt files for generate\frequency_properties_of_words.txt";
                StreamReader Stream_Reader = new StreamReader(FreqWords, Encoding.GetEncoding(1251));
        
                //Считываем первую строку из файла requency_properties_of_words.txt
                #nullable enable
                string? line = Stream_Reader.ReadLine();
                //Продолжаем читать файл frequency_properties_of_words.txt пока не закончится 
                int i = 0;
                while (line != null)
                {
                    string[] Split_line = line.Split(new char[] { '\t' });
                    // index 1 = word; index 3 = frequency
                    words[i] = Split_line[1];
                    frequency[i] = int.Parse(Split_line[3]);
                    i++;
                    line = Stream_Reader.ReadLine();
                }
            }
        
            //Чтобы избежать работу с миллионами, для удобства уменьшим частоты
            //Берём самую минимальную частоту MIN и вычитаем её из каждого элемента
            public void Minimizing_and_Calculating_Summa()
            {
                int min = frequency[99];
                for (int i = 0; i < 100; i++)
                {
                    frequency[i] -= min;
                }
                //Считаем summa опираясь на верхние границы из np
                np[0] = frequency[0];
                for (int i = 1; i < 100; i++)
                {
                    np[i] = np[i - 1] + frequency[i];
                }
                Summa = np[99];
            }
        
            public string getWord()
            {
                int m = random.Next(0, Summa);
                int j = 0;
                for (j = 0; j < size; j++)
                {
                    if (m < np[j])
                    {
                        break;
                    }
                }
                return words[j];
            }
        }
        
        static void funtion_for_gen_0_txt()
        {
            //Записываем путь файла gen-0.txt для удобства работы с ним
            string File_Name = @"C:\Users\wizze\source\repos\lab5MIPS\gen-0.txt";
            //Записываем всё в файл gen-0.txt в результате работы CharGenerator
            CharGenerator gen = new CharGenerator();
            using (StreamWriter Stream_Writer = new StreamWriter(File_Name))
            {
                SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
                for (int i = 0; i < 1000; i++)
                {
                    char ch = gen.getSym();
                    if (stat.ContainsKey(ch))
                    {
                        stat[ch]++;
                    }
                    else
                    {
                        stat.Add(ch, 1);
                    }
                    Stream_Writer.Write(ch);
                }
                Stream_Writer.WriteLine();
                foreach (KeyValuePair<char, int> entry in stat)
                {
                    Stream_Writer.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
                }
            }
        }

        static void funtion_for_gen_1_txt()
        {
            //Записываем путь файла gen-0.txt для удобства работы с ним
            string File_Name = @"C:\Users\wizze\source\repos\lab5MIPS\gen-1.txt";
            //Записываем всё в файл gen-0.txt в результате работы CharGenerator
            Generator_BIgramm gen1 = new Generator_BIgramm();
            //Первое вхождение для того чтобы оно работало 
            char letter = 'а';
            using (StreamWriter Stream_Writer = new StreamWriter(File_Name))
            {
                SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
                for (int i = 0; i < 1000; i++)
                {
                    char ch = gen1.getSym(letter);
                    if (stat.ContainsKey(ch))
                    {
                        stat[ch]++;
                    }
                    else
                    {
                        stat.Add(ch, 1);
                    }
                    letter = ch;
                    Stream_Writer.Write(ch);
                }
                Stream_Writer.WriteLine();
                foreach (KeyValuePair<char, int> entry in stat)
                {
                    Stream_Writer.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
                }
            }
        }

        static void funtion_for_gen_2_txt()
        {
            //Записываем путь файла gen-0.txt для удобства работы с ним
            string File_Name = @"C:\Users\wizze\source\repos\lab5MIPS\gen-2.txt";
            //Записываем всё в файл gen-0.txt в результате работы CharGenerator
            Generator_Words_Text gen2 = new Generator_Words_Text();
            gen2.Minimizing_and_Calculating_Summa();
            using (StreamWriter Stream_Writer = new StreamWriter(File_Name))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string ch = String.Concat(gen2.getWord()," ");
                    Stream_Writer.Write(ch);
                }
            }
        }

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;

            funtion_for_gen_0_txt();

            funtion_for_gen_1_txt();

            funtion_for_gen_2_txt();
        }
    }
}
