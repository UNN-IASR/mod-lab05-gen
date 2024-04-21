using System;
using System.IO;

namespace ProjCharGenerator
{
    public class Generator
    {
        private Random random = new Random();
        private Pair[] pairs;

        public Generator(string file)
        {
            string[] lines = File.ReadAllLines(file);
            pairs = new Pair[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(' ');
                pairs[i] = new Pair(split[0], int.Parse(split[1]));
            }
            Array.Sort(pairs, (p1,p2) => p2.weight.CompareTo(p1.weight));
        }

        public string getPartOfText()
        {
            int rand = random.Next(0, pairs[0].weight);
            for (int i = 0; i < pairs.Length; i++)
            {
                if (rand > pairs[i].weight) return pairs[i].word;
            }
            return "";
        }

        record Pair(string word, int weight) { }
    }
}
