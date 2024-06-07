using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCharGenerator
{
    public class Generator_BIGRAMM
    {

        private string alphabet = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] characters;
        private int arraySize;
        private Random generator = new Random();

        // Массив верхних границ диапазона целых чисел для каждого из символов
        int[,] upperLimits;
        int[,] probabilities;

        public Generator_BIGRAMM()
        {
            arraySize = alphabet.Length;
            characters = alphabet.ToCharArray();
            upperLimits = new int[arraySize, arraySize];
            probabilities = new int[arraySize, arraySize];

            string pathToFile = "../../../TextFile1.txt";

            using (StreamReader fileReader = new StreamReader(pathToFile))
            {
                string? currentLine = fileReader.ReadLine();
                while (currentLine != null)
                {
                    string[] splitLine = currentLine.Split(new char[] { '\t' });
                    int probabilityValue = int.Parse(splitLine[2]);
                    probabilities[alphabet.IndexOf(splitLine[1][0]), alphabet.IndexOf(splitLine[1][1])] = probabilityValue;
                    currentLine = fileReader.ReadLine();
                }
            }

            int totalProbabilitySum = 0;
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    totalProbabilitySum += probabilities[i, j];
                    upperLimits[i, j] = totalProbabilitySum;
                }
            }
        }

        public char GenerateNextSymbol(char currentLetter)
        {
            int index = 0;
            if (alphabet.Contains(currentLetter))
            {
                int lowerBound;
                if (currentLetter != alphabet[0])
                {
                    lowerBound = upperLimits[alphabet.IndexOf(currentLetter) - 1, arraySize - 1];
                }
                else
                {
                    lowerBound = 0;
                }
                int upperBound = upperLimits[alphabet.IndexOf(currentLetter), arraySize - 1];
                index = generator.Next(lowerBound, upperBound + 1);
            }
            else
            {
                return alphabet[generator.Next(0, arraySize)];
            }

            int columnIndex = 0;
            // Поиск следующего символа по его диапазону случайных значений
            for (int rowIndex = 0; rowIndex < arraySize; rowIndex++)
            {
                for (columnIndex = 0; columnIndex < arraySize; columnIndex++)
                {
                    if (index <= upperLimits[rowIndex, columnIndex])
                    {
                        return characters[columnIndex];
                    }
                }
            }
            return characters[columnIndex];
        }


    }
}
