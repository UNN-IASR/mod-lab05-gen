using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using System.Buffers.Text;
using System.Data;

namespace generator
{
    class CharGenerator 
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя"; 
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
    }
    public class CharGenerator2 {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] alfavit;
        private string[,] data = new string[36,36];
        int[,]weights =  {
                    {2, 12, 35, 8, 14, 7, 6, 15, 7, 7, 19, 27, 19, 45, 5, 11, 26, 31, 27, 3, 1, 10, 6, 7, 10, 1, 0, 0, 2, 6, 9},
                    {5, 0, 0, 0, 0, 9, 1, 0, 6, 0, 0, 6, 0, 2, 21, 0, 8, 1, 0, 6, 0, 0, 0, 0, 0, 1, 11, 0, 0, 0, 2},
                    {35, 1, 5, 3, 3, 32, 0, 2, 17, 0, 7, 10, 3, 9, 58, 6, 6, 19, 6, 7, 0, 1, 1, 2, 4, 1, 18, 1, 2, 0, 3},
                    {7, 0, 0, 0, 3, 3, 0, 0, 5, 0, 1, 5, 0, 1, 50, 0, 7, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {25, 0, 3, 1, 1, 29, 1, 1, 13, 0, 1, 5, 1, 13, 22, 3, 6, 8, 1, 10, 0, 0, 1, 1, 1, 0, 5, 1, 0, 0, 1},
                    {2, 9, 18, 11, 27, 7, 5, 10, 6, 15, 13, 35, 24, 63, 7, 16, 39, 37, 33, 3, 1, 8, 3, 7, 3, 3, 0, 0, 1, 1, 2},
                    {5, 1, 0, 0, 6, 12, 0, 0, 5, 0, 0, 0, 0, 6, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {35, 1, 7, 1, 5, 3, 0, 0, 4, 0, 2, 1, 2, 9, 9, 1, 3, 1, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4},
                    {4, 6, 22, 5, 10, 21, 2, 23, 19, 11, 19, 21, 20, 32, 8, 13, 11, 29, 29, 3, 1, 17, 3, 11, 1, 1, 0, 0, 1, 3, 17},
                    {1, 1, 4, 1, 3, 0, 1, 2, 4, 0, 5, 1, 2, 7, 9, 7, 3, 10, 2, 0, 0, 0, 1, 3, 2, 0, 0, 0, 0, 0, 0},
                    {24, 1, 4, 1, 0, 4, 1, 1, 26, 0, 1, 4, 1, 2, 66, 2, 10, 3, 7, 10, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                    {25, 1, 1, 1, 1, 33, 2, 1, 36, 0, 1, 2, 1, 8, 30, 2, 0, 3, 1, 6, 0, 4, 0, 1, 0, 0, 3, 20,  0, 4, 9},
                    {18, 2, 4, 1, 1, 21, 1, 2, 23, 0, 3, 1, 3, 7, 19, 5, 2, 5, 3, 9, 1, 0, 0, 2, 0, 0, 5, 1, 1, 0, 3},
                    {54, 1, 2, 3, 3, 34, 0, 0, 58, 0, 3, 0, 1, 24, 67, 2, 1, 9, 9, 7, 1, 0, 5, 2, 0, 0, 36, 3, 0, 0, 5},
                    {1, 28, 84, 32, 47, 15, 7, 18, 12, 29, 19, 41, 38, 30, 9, 18, 43, 50, 39, 3, 2, 5, 2, 12, 4, 3, 0, 0, 2, 3, 2},
                    {7, 0, 0, 0, 0, 15, 0, 0, 4, 0, 0, 9, 0, 1, 46, 0, 41, 1, 0, 6, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2},
                    {55, 1, 4, 4, 3, 37, 3, 1, 24, 0, 3, 1, 3, 7, 56, 2, 1, 5, 9, 16, 0, 1, 1, 1, 2, 0, 8, 3, 0, 0, 5},
                    {8, 1, 7, 1, 2, 25, 0, 0, 6, 0, 40, 13, 3, 9, 27, 11, 4, 11, 82, 6, 0, 1, 1, 2, 2, 0, 1, 8, 0, 0, 17},
                    {35, 1, 27, 1, 3, 31, 0, 1, 28, 0, 5, 1, 1, 11, 56, 4, 26, 18, 2, 10, 0, 0, 0, 1, 0, 0, 11, 21, 0, 0, 4},
                    {1, 4, 4, 4, 11, 2, 6, 3, 2, 0, 8, 5, 5, 5, 1, 5, 7, 14, 7, 0, 0, 1, 0, 8, 3, 2, 0, 0, 0, 9, 1},
                    {2, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {4, 1, 4, 1, 3, 1, 0, 2, 3, 0, 4, 3, 3, 4, 18, 5, 3, 4, 2, 2, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                    {3, 0, 0, 0, 0, 7, 0, 0, 10, 0, 2, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
                    {12, 0, 0, 0, 0, 23, 0, 0, 13, 0, 2, 0, 0, 6, 0, 0, 0, 0, 7, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
                    {5, 0, 0, 0, 0, 11, 0, 0, 14, 0, 1, 2, 0, 2, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
                    {3, 0, 0, 0, 0, 8, 0, 0, 6, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 1, 9, 1, 3, 12, 0, 2, 4, 7, 3, 6, 6, 3, 2, 10, 3, 9, 4, 1, 0, 16, 0, 1, 2, 0, 0, 0, 0, 0, 0},
                    {0, 2, 4, 1, 1, 2, 0, 2, 2, 0, 6, 0, 3, 13, 2, 4, 1, 11, 3, 0, 0, 0, 0, 1, 4, 0, 0, 0, 1, 3, 1},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 2, 1, 2, 1, 0, 0, 3, 1, 0, 1, 0, 1, 1, 1, 3, 1, 1, 7, 0, 0, 0, 1, 1, 0, 4, 0, 0, 0, 0, 0},
                    {1, 3, 9, 1, 3, 3, 1, 5, 3, 2, 3, 3, 4, 6, 3, 6, 3, 6, 10, 0, 0, 2, 1, 4, 1, 1, 0, 0, 1, 1, 1}
                };
        private int size;
        private Random random = new Random();
        public CharGenerator2() 
        {
           size = syms.Length;
           alfavit = syms.ToCharArray();
           string twoSybols;
           for(int i = 0; i < 30; i++){
            for(int j = 0; j < 30; j++){
                twoSybols=alfavit[i].ToString()+alfavit[j].ToString(); 
                data[i,j] = twoSybols;
                }
            }
            SumWeight();
        }
        int sumWeight;
        public int SumWeight(){
            sumWeight=0;
            for(int k=0; k < 30; k++){
                for (int l=0; l < 30;l++)
                {
                   sumWeight+=weights[l,k];
                }
            } 
            return sumWeight;
        }
        public int[] Rule(int num){
            int i=0,j=0;
            int sum=weights[0,0];
            while(sum<num){
                j++;
                if(j>=29) {i++;j=0;}
                sum+=weights[i,j];
            } 
            return[i,j];
        }   
        public string getSym() 
        {
            int num=random.Next(0, sumWeight);
            int[] index=Rule(num);
            return data[index[0],index[1]]; 
        }

    }
    
    public class CharGenerator3 {
        private string[] data = new string[100];
        string[] baseWords = new string[100]
            {
                "и", "в", "не", "на", "с", "что", "я", "а", "он", "как", "к", "по", "но", "его",
                "это", "из", "все", "у", "за", "от", "то", "о", "же", "так", "для", "было", "она",
                "только", "мы", "бы", "мне", "был", "ее", "или", "еще", "меня", "их", "они", "до",
                "когда", "уже", "ты", "если", "да", "вы", "вот", "при", "ни", "ему", "чтобы", "нет",
                "есть", "даже", "может", "быть", "во", "время", "очень", "были", "была", "сказал",
                "ли", "под", "со", "себя", "нас", "где", "него", "чем", "того", "без", "будет",
                "этого", "теперь", "после", "там", "можно", "этом", "раз", "себе", "тем", "этот",
                "ну", "том", "потом", "более", "них", "которые", "всех", "человек", "ничего", "надо",
                "тут", "тогда", "здесь", "потому", "один", "кто", "через", "который"
            };
        int[] weights = new int[100]
        {
            7416, 5842, 3385, 2936, 2228, 2210, 1592, 1541, 1377, 1300, 1132, 1071, 1048, 983,
            957, 836, 817, 798, 754, 747, 695, 685, 665, 663, 600, 592, 553, 516, 501, 485, 449,
            442, 438, 434, 432, 422, 415, 412, 400, 390, 385, 348, 347, 338, 338, 310, 305, 305,
            302, 286, 269, 267, 264, 263, 262, 259, 255, 252, 249, 246, 233, 231, 228, 222, 220,
            218, 216, 216, 213, 209, 205, 204, 202, 201, 195, 192, 189, 189, 184, 180, 177, 176,
            175, 174, 173, 170, 168, 167, 167, 166, 163, 162, 160, 159, 158, 157, 157, 156, 153, 151
        };
        private int size;
        private Random random = new Random();
        public CharGenerator3() 
        {
           size = baseWords.Length;
           for(int i = 0; i < size; i++){
                data[i] = baseWords[i];
            }
            SumWeight();
        }
        int sumWeight;
        public int SumWeight(){
            sumWeight=0;
            for (int l=0; l < size;l++)
            {
                sumWeight+=weights[l];
            }            
            return sumWeight;
        }

        public int Rule(int num){
            int j=0;
            int sum=weights[0];
            while(sum<num){
                j++;
                sum+=weights[j];
            } 
            return j;
        }   
        public string getSym() 
        {
            int num=random.Next(0, sumWeight);
            int index=Rule(num);
            return data[index]; 
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for(int i = 0; i < 1000; i++) 
            {
               char ch = gen.getSym(); 
               if (stat.ContainsKey(ch))
                  stat[ch]++;
               else
                  stat.Add(ch, 1); Console.Write(ch);
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat) 
            {
                 Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            }


            CharGenerator2 gen2 = new CharGenerator2();
            string fileName = "gen-1.txt";
            using (StreamWriter sw2 = new StreamWriter(fileName))
            {
                for(int j = 0; j < 20; j++) {
                    for(int i = 0; i < 50; i++) 
                    {
                        string ch = gen2.getSym();
                        sw2.Write(ch + " ");   
                    }
                    sw2.WriteLine();
                }
            }
            
            CharGenerator3 gen3 = new CharGenerator3();
            fileName = "gen-2.txt";
            using (StreamWriter sw2 = new StreamWriter(fileName))
            {
                for(int j = 0; j < 20; j++) {
                    for(int i = 0; i < 50; i++) 
                    {
                        string ch = gen3.getSym();
                        sw2.Write(ch + " ");   
                    }
                    sw2.WriteLine();
                }
            }

           
        }
    }
}

