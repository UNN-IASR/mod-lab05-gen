using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace generator
{
    public class Generator
    {
        public List<string> syms;
        public List<int> weights;
        public int max;
        public Generator(List<string> _syms, List<int> _weights)
        {
            syms = _syms;
            weights = _weights;
            foreach (var w in weights) max += w;
        }
        public string getSym()
        {
            Random random = new Random();
            int randnum = random.Next(max);
            string res = "";
            for (int i = 0; i < syms.Count; i++)
            {
                if (randnum < weights[i]) {
                    res = syms[i];
                    break;
                }
                randnum -= weights[i];
            }
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> syms = new List<string>();
            List<int>  weights = new List<int>();
            using (StreamReader file = new StreamReader("bigrams.txt"))
            {
                while (!file.EndOfStream)
                {
                    string[] line = file.ReadLine().Split();
                    syms.Add(line[0]);
                    weights.Add(Convert.ToInt32(line[1]));
                }
            }
            Generator gen1 = new Generator(syms, weights);
            string res = "";
            for (int i = 0; i < 1000; i++) res += gen1.getSym();
            using (StreamWriter file = new StreamWriter("gen1.txt"))
            {
                file.WriteLine(res);
            }

            syms = new List<string>();
            weights = new List<int>();
            using (StreamReader file = new StreamReader("words.txt"))
            {
                while (!file.EndOfStream)
                {
                    string[] line = file.ReadLine().Split();
                    syms.Add(line[0]);
                    weights.Add(Convert.ToInt32(line[1]));
                }
            }
            Generator gen2 = new Generator(syms, weights);
            res = "";
            for (int i = 0; i < 1000; i++) res += gen2.getSym() + ",";
            using (StreamWriter file = new StreamWriter("gen2.txt"))
            {
                file.WriteLine(res);
            }
        }
    }
}

