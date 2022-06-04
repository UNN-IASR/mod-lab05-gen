using System;
using System.Linq;
using System.Text;
using System.IO;

namespace generator
{
    public class BigrammGenerator
    {
        public string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        public int[,] bigramm;
        private int size;
        private int[] max_bigramm;
        public BigrammGenerator(string file)
        {
            size = syms.Length;
            bigramm = new int[size, size];
            max_bigramm = new int[size];
            using (StreamReader f = new StreamReader(file))
            {
                for (int i = 0; i < size - 1; i++)
                {
                    string text = f.ReadLine();
                    string[] lines = text.Split(new char[] { ' ' });
                    for (int j = 0; j < size - 1; j++)
                    {
                        bigramm[i, j] = Int32.Parse(lines[j]);
                    }
                }
            }
            for (int i = 0; i < size - 1; i++)
                for (int j = 0; j < size - 1; j++)
                    if (max_bigramm[i] < bigramm[i, j])
                        max_bigramm[i] = bigramm[i, j];
        }
        public char getsym(char s)
        {
            Random random = new Random();
            if (s == '1')
                s = syms[random.Next(0, size)];
            int i = syms.IndexOf(s);
            int j = 0;
            int r = random.Next(0, max_bigramm[i]);
            while (true)
            {
                j = random.Next(0, size);
                if (r < bigramm[i, j])
                    break;
            }
            return syms[j];
        }
    }
    public class WordsGenerator
    {
        public string[] words;
        public int[] odd;
        private int maxodd;
        private int size = 100;
        public WordsGenerator(string file)
        {
            odd = new int[size];
            words = new string[size];
            using (StreamReader f = new StreamReader(file))
            {
                for (int i = 0; i < size; i++)
                {
                    string text = f.ReadLine();
                    string[] line = text.Split(new Char[] { ' ' });
                    words[i] = line[0];
                    odd[i] = Int32.Parse(line[1]);
                }
                maxodd = odd[0];
            }
        }
        public string getword()
        {
            Random random = new Random();
            int r = random.Next(0, maxodd);
            int i;
            while (true)
            {
                i = random.Next(0, size);
                if (r < odd[i])
                    break;
            }
            return words[i];
        }
    }
    public class BiWordsGenerator
    {
        public string[,] words;
        public int[] odd;
        private int maxodd;
        private int size = 100;
        public BiWordsGenerator(string file)
        {
            words = new string[size, 2];
            odd = new int[size];

            using (StreamReader f = new StreamReader(file))
            {
                for (int i = 0; i < size; i++)
                {
                    string text = f.ReadLine();
                    string[] line = text.Split(new Char[] { ' ' });
                    words[i, 0] = line[0];
                    words[i, 1] = line[1];
                    odd[i] = Int32.Parse(line[2]);
                }
                maxodd = odd[0];
            }
        }
        public string getbiwors()
        {
            Random random = new Random();
            int r = random.Next(0, maxodd);
            int i;
            while (true)
            {
                i = random.Next(0, size);
                if (r < odd[i])
                    break;
            }
            return (words[i, 0] + " " + words[i, 1]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char str = '1';
            string word;
            string biword;
            int size = 1000;

            BigrammGenerator g1 = new BigrammGenerator("bigramms.txt");
            WordsGenerator g2 = new WordsGenerator("words.txt");
            BiWordsGenerator g3 = new BiWordsGenerator("comb_words.txt");

            using (StreamWriter w = new StreamWriter("text-1.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    str = g1.getsym(str);
                    w.Write(str);
                    w.Write(" ");
                }
            }
            using (StreamWriter w = new StreamWriter("text-2.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    word = g2.getword();
                    for (int j = 0; j < word.Length; j++)
                        w.Write(word[j]);
                    w.Write(' ');
                }
            }

            using (StreamWriter w = new StreamWriter("text-3.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    biword = g3.getbiwors();
                    for (int j = 0; j < biword.Length; j++)
                        w.Write(biword[j]);
                    w.Write(' ');
                }
            }
        }
    }
}