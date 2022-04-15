using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjCharGenerator
{
    public class Bigrams
    {
        int[,] pairFr;
        string alp = "абвгдежзийклмнопрстуфхцчшщыьэюя";
        Random r;
        int frSum;
        public Bigrams(Random r)
        {
            pairFr = new int[alp.Length, alp.Length];
            this.r = r;
            frSum = 0;
            string[] rows = File.ReadAllLines(@"Sources/Bigrams.txt");
            for (int i = 0; i < alp.Length; i++)
            {
                var values = Regex.Matches(rows[i], @"\d+").Select(m => int.Parse(m.Value)).ToArray();
                for (int j = 0; j < alp.Length; j++)
                {
                    pairFr[i, j] = values[j];
                    frSum += values[j];
                }
            }
        }
        public void Show()
        {
            for (int i = 0; i < alp.Length; i++)
            {
                for (int j = 0; j < alp.Length; j++)
                {
                    Console.Write("{0} ", pairFr[i, j]);
                }
                Console.WriteLine();
            }
        }

        string GetRandomBigram()
        {
            string bg = "";

            int temp = r.Next(0, frSum);
            int tempsum = 0;
            for (int i = 0; i < alp.Length; i++)
            {
                for (int j = 0; j < alp.Length; j++)
                {
                    tempsum += pairFr[i, j];
                    if ((temp < tempsum) && (pairFr[i, j] != 0))
                    {
                        bg = alp[i].ToString() + alp[j].ToString();
                        j = alp.Length;
                        i = alp.Length;
                    }
                }
            }
            return bg;
        }

        public string GetText(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += GetRandomBigram() + " ";
            }
            return result;
        }
        public void WriteToFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}
