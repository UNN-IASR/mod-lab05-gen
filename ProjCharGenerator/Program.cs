using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace generator
{
    class zadanie1
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public int[,] arr;
        int[,] np;
        int summa = 0;
        public zadanie1(int[,] ar)
        {
            arr = ar;
            size = syms.Length;
            data = syms.ToCharArray();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    summa += arr[i, j];
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
        public string Sym()
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
    class zadanie2
    {
        private string[] data;
        private int size;
        private Random random = new Random();
        int[] np;
        int summa = 0;
        public zadanie2(string[] arr)
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
        public string Sym()
        {
            int m = random.Next(0, summa);
            int i = 0;
            for (i = 0; i < 100; i++) if (m < np[i]) break;
            return data[i];
        }
    }
    class zadanie3
    {
        private string[] data;
        private int size;
        private Random random = new Random();
        int[] np;
        int summa = 0;
        public zadanie3(string[] arr)
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
        public string Sym()
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
            using (StreamReader r = new StreamReader("t1.txt"))
            {
                for (int i = 0; i < 16; i++)
                {
                    string test = r.ReadLine();
                    string[] temp = test.Split(new Char[] { ' ' });
                    int j = 0;
                    foreach (string item in temp)
                    {
                        arr[i, j] = int.Parse(item);
                        j++;
                    }
                }
            }
            using (StreamReader r = new StreamReader("t2.txt"))
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
            using (StreamReader r = new StreamReader("t3.txt"))
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
            using (StreamReader r = new StreamReader("t4.txt"))
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
            zadanie1 zad = new zadanie1(arr);
            string[] arr_str = new string[100];
            using (StreamReader r = new StreamReader("w.txt", Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < 100; i++)
                    arr_str[i] = r.ReadLine();
            }
            zadanie2 zad2 = new zadanie2(arr_str);
            using (StreamReader r = new StreamReader("two_w.txt", Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < 100; i++)
                    arr_str[i] = r.ReadLine();
            }
            zadanie3 zad3 = new zadanie3(arr_str);
            using (StreamWriter r = new StreamWriter("ans1.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = zad.Sym();
                    r.Write(str[0]);
                    r.Write(str[1]);
                }
            }
            using (StreamWriter r = new StreamWriter("ans2.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = zad2.Sym();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                    r.Write(' ');
                }
            }
            using (StreamWriter r = new StreamWriter("ans3.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = zad3.Sym();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                    r.Write(' ');
                }
            }
            Console.ReadKey();
        }
    }
}
