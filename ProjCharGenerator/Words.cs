using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjCharGenerator
{
    public class Words
    {
        Dictionary<string, int> WordF;
        Random r;
        int frSum;

        public Words(Random r)
        {
            frSum = 0;
            this.r = r;
            WordF = new Dictionary<string, int>();
            string[] rows = File.ReadAllLines(@"Sources/WordsFreq.txt");

            for (int i = 0; i < rows.Length; i++)
            {
                string[] temp = rows[i].Split('\t');
                WordF.Add(temp[0], int.Parse(temp[1]));
                frSum += int.Parse(temp[1]);
            }
        }
        public void Show()
        {
            foreach (var item in WordF)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
        string GetRandomWord()
        {
            string bg = "";

            int temp = r.Next(0, frSum);
            int tempsum = 0;
            foreach (var item in WordF)
            {
                tempsum += item.Value;
                if (temp < tempsum)
                {
                    bg = item.Key;
                    break;
                }
            }

            return bg;
        }
        public string GetText(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += GetRandomWord() + " ";
            }
            return result;
        }
        public void WriteToFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}
