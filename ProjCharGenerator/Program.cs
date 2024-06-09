using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{

    class Program
    {


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



            PairGenerator gen1 = new PairGenerator();

            string file_name1 = "text1.txt";
            gen1.Text('а');
            file_name1 = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\", file_name1);
            gen1.WriteFile(file_name1);



            WordGenerator gen2 = new WordGenerator();
            string file_name2 = "text2.txt";
            file_name2 = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\", file_name2);
            gen2.Text();
            gen2.WriteFile(file_name2);


            PairWord gen3 = new PairWord();
            string file_name3 = "text3.txt";
            file_name3 = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\", file_name3);
            gen3.Text();
            gen3.WriteFile(file_name3);

        }
    }
}

