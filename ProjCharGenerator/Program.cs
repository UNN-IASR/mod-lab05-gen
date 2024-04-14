using System;
using System.Collections.Generic;

namespace generator
{
    class CharGenerator 
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
    }
    class GeneratorTexta1
    {
        public  int[,] weroyatnosti =
        {
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
        public int kol_v_stroke()
        {
            return weroyatnosti.GetLength(0);
        }
        public string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя";
        public char symbol;
        public int nomersymb;
        public char firstsymbol(int nomersymb)
        {
            symbol = syms[nomersymb];
            return symbol;
        }
        public int summa_veroyatnosti(int nomersymb)
        {
            int summa_veroyatnosti = 0;
            for (int i = 0; i < kol_v_stroke(); i++)
            {
                summa_veroyatnosti += weroyatnosti[nomersymb, i];
            }
            return summa_veroyatnosti;
        }
        public char secondsymbol(int nomersymb)
        {
            char s;
            int summa_ver = summa_veroyatnosti(nomersymb);
            Random random = new Random();
            int razmer = kol_v_stroke();
            int r = random.Next(0,summa_ver);
            for (int i = 0; i < kol_v_stroke(); i++)
            {
                if (r < weroyatnosti[nomersymb, i])
                {
                    s = syms[i];
                    return s;
                }
                if (r == weroyatnosti[nomersymb,i])
                {
                    s = ' ';
                    return s;
                }
                r -=weroyatnosti[nomersymb,i];
            }
            return ' ';
        }
        public string text(int dlina)
        {
            Random random = new Random();
            nomersymb = random.Next(0, syms.Length);
            char first = firstsymbol(nomersymb);
            string text = first.ToString();
            for (int i = 1;i<dlina;i++)
            {
                char second = secondsymbol(nomersymb);
                text += second.ToString();
                char[] syms2 = syms.ToCharArray();
                for (int j = 0;j<syms.Length;j++)
                {
                    if (second == syms2[j])
                    {
                        nomersymb = j;
                    }
                }
            }
            return text;
        }
    }
    class GeneratorTexta2
    {
        public string[] words = 
        {
            "и","в","не","на","я","он","быть","что","с","а","как","то","она","к","этот",
            "это","по","но","они","мы","свой","который","из","весь","у","за","от","все",
            "о","так","же","вы","для","мочь","ты","год","один","его","тот","человек",
            "только","такой","бы","себя","сказать","еще","мой","или","говорить","до",
            "время","уже","когда","другой","наш","да","если","знать","вот","сам","ни",
            "день","дело","при","стать","чтобы","самый","жизнь","очень","нет","во",
            "даже","два","рука","ее","первый","ли","под","со","кто","где","новый",
            "слово","какой","раз","теперь","их","идти","без","после","иметь","там",
            "ничто","должен","большой","видеть","место","хотеть","можно","глаз"
        };
        public int[] weroyatnosti_slov =
        {
            14345348, 11335734, 6545609, 5737426, 4998377, 4947719, 4843591, 4675069, 4253772, 2815475, 2505731,
            2261069, 2227685, 2185239, 2109612, 2097072, 2089119, 2062425, 1915969, 1772879, 1718580, 1703197, 
            1669273, 1616065, 1572078, 1487183, 1467970, 1368273, 1361776, 1357693, 1297018, 1163388, 1150019, 
            1139491, 1118783, 1111801, 1110290, 1103656, 1096373, 1084431, 1004688, 962928, 948112, 935991, 
            920200, 899685, 817174, 807411, 801050, 794052, 768251, 757837, 756600, 753279, 717777, 654661, 
            647885, 644576, 618116, 618081, 596498, 585302, 583032,563150, 557706, 556761, 551223, 531854,
            525880, 525422, 518561,514289, 510161, 491628, 485912, 477689, 454761, 440182, 439392,437200, 
            435603, 431285, 427548, 425011, 418547, 403544, 402082, 402002, 399192, 395383, 394195, 389633, 
            388024, 377820, 376185, 374580, 370104, 369179, 361755, 358913
        };
        public int sum()
        {
            int razmer1 = weroyatnosti_slov.Length;
            int sumver = 0;
            for (int i = 0; i < razmer1; i++)
            {
                sumver += weroyatnosti_slov[i];
            }
            return sumver;
        }
        public string randomword()
        {
            string s;
            Random random = new Random();
            int sumver = sum();
            int r1 = random.Next(sumver);
            for (int i=0;i< weroyatnosti_slov.Length; i++)
            {
                if(r1<weroyatnosti_slov[i])
                {
                    s = words[i];
                    return s;
                }
                r1-= weroyatnosti_slov[i];
            }
            return ",";
        }
        public string wordtext(int len)
        {
            string a = "";
            for (int i=0; i < len; i++)
            {
                a += randomword()+" ";
            }
            return a;
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
            GeneratorTexta1 generator = new GeneratorTexta1();
            GeneratorTexta2 generator2 = new GeneratorTexta2();
            using (StreamWriter writer = new StreamWriter("C:\\Users\\ASUS\\OneDrive\\Рабочий стол\\gen1.txt"))
            {
                writer.Write(generator.text(1000));
            }
            using (StreamWriter writer1 = new StreamWriter("C:\\Users\\ASUS\\OneDrive\\Рабочий стол\\gen2.txt"))
            {
                writer1.Write(generator2.wordtext(1000));
            }
        }
    }
}

