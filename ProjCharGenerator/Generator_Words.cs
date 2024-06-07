using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCharGenerator
{
    public class WordGenerator
    {
        public List<string> frequentWordsList = new List<string>();
        const int wordCount = 100;
        int[] cumulativeWeights;
        int[] individualWeights;
        Random randomGenerator = new Random();

        public WordGenerator()
        {
            string filePath = "../../../TextFile 2.txt";
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                individualWeights = new int[wordCount];
                cumulativeWeights = new int[wordCount];

                string? currentLine = fileReader.ReadLine();
                int currentIndex = 0;
                while (currentLine != null)
                {
                    string[] splitLine = currentLine.Split(new char[] { '\t' });
                    frequentWordsList.Add(splitLine[1]);
                    int weightValue = int.Parse(splitLine[3]);
                    individualWeights[currentIndex] = weightValue;
                    currentIndex++;
                    currentLine = fileReader.ReadLine();
                }

                int totalWeightSum = 0;
                for (int index = 0; index < wordCount; index++)
                {
                    totalWeightSum += individualWeights[index];
                    cumulativeWeights[index] = totalWeightSum;
                }
            }
        }

        public string GenerateWord()
        {
            int maxCumulativeWeight = cumulativeWeights[wordCount - 1];
            int selectedIndex = randomGenerator.Next(0, maxCumulativeWeight);
            int targetIndex = 0;

            for (targetIndex = 0; targetIndex < wordCount; targetIndex++)
            {
                if (selectedIndex < cumulativeWeights[targetIndex])
                {
                    break;
                }
            }

            return frequentWordsList[targetIndex];
        }
    }
}
