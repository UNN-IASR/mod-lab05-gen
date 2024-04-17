using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;

namespace generator
{
    public class CharGenerator 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator() 
        {
           size = syms.Length;
           data = syms.ToCharArray(); 
        }
        public char getSym() 
        {
           return data[random.Next(0, size)]; 
        }
        public int getSize() {
            return size;
        }
        public bool isCharInData(char sym) {
            return Array.IndexOf(data, sym) != -1;
        }
    }
    public class BinaryCharGen {
        private Dictionary<char, Dictionary<char, int>> data;
        private int size;
        private Dictionary<char, int> summa;
        private Dictionary<char, Dictionary<char, int>> np;
        private Random random = new Random();

        public BinaryCharGen() {
            string[] splitline;
            data = new Dictionary<char, Dictionary<char, int>>();

            foreach(string line in File.ReadLines("data.csv")) {
                splitline = line.Split(',');
                if (data.ContainsKey(splitline[0][0]) == false) {
                    Dictionary<char, int> add_data = new Dictionary<char, int>
                    {
                        { splitline[0][1], Convert.ToInt32(splitline[1]) }
                    };
                    data.Add(splitline[0][0], add_data);
                }
                else {
                    data[splitline[0][0]].Add(splitline[0][1],Convert.ToInt32(splitline[1]));
                }
            }

            size = data.Count;
            np = new Dictionary<char, Dictionary<char, int>>();
            summa = new Dictionary<char, int>();
            foreach (char main_key in data.Keys) {
                summa[main_key] = 0;
                np[main_key] = new Dictionary<char, int>();
                foreach (char key in data[main_key].Keys) {
                    summa[main_key] += data[main_key][key];
                    np[main_key][key] = summa[main_key];
                }
            }
        }
        public char getSym(char c_in) {
            int m = random.Next(0, summa[c_in]);
            char c_out = ' ';
            foreach (char key in data[c_in].Keys) {
                if (m < np[c_in][key]) {
                    c_out = key;
                    break;
                }
            }
            return c_out;
        }
        public int getSize() {
            return size;
        }
        public bool isBinCharInData(char c) {
            return data.ContainsKey(c);
        }
    }

    public class WordsGen {  
        private Dictionary<string, int> data;
        private int size;
        private int summa;
        private int[] np;
        private Random random = new Random();

        public WordsGen() {
            string[] splitline;
            data = new Dictionary<string, int>();
            foreach(string line in File.ReadLines("words.csv")) {
                splitline = line.Split(';');
                data.Add(splitline[1], Convert.ToInt32(splitline[2]));
            }
            size = data.Count;
            summa = 0;
            np = new int[size];
            int i = 0;
            foreach (string key in data.Keys) {
                summa+=data[key];
                np[i] = summa;
                i++;
            }
        }
        public string getWord() {
            int m = random.Next(0, summa);
            int j = 0;
            string answkey = "";
            foreach (string key in data.Keys) {
                if (m < np[j]) {
                    answkey = key;
                    break;
                }
                j++;
            }
            return answkey;
        }
        public int getSize(){
            return size;
        }
        public bool isWordInData(string w) {
            return data.ContainsKey(w);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            
            
            CharGenerator gen = new CharGenerator();
            BinaryCharGen bingen = new BinaryCharGen();
            WordsGen wgen = new WordsGen();
            StreamWriter writer1 = new StreamWriter("../out1.txt",false);
            for(int i = 1; i < 1001; i++) 
            {
                char ch = gen.getSym(); 
                writer1.Write(ch);
                if (i % 50 == 0) writer1.Write("\n");
            }
            writer1.Close();
            StreamWriter writer2 = new StreamWriter("../gen-1.txt",false);
            char prev_char = gen.getSym();
            for(int i = 1; i < 1001; i++) 
            {
                char c = bingen.getSym(prev_char);
                prev_char = c;
                writer2.Write(c);
                if (i % 50 == 0) writer2.Write("\n");
            }
            writer2.Close();
            StreamWriter writer3 = new StreamWriter("../gen-2.txt",false);
            for(int i = 1; i < 1001; i++) 
            {
                string s = wgen.getWord(); 
                writer3.Write(s + " ");
                if (i % 25 == 0) writer3.Write("\n");
            }
            writer3.Close();
            
        }
    }
}

