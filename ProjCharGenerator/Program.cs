using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjCharGenerator
{
    public class DoubleCharGenerator
    {
    private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
    private char[] data;
    private int index = -1;
    private int size;
    private string[] wordnumber;
    private Random random = new Random();
    int[,] weights = new int[,] {{ 2, 12, 35, 8, 14, 7, 0, 6, 15, 7, 7, 19, 27, 19, 45, 5, 11, 26, 31, 27, 3, 1, 10, 6, 7, 10, 1, 0, 0, 0, 2, 6, 9 },
                                     { 5, 0, 0, 0, 0, 9, 0, 1, 0, 6, 0, 0, 6, 0, 2, 21, 0, 8, 1, 0, 6, 0, 0, 0, 0, 0, 1, 0, 11, 0, 0, 0, 2 },
                                     { 35, 1, 5, 3, 3, 32, 0, 0, 2, 17, 0, 7, 10, 3, 9, 58, 6, 6, 19, 6, 7, 0, 1, 1, 2, 4, 1, 0, 18, 1, 2, 0, 3 },
                                     { 7, 0, 0, 0, 3, 3, 0, 0, 5, 0, 1, 5, 0, 1, 50, 0, 7, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                     { 25, 0, 3, 1, 1, 29, 0, 1, 1, 13, 0, 1, 5, 1, 13, 22, 3, 6, 8, 1, 10, 0, 0, 1, 1, 1, 0, 0, 5, 1, 0, 0,1},
                                     { 2, 9, 18, 11, 27, 7, 0, 5, 10, 6, 15, 13, 35, 24, 63, 7, 16, 39, 37, 33, 3, 1, 8, 3, 7, 3, 3, 0, 0, 0, 1, 1, 2},
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 5, 1, 0, 0, 6, 12, 0, 0, 0, 5, 0, 0, 0, 0, 6, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                     { 35, 1, 7, 1, 5, 3, 0, 0, 0, 4, 0, 2, 1, 2, 9, 9, 1, 3, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4},
                                     { 4, 6, 22, 5, 10, 21, 0, 2, 23, 19, 11, 19, 21, 20, 32, 8, 13, 11, 29, 29, 3, 1, 17, 3, 11, 1, 1, 0, 0, 0, 1, 3, 17},
                                     { 1, 1, 4, 1, 3, 0, 0, 1, 2, 4, 0, 5, 1, 2, 7, 9, 7, 3, 10, 2, 0, 0, 0, 1, 3, 2, 0, 0, 0, 0, 0, 0, 0 },
                                     { 24, 1, 4, 1, 0, 4, 0, 1, 1, 26, 0, 1, 4, 1, 2, 66, 2, 10, 3, 7, 10, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                     { 25, 1, 1, 1, 1, 33, 0, 2, 1, 36, 0, 1, 2, 1, 8, 30, 2, 0, 3, 1, 6, 0, 4, 0, 1, 0, 0, 0, 3, 20, 0, 4, 9},
                                     { 18, 2, 4, 1, 1, 21, 0,  1, 2, 23, 0, 3, 1, 3, 7, 19, 5, 2, 5, 3, 9, 1, 0, 0, 2, 0, 0, 0, 5, 1, 1, 0, 3 },
                                     { 54, 1, 2, 3, 3, 34, 0, 0, 0, 58, 0, 3, 0, 1, 24, 67, 2, 1, 9, 9, 7, 1, 0, 5, 2, 0, 0, 0, 36, 3, 0, 0, 5},
                                     { 1, 28, 84, 32, 47, 15, 0, 7, 18, 12, 29, 19, 41, 38, 30, 9, 18, 43, 50, 39, 3, 2, 5, 2, 12, 4, 3, 0, 0, 0, 2, 3, 2 },
                                     { 7, 0, 0, 0, 0, 15, 0, 0, 0, 4, 0, 0, 9, 0, 1, 46, 0, 41, 1, 0, 6, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2},
                                     {  55, 1, 4, 4, 3, 37, 0,  3, 1, 24, 0, 3, 1, 3, 7, 56, 2, 1, 5, 9, 16, 0, 1, 1, 1, 2, 0, 0, 8, 3, 0, 0, 5},
                                     { 8, 1, 7, 1, 2, 25, 0, 0, 0, 6, 0, 40, 13, 3, 9, 27, 11, 4, 11, 82, 6, 0, 1, 1, 2, 2, 0, 0, 1, 8, 0, 0, 17},
                                     { 35, 1, 27, 1, 3, 31, 0, 0, 1, 28, 0, 5, 1, 1, 11, 56, 4, 26, 18, 2, 10, 0, 0, 0, 1, 0, 0, 0, 11, 21, 0, 0, 4},
                                     { 1, 4, 4, 4, 11, 2, 0,  6, 3, 2, 0, 8, 5, 5, 5, 1, 5, 7, 14, 7, 0, 0, 1, 0, 8, 3, 2, 0, 0, 0, 0, 9, 1},
                                     { 2, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                     { 4, 1, 4, 1, 3, 1, 0, 0, 2, 3, 0, 4, 3, 3, 4, 18, 5, 3, 4, 2, 2, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                                     { 3, 0, 0, 0, 0, 7, 0, 0, 0, 10, 0, 2, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                                     { 12, 0, 0, 0, 0, 23, 0, 0, 0, 13, 0, 2, 0, 0, 6, 0, 0, 0, 0, 7, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
                                     { 5, 0, 0, 0, 0, 11, 0, 0, 0, 14, 0, 1, 2, 0, 2, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
                                     { 3, 0, 0, 0, 0, 8, 0, 0, 0, 6, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 1, 9, 1, 3, 12, 0, 0, 2, 4, 7, 3, 6, 6, 3, 2, 10, 3, 9, 4, 1, 0, 16, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0 },
                                     { 0, 2, 4, 1, 1, 2, 0, 0, 2, 2, 0, 6, 0, 3, 13, 2, 4, 1, 11, 3, 0, 0, 0, 0, 1, 4, 0, 0, 0, 0, 1, 3, 1 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                     { 0, 2, 1, 2, 1, 0, 0, 0, 3, 1, 0, 1, 0, 1, 1, 1, 3, 1, 1, 7, 0, 0, 0, 1, 1, 0, 4, 0, 0, 0, 0, 0, 0},
                                     { 1, 3, 9, 1, 3, 3, 0, 1, 5, 3, 2, 3, 3, 4, 6, 3, 6, 3, 6, 10, 0, 0, 2, 1, 4, 1, 1, 0, 0, 0, 1, 1, 1 }};
    int[,] np;
    int[] summa;
    public DoubleCharGenerator()
    {
        summa = new int[size];
        data = syms.ToCharArray();
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            summa[i] += weights[i,j];
        np = new int[size,size];
        int s2 = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j< size; j++)
            {
                s2 += weights[i,j];
                np[i,j] = s2;
            }
        }
    }
    public async Task ReadTextFromFileAsync(string path)
        {
            string textall = "";
            // асинхронное чтение
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                textall = textall + text;
            }
            textall = textall.Replace("\r", "");
            textall = textall.Replace("\n", " ");
            wordnumber = textall.Split(' ');
            size = syms.Length;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    weights[i, j] = Int32.Parse(wordnumber[i*33 + j]);
            }
            summa = new int[size];
            data = syms.ToCharArray();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    summa[i] += weights[i, j];
            np = new int[size, size];
            int s2 = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    s2 += weights[i, j];
                    np[i, j] = s2;
                }
            }
        }
    public char getSym()
    {
        int m = 0;
        if (index == -1)
        {
        m = random.Next(0, summa[random.Next(0, syms.Length)]);
        index = 0;
        }
        else
        m = random.Next(0, summa[index]);
        int j;
        for (j = 0; j < size; j++)
        {
            if (m < np[index,j])
                break;
        }
        index = j;
        return data[j];
    }
    }
    public class WordGenerator {
        private string[] data = new string[] {"и", "в", "не", "на", "с", "что", "я", "а", "он", "как", "к", "по", "но", "его", "это", "из", "все",
                                              "у", "за", "от", "то", "о", "же", "так", "для", "было", "она", "только", "мы", "бы", "мне", "был",
                                              "ее", "или", "еще", "меня", "их", "они", "до", "когда", "уже", "ты", "если", "да", "вы", "вот", "при",
                                              "ни", "ему", "чтобы", "нет", "есть", "даже", "может", "быть", "во", "время", "очень", "были", "была",
                                              "сказал", "ли", "под", "со", "себя", "нас", "где", "него", "чем", "того", "без", "будет", "этого", "теперь",
                                              "после", "там", "можно", "этом", "раз", "себе", "тем", "этот", "ну", "том", "потом", "более", "них", "которые",
                                              "всех", "человек", "ничего", "надо", "тут", "тогда", "здесь", "потому", "один", "кто", "через", "который"};
        private Random random = new Random();
        int[] weights = new int[] { 7416716, 5842670, 3385161, 2936096, 2228350, 2210373, 1592127, 1541398, 1377314, 1300577,
                                    1132463, 1071698, 1048321, 983462, 957828, 836230, 817619, 798746, 754712, 747239, 695763,
                                    685187, 665139, 663853, 600197, 592525, 553635, 516518, 501250, 485709, 449883, 442198,
                                    438349, 434375, 432318, 422671, 415977, 412867, 400385, 390040, 385992, 348216, 347484,
                                    338405, 338350, 310419, 305370, 305025, 302129, 286114, 269615, 267554, 264014, 263199,
                                    262913, 259603, 255317, 252939, 249393, 246499, 233062, 231733, 228843, 222715, 220734,
                                    218046, 216726, 216511, 213262, 209534, 205150, 204581, 202868, 201329, 195907, 192639,
                                    189774, 189405, 184146, 180956, 177179, 176597, 175961, 174807, 173458, 170327, 168703,
                                    167945, 167764, 166587, 163311, 162849, 160363, 159227, 158961, 157741, 157644, 156987,
                                    153712, 151251 };
        int[] np;
        int summa = 0;
        public WordGenerator()
        {
            if (data.Length != weights.Length)
            {
                Console.WriteLine("Error");
                Environment.Exit(1);
            }
            for (int i = 0; i < data.Length; i++)
                summa += weights[i];
            np = new int[data.Length];
            int s2 = 0;
            for (int i = 0; i < data.Length; i++)
            {
                s2 += weights[i];
                np[i] = s2;
            }
        }
        public async Task ReadTextFromFileAsync(string path)
        {
            string textall = "";
            // асинхронное чтение
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                textall = textall + text;
            }
            textall = textall.Replace("\r", "");
            textall = textall.Replace("\n", " ");
            string[] wordnumber = new string[2];
            wordnumber = textall.Split(' ');
            for (int i = 0; i < data.Length; i++)
            {
                    weights[i] = Int32.Parse(wordnumber[i]);
            }
            summa = 0;
            for (int i = 0; i < data.Length; i++)
                summa += weights[i];
            np = new int[data.Length];
            int s2 = 0;
            for (int i = 0; i < data.Length; i++)
            {
                s2 += weights[i];
                np[i] = s2;
            }
        }
        public string getSym()
        {
            int m = random.Next(0, summa);
            int j;
            for (j = 0; j < data.Length; j++)
            {
                if (m < np[j])
                    break;
            }
            return data[j];
        }
    }
    public class DoubleWordGenerator
    {
        private string[] data = new string[] {"и не", "и в", "потому что", "я не", "у меня", "может быть", "то что", "что он", "не было", "в том",
                                              "у нас", "в этом", "у него", "что в", "не только", "том что", "что я", "и на", "ничего не", "так и",
                                              "и с", "он не", "и я", "о том", "и все", "но и", "с ним", "а в", "так как", "что это", "как бы",
                                              "все это", "как и", "да и", "вместе с", "не в", "то есть", "и что", "и он", "никогда не", "к нему",
                                              "не может", "если бы", "а я", "так что", "он был", "а не", "об этом", "и даже", "что не", "это не",
                                              "еще не", "но не", "и как", "не мог", "из них", "не знаю", "на него", "в нем", "а потом", "что же",
                                              "в то", "при этом", "уже не", "в его", "это было", "во время", "что она", "того что", "как будто", "то же",
                                              "но в", "как в", "ко мне", "так же", "а также", "и по", "что у", "у них", "и т", "и так", "и вот",
                                              "один из", "никто не", "в Москве", "и его", "у вас", "к тому", "не могу", "в конце", "что вы", "но я",
                                              "что они", "я и", "только в", "его в", "таким образом", "что и", "в России", "несмотря на"};
        private Random random = new Random();
        int[] weights = new int[] { 201352, 193983, 117401, 113767, 97102, 96065, 95251, 92743, 92729, 89842,
                                    86446, 84820, 82963, 80398, 80252, 77858, 75642, 74347, 71816, 71614,
                                    71079, 68787, 68653, 67202, 66971, 66247, 65937, 60045, 58376, 57962,
                                    56860, 52951, 50613, 50243, 49521, 49285, 49262, 49137, 48879, 48344,
                                    48225, 48027, 47665, 47558, 47525, 47234, 46620, 45100, 44977, 44953,
                                    44867, 44753, 44428, 42588, 42307, 41386, 40338, 40336, 40316, 40259,
                                    40197, 39971, 39931, 39037, 38517, 38081, 37952, 37436, 37244, 37176,
                                    37103, 36943, 36837, 36495, 36435, 36133, 35266, 35149, 34548, 33965,
                                    33734, 33586, 33342, 33320, 33159, 33095, 33010, 32814, 32714, 32590,
                                    32428, 31972, 31330, 31004, 30819, 30782, 30278, 30274, 29973, 29741 };
        int[] np;
        int summa = 0;
        public DoubleWordGenerator()
        {
            if (data.Length != weights.Length)
            {
                Console.WriteLine("Error");
                Environment.Exit(1);
            }
            for (int i = 0; i < data.Length; i++)
                summa += weights[i];
            np = new int[data.Length];
            int s2 = 0;
            for (int i = 0; i < data.Length; i++)
            {
                s2 += weights[i];
                np[i] = s2;
            }
        }
        public async Task ReadTextFromFileAsync(string path)
        {
            string textall = "";
            // асинхронное чтение
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                textall = textall + text;
            }
            textall = textall.Replace("\r", "");
            textall = textall.Replace("\n", " ");
            string[] wordnumber = new string[2];
            wordnumber = textall.Split(' ');
            for (int i = 0; i < data.Length; i++)
            {
                weights[i] = Int32.Parse(wordnumber[i]);
            }
            summa = 0;
            for (int i = 0; i < data.Length; i++)
                summa += weights[i];
            np = new int[data.Length];
            int s2 = 0;
            for (int i = 0; i < data.Length; i++)
            {
                s2 += weights[i];
                np[i] = s2;
            }
        }
        public string getSym()
        {
            int m = random.Next(0, summa);
            int j;
            for (j = 0; j < data.Length; j++)
            {
                if (m < np[j])
                    break;
            }
            return data[j];
        }
    }
    public class WordGeneratorMarkov
    {
        private Dictionary<string,List<string>> Word = new Dictionary <string, List<string>>();
        private Random random = new Random();
        private string path;
        public string[] textarray { get; set; }
        private string index;
        public string Result { get; set; }
        public WordGeneratorMarkov(string path)
        {
            this.path = path;
            this.index = " ";
        }
        void addKey(string w1, string w2)
        {
            Dictionary<string, List<string>>.KeyCollection keyColl = Word.Keys;
            bool inDictionary = false;
            foreach (string s in keyColl)
            {
                if (w1.Equals(s))
                {
                    Word[s].Add(w2);
                    inDictionary = true;
                    break;
                }
            }
            if (!inDictionary)
            {
                Word.Add(w1, new List<string>() { w2 });
            }
        }
        public async Task ReadTextFromFileAsync()
        {
            string textall = "";
            // асинхронное чтение
            using (StreamReader reader = new StreamReader(this.path))
            {
                string text = await reader.ReadToEndAsync();
                textall = textall + text;
            }
            textall = textall.Replace("\r", "");
            textall = textall.Replace("\n", " ");
            textarray = textall.Split(' ');
            for (int i = 0; i < textarray.Length; i++)
            {
                if (i < textarray.Length - 1)
                    addKey(textarray[i], textarray[i + 1]);
                else addKey(textarray[i], textarray[0]);
            }
        }
        private string GenWords(string w1)
        {
            string genstring = "";
            int m = 0;
            Dictionary<string, List<string>>.KeyCollection keyColl = Word.Keys;
            foreach (string s in keyColl)
            {
                if (w1.Equals(s))
                {
                    m = random.Next(0, Word[s].Count);
                    genstring = Word[s][m];
                    index = Word[s][m];
                    break;
                }
            }
            return genstring;
        }
        public void Generate()
        {
            if (this.index.Equals(" "))
            {
                this.Result = textarray[0];
                index = textarray[0];
            }
            else
            {
                this.Result +=" " +  GenWords(index);
            }
        }
    }
    public class DoubleWordGeneratorMarkov
    {
        private Dictionary<string[], List<string>> Word = new Dictionary<string[], List<string>>();
        private Random random = new Random();
        private string path;
        public string[] textarray { get; set; }
        private string[] index;
        public string Result { get; set; }
        public DoubleWordGeneratorMarkov(string path)
        {
            this.path = path;
            this.index = new string[] { " ", " " };
        }
        void addKey(string w1, string w2, string w3)
        {
            Dictionary<string[], List<string>>.KeyCollection keyColl = Word.Keys;
            bool inDictionary = false;
            foreach (string[] s in keyColl)
            {
                if (w1.Equals(s[0]) && w2.Equals(s[1]))
                {
                    Word[s].Add(w3);
                    inDictionary = true;
                    break;
                }
            }
            if (!inDictionary)
            {
                Word.Add(new string[] { w1, w2 }, new List<string>() { w3 });
            }
        }
        public async Task ReadTextFromFileAsync()
        {
            string textall = "";
            // асинхронное чтение
            using (StreamReader reader = new StreamReader(this.path))
            {
                string text = await reader.ReadToEndAsync();
                textall = textall + text;
            }
            textall = textall.Replace("\r", "");
            textall = textall.Replace("\n", " ");
            textarray = textall.Split(' ');
            for (int i = 0; i < textarray.Length; i++)
            {
                if (i < textarray.Length - 2)
                    addKey(textarray[i], textarray[i + 1], textarray[i + 2]);
                else if (i == textarray.Length - 2)
                    addKey(textarray[i], textarray[i + 1], textarray[0]);
                else if (i == textarray.Length - 1)
                    addKey(textarray[i], textarray[0], textarray[1]);
            }
        }
        private string GenWords(string w1, string w2)
        {
            string genstring = "";
            int m = 0;
            Dictionary<string[], List<string>>.KeyCollection keyColl = Word.Keys;
            foreach (string[] s in keyColl)
            {
                if (w1.Equals(s[0]) && w2.Equals(s[1]))
                {
                    m = random.Next(0, Word[s].Count);
                    genstring = Word[s][m];
                    index[0] = w2;
                    index[1] = Word[s][m];
                    break;
                }
            }
            return genstring;
        }
        public void Generate()
        {
            if (this.index[0].Equals(" ") && this.index[1].Equals(" "))
            {
                this.Result = textarray[0] + " " + textarray[1];
                index[0] = textarray[0];
                index[1] = textarray[1];
            }
            else
            {
                this.Result += " " + GenWords(index[0], index[1]);
            }
        }
    }
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            DoubleWordGeneratorMarkov gen = new DoubleWordGeneratorMarkov("DoubleWordGeneratorMarkovTest1.txt");
            await gen.ReadTextFromFileAsync();
            for (int i = 0; i < gen.textarray.Length - 1; i++)
            {
                gen.Generate();
            }
            Console.WriteLine(gen.Result);
            string path = "DoubleWordGeneratorMarkovResult2.txt";
            // полная перезапись файла 
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync(gen.Result);
            }
        }
    }
}
