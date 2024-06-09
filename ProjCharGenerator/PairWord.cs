using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace generator
{
    public class PairWord
    {
        public SortedDictionary<string, double> stat3 = new SortedDictionary<string, double>();

        public Dictionary<string, double> stat = new Dictionary<string, double>();

        private Random random = new Random();
        string text = "";
       
        public PairWord()
        {
            ReadFile();

        }
       public void ReadFile()
        {
            StreamReader file = new StreamReader("PairWord.txt");

            while (!file.EndOfStream)
            {
                // string[] temp = file.ReadLine().Split("  ");
                string[] temp = file.ReadLine().Split('|');
                stat.Add(temp[1], double.Parse(temp[0]));

            }

            GetCount();
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
           // SortedDictionary<string, double> stat3 = new SortedDictionary<string, double>();

            for (int i = 0; i < 1000; i++)
            {
                string ch = getSym();
                if (stat3.ContainsKey(ch))
                    stat3[ch]++;
                else
                    stat3.Add(ch, 1);
                Console.Write(ch + " ");
                text = text + " " + ch;
            }
            Console.Write('\n');
            foreach (KeyValuePair<string, double> entry in stat3)
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


    }
}
