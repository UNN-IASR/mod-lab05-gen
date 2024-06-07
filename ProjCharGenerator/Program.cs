using ProjCharGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace generator
{

   public class Program
    {
        
        public static void Function_generation_onegramm()
        {
            string Out_file = "../../GEN-ONEGRAMM.txt";
            CharGenerator CG = new CharGenerator();
            using (StreamWriter Stream_Writer = new StreamWriter(Out_file))
            {
                SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
                for (int i = 0; i < 1000; i++)
                {
                    char ch = CG.getSym();
                    if (stat.ContainsKey(ch))
                    {
                        stat[ch]++;
                    }
                    else
                    {
                        stat.Add(ch, 1);
                    }
                    
                    Stream_Writer.Write(ch);
                    if (i % 20 == 0 && i != 0) { Stream_Writer.WriteLine(); }//для комфортного чтения файла 
                }
                Stream_Writer.WriteLine();
                foreach (KeyValuePair<char, int> entry in stat)
                {
                    Stream_Writer.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
                }
            }
        }
        public static void function_for_generation_bigramm()
            {
                string Out_file = "../../GEN-BI.txt";
                //Записываем всё в файл gen-0.txt в результате работы CharGenerator
                Generator_BIGRAMM bi = new Generator_BIGRAMM();
                char Start_symbol = 'a';
                using (StreamWriter Stream_Writer = new StreamWriter(Out_file))
                {
                    SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
                    for (int i = 0; i < 1000; i++)
                    {
                        char ch = bi.GenerateNextSymbol(Start_symbol);
                        if (stat.ContainsKey(ch))
                        {
                            stat[ch]++;
                        }
                        else
                        {
                            stat.Add(ch, 1);
                        }
                        Start_symbol = ch;
                        Stream_Writer.Write(ch);
                    if (i % 20 == 0 && i != 0) { Stream_Writer.WriteLine(); }//для комфортного чтения файла 
                }
                    Stream_Writer.WriteLine();
                    foreach (KeyValuePair<char, int> entry in stat)
                    {
                        Stream_Writer.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
                    }
                }
            }
        public static void Func_for_generation_word()
        {
            string Out_file = @"C:\Users\Юрий\source\repos\mod-lab05-gen\GEN-Words.txt";
            //Записываем всё в файл gen-0.txt в результате работы CharGenerator
            WordGenerator gw = new WordGenerator();
            using (StreamWriter Stream_Writer = new StreamWriter(Out_file))
            {
                SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
                for (int i = 0; i < 1000; i++)
                {
                    
                    string word = gw.GenerateWord();
                    if (stat.ContainsKey(word))
                    {
                        stat[word]++;
                    }
                    else
                    {
                        stat.Add(word, 1);
                    }
                    Stream_Writer.Write(word + " ");
                    if (i % 20 == 0&& i!=0) { Stream_Writer.WriteLine(); }//для комфортного чтения файла 
                }
                Stream_Writer.WriteLine();
                foreach (KeyValuePair<string, int> entry in stat)
                {
                    Stream_Writer.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
                }
            }
           
        }
    
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for (int i = 0; i < 1000; i++)
            {
                char ch = gen.getSym();
                if (stat.ContainsKey(ch))
                    stat[ch]++;
                else
                    stat.Add(ch, 1); Console.Write(ch);
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat)
            {
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
            }

            Function_generation_onegramm();
            function_for_generation_bigramm();
            Func_for_generation_word();
        }
    }
}


