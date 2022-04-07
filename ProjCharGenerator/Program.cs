using System.Collections.Generic;
using System.IO;

namespace CharGenerator
{

  class Program
  {
    static void Main(string[] args)
    {
      SortedDictionary<string, int> sortedDictionary;
      TextGenerator.TextGenerator textGenerator;
      List<string> stringList;

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("BiGrammDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList = textGenerator.Generate(100);
      File.WriteAllText("BIGrammOutputFile.txt", string.Join(null, stringList));

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("WordDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList = textGenerator.Generate(100);
      File.WriteAllText("WordOutputFile.txt", string.Join(" ", stringList));

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("CoupleWordDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList = textGenerator.Generate(100);
      File.WriteAllText("CoupleWordOutputFile.txt", string.Join(" ", stringList));
    }
  }
}
