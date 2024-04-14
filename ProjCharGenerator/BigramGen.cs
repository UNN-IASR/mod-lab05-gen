using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace generator
{
    internal class BigramGen
    {
        int size;
        Random random = new Random();
        int[] weights;
        string[] pairs;
        //Массив верхних границ диапазона целых чисел для каждого из символов
        int[] np;
        int summa = 0;
        public BigramGen()
        {
            InputData(out pairs, out weights); //берём данные прямо из сайта
            size = pairs.Length;
            if (size != weights.Length)
            {
                Console.WriteLine("Error!");
                Environment.Exit(1);
            }
            for (int i = 0; i < size; i++)
                summa += weights[i];
            np = new int[size];
            //заполнение массива верхних границ символов
            int s2 = 0;
            for (int i = 0; i < size; i++)
            {
                s2 += weights[i];
                np[i] = s2;
            }
        }
        public string getPair()
        {
            int m = random.Next(0, summa);
            int j;
            //поиск биграммы по его диапазону случайных значений
            for (j = 0; j < size; j++)
            {
                if (m < np[j])
                    break;
            }
            return pairs[j];
        }
        static void InputData(out string[] pairs, out int[] weights)
        {
            string url = "http://dict.ruslang.ru/freq.php?act=show&dic=freq_2letters&title=%D7%E0%F1%F2%EE%F2%ED%EE%F1%F2%FC%20%E4%E2%F3%E1%F3%EA%E2%E5%ED%ED%FB%F5%20%F1%EE%F7%E5%F2%E0%ED%E8%E9";
            var web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            HtmlNodeCollection rows = doc.DocumentNode.SelectNodes("/html/body/table/tr[1]/td[2]/table/tr");
            int size = rows.Count-2;
            pairs = new string[size];
            weights = new int[size];
            for (int i = 2; i < rows.Count; i++) 
            {
                HtmlNodeCollection cells = rows[i].SelectNodes("./td");
                pairs[i-2] = cells[1].InnerText;
                weights[i - 2] = int.Parse(cells[2].InnerText);
            }
        }
        public void PrintData()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{pairs[i]} | {weights[i]}");
            }
        }
    }
}
