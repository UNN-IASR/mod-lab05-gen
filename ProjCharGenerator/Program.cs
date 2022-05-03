using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace generator
{
    class Gen1
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public int[,] arr;
        int[,] np; 
        int summa = 0;
        public Gen1(int[,] ar)
        {
            arr = ar;
            size = syms.Length;
            data = syms.ToCharArray(); 
            for (int i = 0; i < size; i++) 
                for (int j = 0; j < size; j++)
                    summa += arr[i,j];
            np = new int[size, size];
            int s2 = 0;
            for (int i = 0; i < size; i++) 
            {
                for (int j = 0; j < size; j++)
                {
                    s2 += arr[i, j];
                    np[i, j] = s2;
                }
            }
        }
        public string getSym()
        {
            int m = random.Next(0, summa); 
            int j = 0;
            int i = 0;
            for (i = 0; i < size; i++)
            {
                int F = 0;
                for (j = 0; j < size; j++)
                {
                    if (m < np[i, j])
                    {
                        F = 1;
                        break;
                    }
                }
                if (F == 1) break;
            }
            return data[i].ToString() + data[j].ToString();
        }
    }
    class Gen2
    {
        private string[] data;
        private int size;
        private Random random = new Random();
        int[] np;
        int summa = 0;
        public Gen2(string[] arr)
        {
            data = arr;
            size = 100;
            np = new int[size];
            for (int i = 0; i < size; i++)
            {
                summa += i;
                np[i] = summa;
            }
        }
        public string getSym()
        {
            int m = random.Next(0, summa);
            int i = 0;
            for (i = 0; i < 100; i++) if (m < np[i]) break;
            return data[i];
        }
    }
    class Gen3
    {
        private string[] data;
        private int size;
        private Random random = new Random();
        int[] np;
        int summa = 0;
        public Gen3(string[] arr)
        {
            data = arr;
            size = 100;
            np = new int[size];
            for (int i = 0; i < size; i++)
            {
                summa += i;
                np[i] = summa;
            }
        }
        public string getSym()
        {
            int m = random.Next(0, summa);
            int i = 0;
            for (i = 0; i < 100; i++) if (m < np[i]) break;
            return data[i];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[31, 31];
            using (StreamReader r = new StreamReader("test1.txt"))
            {
                for (int i = 0; i < 16; i++)
                {
                    string test = r.ReadLine();
                    string[] temp = test.Split(new Char[] { ' ' });
                    int j = 0;
                    foreach (string item in temp)
                    {
                        arr[i,j] = int.Parse(item);
                        j++;
                    }
                }
            }
            using (StreamReader r = new StreamReader("test2.txt"))
            {
                for (int i = 0; i < 16; i++)
                {
                    string test = r.ReadLine();
                    string[] temp = test.Split(new Char[] { ' ' });
                    int j = 0;
                    foreach (string item in temp)
                    {
                        arr[i, j + 16] = int.Parse(item);
                        j++;
                    }
                }
            }
            using (StreamReader r = new StreamReader("test3.txt"))
            {
                for (int i = 0; i < 15; i++)
                {
                    string test = r.ReadLine();
                    string[] temp = test.Split(new Char[] { ' ' });
                    int j = 0;
                    foreach (string item in temp)
                    {
                        arr[i + 16, j] = int.Parse(item);
                        j++;
                    }
                }
            }
            using (StreamReader r = new StreamReader("test4.txt"))
            {
                for (int i = 0; i < 15; i++)
                {
                    string test = r.ReadLine();
                    string[] temp = test.Split(new Char[] { ' ' });
                    int j = 0;
                    foreach (string item in temp)
                    {
                        arr[i + 16, j + 16] = int.Parse(item);
                        j++;
                    }
                }
            }
            Gen1 gen = new Gen1(arr);
            string[] arr_str = new string[100];
            using (StreamReader r = new StreamReader("word.txt", Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < 100; i++)
                    arr_str[i] = r.ReadLine();
            }
            Gen2 gen2 = new Gen2(arr_str);
            using (StreamReader r = new StreamReader("double_words.txt", Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < 100; i++)
                    arr_str[i] = r.ReadLine();
            }
            Gen3 gen3 = new Gen3(arr_str);
            using (StreamWriter r = new StreamWriter("answer1.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = gen.getSym();
                    r.Write(str[0]);
                    r.Write(str[1]);
                }
            }
            using (StreamWriter r = new StreamWriter("answer2.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = gen2.getSym();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                    r.Write(' ');
                }
            }
            using (StreamWriter r = new StreamWriter("answer3.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = gen3.getSym();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                    r.Write(' ');
                }
            }
            Console.ReadKey();
        }
    }
}
