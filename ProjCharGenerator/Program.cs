using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace generator
{
    class Program
    {
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
