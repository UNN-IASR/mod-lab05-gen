using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace generator
{
    public class PairGenerator
    {


        Dictionary<char, Dictionary<char, int>> stat = new Dictionary<char, Dictionary<char, int>>();

        private Random random = new Random();
      
        public string text = "";
        public PairGenerator()
        {
            ReadFile();
            Sort();

        }

        public void ReadFile()
        {
            StreamReader file = new StreamReader("Bigramma.txt");
            char str = 'а';
            while (!file.EndOfStream)
            {
                Dictionary<char, int> temp_stat = new Dictionary<char, int>();
                string[] temp = file.ReadLine().Split();
                char str_temp = 'а';

                for (int i = 0; i < 32; i++)
                {
                    temp_stat.Add(str_temp, int.Parse(temp[i]));
                    str_temp++;
                }

                stat.Add(str, temp_stat);
                str++;
            }

        }

        public void Sort()
        {
            Dictionary<char, int> temp_stat = new Dictionary<char, int>();
            for (char i = 'а'; i <= 'я'; i++)
            {
                temp_stat = stat[i];
                var sorted_temp = temp_stat.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                stat[i] = sorted_temp;
            }
        }


       public int GetCount(char current)
        {
            int count = 0;
            foreach (var temp2 in stat[current])
            {
                count = count + temp2.Value;

            }
            return count;
        }

        public string Text(char ch1)
        {
            SortedDictionary<char, int> stat1 = new SortedDictionary<char, int>();

            //char ch1 = 'р';


            if (stat1.ContainsKey(ch1))
                stat1[ch1]++;
            else
                stat1.Add(ch1, 1); Console.Write(ch1);
            text = text + ch1;

            for (int i = 0; i < 999; i++)
            {

                ch1 = getSym(ch1);
                if (stat1.ContainsKey(ch1))
                    stat1[ch1]++;
                else
                    stat1.Add(ch1, 1);
                Console.Write(ch1);
                text = text + ch1;
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat1)
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


        public char getSym(char current_char)
        {
            double rnd = random.NextDouble();

            //    char selectedElement = (char)random.Next('а','я');
            char selectedElement = ' ';

            double cumulative = 0;
            Dictionary<char, int> temp_stat = stat[current_char];

            while (cumulative <= rnd)
            {
                cumulative = 0;
                rnd = random.NextDouble();

                //for (char j = 'а'; j <= 'я'; j++)
                foreach (var temp in temp_stat)
                {
                    //  cumulative += temp_stat[j]/count;
                    int sum = GetCount(current_char);
                    cumulative += (double)(temp.Value) / sum;


                    if (rnd < cumulative)
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


