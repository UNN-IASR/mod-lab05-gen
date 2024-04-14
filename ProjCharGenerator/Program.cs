using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Aspose.Cells;
using HtmlAgilityPack;

namespace generator
{
    public class BigramGen
    {
        int size;
        Random random = new Random();
        int[] weights;
        string[] pairs;
        //Массив верхних границ диапазона целых чисел для каждого из символов
        int[] np;
        int summa = 0;
        public int Size { get { return size; } }
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
            int size = rows.Count - 2;
            pairs = new string[size];
            weights = new int[size];
            for (int i = 2; i < rows.Count; i++)
            {
                HtmlNodeCollection cells = rows[i].SelectNodes("./td");
                pairs[i - 2] = cells[1].InnerText;
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
    public class WordGen
    {
        int size;
        Random random = new Random();
        int[] weights;
        string[] words;
        //Массив верхних границ диапазона целых чисел для каждого из символов
        int[] np;
        int summa = 0;
        public int Size { get { return size; } }
        public WordGen()
        {
            InputData(out words, out weights); //берём данные прямо из сайта
            size = words.Length;
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
        public string getWord()
        {
            int m = random.Next(0, summa);
            int j;
            //поиск биграммы по его диапазону случайных значений
            for (j = 0; j < size; j++)
            {
                if (m < np[j])
                    break;
            }
            return words[j];
        }
        static void InputData(out string[] pairs, out int[] weights)
        {
            Workbook wb = new Workbook("../../../../ruscorpora_content.xlsx");
            WorksheetCollection collection = wb.Worksheets;
            Worksheet worksheet = collection[0];
            int rows = worksheet.Cells.MaxDataRow;
            int cols = worksheet.Cells.MaxDataColumn;
            pairs = new string[rows];
            weights = new int[rows];
            for (int i = 1; i <= rows; i++)
            {
                pairs[i - 1] = worksheet.Cells[i, 1].Value.ToString();
                weights[i - 1] = int.Parse(worksheet.Cells[i, 2].Value.ToString());
            }
        }
        public void PrintData()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{words[i]} | {weights[i]}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;
            WordGen wg = new WordGen();
            BigramGen bg= new BigramGen();
            using (FileStream fstream = new FileStream("../../../../gen-1.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer;
                for (int i = 0; i < 600; i++)
                {
                    string pair = bg.getPair();
                    buffer = Encoding.UTF8.GetBytes(pair);
                    fstream.Write(buffer, 0, buffer.Length);
                }
                Console.WriteLine("Текст записан в файл gen-1.txt");
            }
            using (FileStream fstream = new FileStream("../../../../gen-2.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer;
                for (int i = 0; i < 300; i++)
                {
                    string pair = wg.getWord()+" ";
                    buffer = Encoding.UTF8.GetBytes(pair);
                    fstream.Write(buffer, 0, buffer.Length);
                }
                Console.WriteLine("Текст записан в файл gen-2.txt");
            }
        }
    }
}

