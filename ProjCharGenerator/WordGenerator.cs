using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace generator
{
    public class WordGenerator
    {
       public SortedDictionary<string, double> stat2 = new SortedDictionary<string, double>();

        public Dictionary<string, double> stat = new Dictionary<string, double>();
        string text = "";
        private Random random = new Random();
       
        public WordGenerator()
        {
            ReadFile();


        }
        public void ReadFile()
        {
            StreamReader file = new StreamReader("FrequencyWord.txt");

            while (!file.EndOfStream)
            {
                string[] temp = file.ReadLine().Split();
                stat.Add(temp[0], double.Parse(temp[1]));

            }
         //   GetCount();
        }

        public double GetCount()
        {
            double count = 0;   
            foreach (KeyValuePair<string, double> temp in stat)
            {
                count = count + temp.Value;
            }
            return count;
        }


        public string Text()
        {
          // SortedDictionary<string, double> stat2 = new SortedDictionary<string, double>();

            for (int i = 0; i < 1000; i++)
            {
                string ch = getSym();
                if (stat2.ContainsKey(ch))
                    stat2[ch]++;
                else
                    stat2.Add(ch, 1);
                Console.Write(ch + " ");
                text = text + " " + ch;
            }
            Console.Write('\n');
            foreach (KeyValuePair<string, double> entry in stat2)
            {
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value / 1000.0);
            }
            return text;
        }


        public void WriteFile(string file_name)
        {
            StreamWriter file = new StreamWriter(file_name);
            file.WriteLine(text);
            file.Close();

        }


        public string getSym()
        {
            double diceRoll = random.NextDouble();
            string selectedElement = " ";
            double cumulative = 0;


            while (cumulative <= diceRoll)
            {
                cumulative = 0;
                diceRoll = random.NextDouble();
                foreach (KeyValuePair<string, double> temp in stat)
                {
                    cumulative += temp.Value / GetCount();

                    if (diceRoll < cumulative)
                    {
                        selectedElement = temp.Key;
                        break;
                    }
                }
            }
            return selectedElement;

        }

    }

}
