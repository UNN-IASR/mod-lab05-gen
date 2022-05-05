using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace generator
{
    
    public class HalfWordgen
    {
        public string[] words;
        public int[] raw;
        private int Mraw;
        public HalfWordgen(string file)
        {
            raw = new int[100];
            words = new string[100];
            using (StreamReader f = new StreamReader(file))
            {
                for (int i = 0; i < 100; i++)
                {
                    string text = f.ReadLine();
                    string[] s = text.Split(new Char[] { ' ' });
                    words[i] = s[0];
                    raw[i] = Int32.Parse(s[1]);
                }
                Mraw = raw[0];
            }
        }
        public string Word()
        {
            Random rn = new Random();
            int r = rn.Next(0, Mraw);
            int i;
            while (true)
            {
                i = rn.Next(0, 100);
                if (r < raw[i])
                    break;
            }
            return words[i];
        }
    }
    public class TwoWordgen
    {
        public string[,] words;
        public int[] raw;
        private int Mraw;
        public TwoWordgen(string file)
        {
            words = new string[100, 2];
            raw = new int[100];

            using (StreamReader f = new StreamReader(file))
            {
                for (int i = 0; i < 100; i++)
                {
                    string text = f.ReadLine();
                    string[] s = text.Split(new Char[] { ' ' });
                    words[i, 0] = s[0];
                    words[i, 1] = s[1];
                    raw[i] = Int32.Parse(s[2]);
                }
                Mraw = raw[0];
            }
        }
        public string TwoWords()
        {
            Random rn = new Random();
            int r = rn.Next(0, Mraw);
            int i;
            while (true)
            {
                i = rn.Next(0, 100);
                if (r < raw[i])
                    break;
            }
            return (words[i, 0] + " " + words[i, 1]);
        }
    }

    public class BGgen
    {
        public int[,] bg;
            private int[] maxbg = new int[31];
            public string alp = "абвгдежзийклмнопрстуфхцчшщьыэюя";
            
            public BGgen(string file)
            {
                bg = new int[31, 31];
                using (StreamReader f = new StreamReader(file))
                {
                    for (int i = 0; i < 30; i++)
                    {
                        string text = f.ReadLine();
                        string[] s = text.Split(new char[] { ' ' });
                        for (int j = 0; j < 30; j++)
                        {
                            bg[i, j] = Int32.Parse(s[j]);
                        }
                    }
                }
                for (int i = 0; i < 30; i++)
                    for (int j = 0; j < 30; j++)
                        if (maxbg[i] < bg[i, j])
                            maxbg[i] = bg[i, j];
            }
            
        public char Sym(char s)
        {
                Random rn = new Random();
                if (s == '1')
                    s = alp[rn.Next(0, 31)];
                int i = alp.IndexOf(s);
                int j;
                int r = rn.Next(0, maxbg[i]);
                while (true)
                {
                    j = rn.Next(0, 31);
                    if (r < bg[i, j])
                        break;
                }
                return alp[j];
        }
    }
        
        class Program
        {
            static void Main(string[] args)
            {
                    Random rn = new Random();
                int N=1000;
                char str = '1';
                string W;
                string HW;

            BGgen g1 = new BGgen("D:\\CharGenerator\\result\\f.txt");
            HalfWordgen g2 = new HalfWordgen("D:\\CharGenerator\\result\\s.txt");
            TwoWordgen g3 = new TwoWordgen("D:\\CharGenerator\\result\\t.txt");

                using (StreamWriter w = new StreamWriter("D:\\CharGenerator\\GEN.TEST\\1.txt"))
                {
                    

                    for (int i = 0; i < N; i++)
                    {
                        str = g1.Sym(str);
                        w.Write(str);
                        w.Write(" ");
                    }
                }

                using (StreamWriter w = new StreamWriter("D:\\CharGenerator\\GEN.TEST\\2.txt"))
                {
                
                    for (int i = 0; i< N; i++)
                    {
                        W = g2.Word();
                        for (int j = 0; j<W.Length; j++)
                        w.Write(W[j]);
                        w.Write(' ');
                    }
                }

                using (StreamWriter w = new StreamWriter("D:\\CharGenerator\\GEN.TEST\\3.txt"))
                {
                    for (int i = 0; i < N; i++)
                    {
                        HW = g3.TwoWords();
                        for (int j = 0; j < HW.Length; j++)
                        w.Write(HW[j]);
                        w.Write(' ');
                    }
                }

            }
        }


} 