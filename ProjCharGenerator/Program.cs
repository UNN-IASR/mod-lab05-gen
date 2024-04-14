using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    public class CharGenerator
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
@@ -19,6 +20,75 @@ public char getSym()
           return data[random.Next(0, size)]; 
        }
    }

    public class TextGenerator
    {
        private string[] words;
        private double[] prefixSum;
        private int size;
        private Random random = new Random();
        public TextGenerator() 
        {
            size = 0;
        }

        public TextGenerator(string[] words, double[] values)
        {
            size = words.Length;
            this.words = words;
            prefixSum = new double[size];

            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    prefixSum[i] = values[i];
                }
                else
                {   
                    prefixSum[i] = prefixSum[i - 1] + values[i];
                }
            }
        }

        public void LoadDataFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            size = lines.Length;
            words = new string[size];
            prefixSum = new double[size];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                words[i] = parts[0];
                if (i == 0) 
                {
                    prefixSum[i] = double.Parse(parts[1]);
                }
                else
                {
                    prefixSum[i] = prefixSum[i - 1] + double.Parse(parts[1]);
                }
            } 
        }

        public string getSym() 
        {
            int ind;
            double value = random.NextDouble() * prefixSum[size - 1];
            for(ind = 0; ind < size; ind++)
            {
                if(value < prefixSum[ind])
                {
                    break;
                }
            }
            return words[ind]; 
        }

    }
    class Program
    {
        static void Main(string[] args)
@@ -39,6 +109,23 @@ static void Main(string[] args)
                 Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            }

            string res1, res2;
            res1 = res2 = "";
            TextGenerator generator = new TextGenerator();

            generator.LoadDataFromFile("Data1.txt");
            for(int i = 0; i < 1000; i++) 
            {
               res1 += generator.getSym();
            }
            File.WriteAllText("Res1.txt", res1);

            generator.LoadDataFromFile("Data2.txt");
            for(int i = 0; i < 1000; i++) 
            {
               res2 += generator.getSym();
            }
            File.WriteAllText("Res2.txt", res2);
        }
    }
}
