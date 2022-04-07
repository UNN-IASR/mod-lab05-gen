using System;
using System.Collections.Generic;

namespace TextGenerator
{
  public class TextGenerator
  {
    public TextGenerator(SortedDictionary<string, int> elementaryPuzzlesWithFrequencies)
    {
      this.elementaryPuzzlesWithFrequencies = new SortedDictionary<string, int>(elementaryPuzzlesWithFrequencies);
    }

    public List<string> Generate(int wordCount)
    {
      List<string> resultString = new List<string>();

      for (int i = 0; i < wordCount; ++i)
      {
        resultString.Add(GetElementaryPuzzle());
      }

      return resultString;
    }

    private string GetElementaryPuzzle()
    {
      string candidateString = "";
      int frequenciesSum = 0;

      foreach (KeyValuePair<string, int> pair in elementaryPuzzlesWithFrequencies)
      {
        frequenciesSum += pair.Value;
      }

      Random random = new Random();
      int randomValue = random.Next(0, frequenciesSum);
      int currentSum = 0;

      foreach (KeyValuePair<string, int> pair in elementaryPuzzlesWithFrequencies)
      {
        if (currentSum + pair.Value > randomValue)
        {
          candidateString = pair.Key;
          break;
        }
        else
        {
          currentSum += pair.Value;
        }
      }

      return candidateString;
    }

    private SortedDictionary<string, int> elementaryPuzzlesWithFrequencies;
  }
}
