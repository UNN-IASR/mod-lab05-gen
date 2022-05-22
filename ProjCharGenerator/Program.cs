using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace generator
{
    class Zadanie_1
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private Random random = new Random();
        private int[,] arr; 
        int summa = 0;
        public Zadanie_1(string file)
        {
            arr = new int[31, 31];
            using (StreamReader r = new StreamReader(file))
            {
                for (int i = 0; i < 30; i++)
                {
                    string test = r.ReadLine();
                    string[] temp = test.Split(new Char[] { ' ' });
                    for (int j = 0; j < 30; j++)
                    {
                        arr[i, j] = Int32.Parse(temp[j]);
                    }
                }
            }
            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 30; j++)
                    summa += arr[i, j];
        }
        public string get_str()
        {
            int m = random.Next(0, summa);
            int j = 0;
            int i = 0;

            for (i = 0; i < 30; i++)
            {
                int F = 0;
                for (j = 0; j < 30; j++)
                {
                    if (m < arr[i, j])
                    {
                        F = 1;
                        break;
                    }
                }
                if (F == 1) break;
            }
            return syms[i].ToString() + syms[j].ToString();
        }
    }
    class Zadanie_2
    {
        private Random random = new Random();
        int summa = 0;
        public int[] ver;
        public string[] words;
        public int sum;
        public Zadanie_2(string file)
        {
            sum = 0;
            ver = new int[100];
            words = new string[100];
            using (StreamReader sr = new StreamReader(file))
            {
                for (int i = 0; i < 100; i++)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { ' ' });
                    words[i] = temp[0];
                    ver[i] = Int32.Parse(temp[1]);
                    sum += ver[i];
                }
            }
        }
            public string get_str()
        {
            int m = random.Next(0, summa);
            int i = 0;
            for (i = 0; i < 100; i++) 
                if (m < ver[i])
                    break;
            return words[i];
        }
    }
    class Zadanie_3
    {
        private Random random = new Random();
        int summa = 0;
        public int[] ver;
        public string[] words;
        public int sum;
        public Zadanie_3(string file)
        {
            sum = 0;
            ver = new int[100];
            words = new string[100];
            using (StreamReader sr = new StreamReader(file))
            {
                for (int i = 0; i < 100; i++)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { ' ' });
                    words[i] = temp[0];
                    summa += i;
                    ver[i] = summa;
                }
            }
        }
        public string get_str()
        {
            int m = random.Next(0, summa);
            int i = 0;
            for (i = 0; i < 100; i++)
                    if (m < ver[i])
                        break;
            return words[i];
        }
    }
    class Program
    {   
        static void Main(string[] args)
        {
            Zadanie_1 z1 = new Zadanie_1("task_1.txt");
            Zadanie_2 z2 = new Zadanie_2("task_2.txt");
            Zadanie_3 z3 = new Zadanie_3("task_3.txt");
            Zadanie_1 zad_1 = new Zadanie_1(arr);
            Zadanie_2 zad_2 = new Zadanie_2(arr_str);
            Zadanie_3 zad_3 = new Zadanie_3(arr_str);
            string[] arr_str = new string[100];
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

            using (StreamReader r = new StreamReader("word.txt", Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < 100; i++)
                    arr_str[i] = r.ReadLine();
            }
            using (StreamReader r = new StreamReader("double_words.txt", Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < 100; i++)
                    arr_str[i] = r.ReadLine();
            }
            using (StreamWriter r = new StreamWriter("otv_1.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = z1.get_str();
                    r.Write(str[0]);
                    r.Write(str[1]);
                    r.Write(" ");
                }
            }
            using (StreamWriter r = new StreamWriter("otv_2.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = z2.get_str();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                        r.Write(' ');
                }
            }
            using (StreamWriter r = new StreamWriter("otv_3.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = z3.get_str();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                        r.Write(' ');
                }
            }
           
            Console.ReadKey();
        }
    }
}
}
}
