using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCharGenerator
{
    public class WordGenerator
    {
        public SortedDictionary<string, int> stat;

        public Int64 sum;

        public WordGenerator(string path)
        {
            stat = new SortedDictionary<string, int>();

            // асинхронное чтение
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(" ");
                    stat.Add(words[1], int.Parse(words[2]));
                    sum += int.Parse(words[2]);
                }
            }
        }

        public void Generate(int n)
        {

            var result = new StringBuilder();
            var rand = new Random();
            var prev = " ";
            for (int i = 0; i < n; i++)
            {
                double s = 0;
                double shot = (double)(rand.NextInt64(sum)) / sum;
             
                    result.Append(' ');
               
                    foreach (var item in stat)
                    { 
                        s += (double)item.Value / sum;
                        if (s >= shot)
                        {
                            result.Append(item.Key);
                            break;
                        }
                    }
              
                prev = result[result.Length - 1].ToString();
            }

            using (StreamWriter writer = new StreamWriter("../../../gen2.txt", false))
            {
                writer.Write(result);
            }
        }

    }
}
