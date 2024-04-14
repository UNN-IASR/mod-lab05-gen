using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace generator
{
    internal class WordGen
    {
        int size;
        Random random = new Random();
        int[] weights;
        string[] words;
        //Массив верхних границ диапазона целых чисел для каждого из символов
        int[] np;
        int summa = 0;
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
            for (int i = 1; i <=rows; i++)
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
}
