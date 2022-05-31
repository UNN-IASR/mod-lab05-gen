using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace generator
{
    class FrequencyGen
    {
        public FrequencyGen(String filePath)
        {
            usageBase = new Dictionary<string, int>();
            StreamReader sr = File.OpenText(filePath);
            String str;
            List<List<String>> lines = new List<List<string>>();
            while ((str = sr.ReadLine()) != null)
            {
                lines.Add(new List<string>());
                lines[lines.Count - 1] = ProjCharGenerator.utils.readLine(str);
            }
            str = "";
            foreach(var line in lines)
            {
                str += line[0];
                for(int i = 1; i < line.Count()-1; i++)
                {
                    str += " " + line[i];
                }
                usageBase[str] = Int32.Parse(line[line.Count()-1]);
                str = "";
            }
        }
        public FrequencyGen(Dictionary<String, int> usageTable)
        {
            usageBase = usageTable;
        }
        public string Next(int size)
        {
            String returnString = "";
            int chanceSum = 0;
            int[] mass;
            long chance;
            for (int i = 0; i<size; i++)
            {
                mass = new int[usageBase.Values.Count];
                usageBase.Values.CopyTo(mass, 0);
                chance = rand.Next(0, mass.Sum());
                foreach (var pair in usageBase)
                {
                    if (pair.Value + chanceSum >= chance)
                    {
                        returnString += pair.Key + " ";
                        chanceSum = 0;
                        break;
                    }
                    else
                    {
                        chanceSum += pair.Value;
                    }
                }
            }
            return returnString;
        }
        public void printBase()
        {
            foreach(var pair in usageBase)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value.ToString());
            }
        }
        private Random rand = new Random();
        private Dictionary<String, int> usageBase;
    }
    class BigramGen
    {
        public BigramGen(String filePath)
        {
            usageBase = new Dictionary<char, Dictionary<char, int>>();
            StreamReader sr = File.OpenText(filePath);
            String str;
            List<List<String>> lines = new List<List<string>>();
            while ((str = sr.ReadLine()) != null)
            {
                lines.Add(new List<string>());
                lines[lines.Count-1] = ProjCharGenerator.utils.readLine(str);
            }
            syms = new char[lines.Count];
            for(int i = 0; i < lines.Count; i++)
            {
                syms[i] = lines[i][0][0];
            }
            for(int i = 0; i < syms.Length; i++)
            {
                usageBase[syms[i]] = new Dictionary<char, int>();
                for(int j = 1; j< lines[i].Count;j++)
                {
                    usageBase[syms[i]][syms[j - 1]] = Int32.Parse(lines[i][j]);
                }
            }
        }
        public BigramGen(Dictionary<char,Dictionary<char,int>> usageTable)
        {
            usageBase = usageTable;
            syms = new char[usageBase.Keys.Count];
            usageBase.Keys.CopyTo(syms, 0);
        }
        public String Next(int size)
        {
            String returnString = "";

            int nextPos = rand.Next(0,syms.Length);
            char nextSym = syms[nextPos];
            int chanceSum = 0;
            int[] mass;
            int chance;

            returnString += nextSym;
            for(int i = 0; i < size-1; i++)
            {
                mass = new int[usageBase[nextSym].Values.Count];
                usageBase[nextSym].Values.CopyTo(mass, 0);
                chance = rand.Next(0, mass.Sum());
                foreach(var pair in usageBase[nextSym])
                {
                    if(pair.Value+chanceSum >= chance)
                    {
                        nextSym = pair.Key;
                        returnString += nextSym;
                        chanceSum = 0;
                        break;
                    }
                    else
                    {
                        chanceSum += pair.Value;
                    }
                }
            }
            return returnString;
        }
        public void PrintBase()
        {
            foreach(var key in usageBase)
            {
                Console.Write(key.Key.ToString() + ": { ");
                foreach(var value in key.Value)
                {
                    Console.Write(value.Value.ToString() + " ");
                }
                Console.WriteLine("} ");
            }
        }
        private char[] syms;
        private Random rand = new Random();
        private Dictionary<char, Dictionary<char, int>> usageBase;
    }

    class CharGen 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGen()
        {
           size = syms.Length;
           data = syms.ToCharArray();
        }
        public char getSym()
        {
           return data[random.Next(0, size)];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BigramGen bgen = new BigramGen(@"..\..\..\Bigram.txt");
            FrequencyGen fgen1 = new FrequencyGen(@"..\..\..\Frequency1.txt");
            FrequencyGen fgen2 = new FrequencyGen(@"..\..\..\Frequency2.txt");
            File.WriteAllText(@"..\..\..\BigramOutput.txt",bgen.Next(1000));
            File.WriteAllText(@"..\..\..\Frequency1Output.txt", fgen1.Next(1000));
            File.WriteAllText(@"..\..\..\Frequency2Output.txt", fgen2.Next(1000));
        }
    }
}

