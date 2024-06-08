using System;
using System.IO;

namespace Lab5
{
    public class genBgramm
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public int[,] array;
        public int[,] bagOfWords;
        int sum = 0;
        public genBgramm(int[,] array1)
        {
            array = array1;
            size = syms.Length;
            data = syms.ToCharArray();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    sum += array[i, j];
            bagOfWords = new int[size, size];
            int sum2 = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sum2 += array[i, j];
                    bagOfWords[i, j] = sum2;
                }
            }
        }
        public string getSym()
        {
            int r = random.Next(0, sum);
            int j = 0, i = 0;
            for (i = 0; i < size; i++)
            {
                bool check = false;
                for (j = 0; j < size; j++)
                {
                    if (r < bagOfWords[i, j])
                    {
                        check = true;
                        break;
                    }
                }
                if (check) break;
            }
            return data[i].ToString() + data[j].ToString();
        }
    }
    public class genWord
    {
        private string[] data;
        private int size;
        private Random random = new Random();
        public int[] bagOfWords;
        int sum = 0;
        public genWord(string[] array)
        {
            data = array;
            size = 100;
            bagOfWords = new int[size];
            for (int i = 0; i < size; i++)
            {
                sum += i;
                bagOfWords[i] = sum;
            }
        }
        public string getSym()
        {
            int r = random.Next(0, sum);
            int i = 0;
            for (i = 0; i < 100; i++) if (r < bagOfWords[i]) break;
            return data[i];
        }
    }
    public class genPairOfWords
    {
        private string[] data;
        private int size;
        private Random random = new Random();
        public int[] bagOfWords;
        int sum = 0;
        public genPairOfWords(string[] array)
        {
            data = array;
            size = 100;
            bagOfWords = new int[size];
            for (int i = 0; i < size; i++)
            {
                sum += i;
                bagOfWords[i] = sum;
            }
        }
        public string getSym()
        {
            int r = random.Next(0, sum);
            int i = 0;
            for (i = 0; i < 100; i++) if (r < bagOfWords[i]) break;
            return data[i];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[31, 31];
            using (StreamReader r = new StreamReader("bgramm.txt"))
            {
                for (int i = 0; i < 31; i++)
                {
                    string test = r.ReadLine();
                    string[] temp = test.Split(new Char[] { ' ' });
                    int j = 0;
                    foreach (string item in temp)
                    {
                        array[i, j] = int.Parse(item);
                        j++;
                    }
                }
            }
            genBgramm genB = new genBgramm(array);
            string[] array_str = new string[100];
            using (StreamReader r = new StreamReader("words.txt"))
            {
                for (int i = 0; i < 100; i++)
                    array_str[i] = r.ReadLine();
            }
            genWord genW = new genWord(array_str);
            using (StreamReader r = new StreamReader("pairs.txt"))
            {
                for (int i = 0; i < 100; i++)
                    array_str[i] = r.ReadLine();
            }
            genPairOfWords genP = new genPairOfWords(array_str);

            using (StreamWriter r = new StreamWriter("answer1.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = genB.getSym();
                    r.Write(str[0]);
                    r.Write(str[1]);
                }
            }
            using (StreamWriter r = new StreamWriter("answer2.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = genW.getSym();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                    r.Write(' ');
                }
            }
            using (StreamWriter r = new StreamWriter("answer3.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = genP.getSym();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                    r.Write(' ');
                }
            }
        }
    }
}
