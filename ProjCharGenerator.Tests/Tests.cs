using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using TextGenerator;
using BinFileManager;

namespace Tests
{
  [TestClass]
  public class Tests
  {
    [TestMethod]
    public void TestBinFileManager()
    {
      string stringInput = "Это строка предназначена для проверки считывания и записи информации в бинарном виде";

      BinFileManager.BinFileManager.WriteObjectToBinFile("TestFile.bin", stringInput);

      string stringOutput = BinFileManager.BinFileManager.ReadFromBinFileToObject<string>("TestFile.bin");

      Assert.AreEqual(stringInput, stringOutput);
    }

    [TestMethod]
    public void TestTextGenerator1()
    {
      SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();

      sortedDictionary.Add("a", 1);
      sortedDictionary.Add("b", 1);

      TextGenerator.TextGenerator textGenerator = new TextGenerator.TextGenerator(sortedDictionary);

      List<string> generatedList = textGenerator.Generate(10000);
      int[] lettersCount = new int[2];

      foreach (string value in generatedList)
      {
        switch (value)
        {
          case "a":
            lettersCount[0] += 1;
          break;
          case "b":
            lettersCount[1] += 1;
            break;
        }
      }

      Assert.IsTrue(lettersCount[0] / (double) lettersCount[1] < lettersCount[1] / 1.05 &&
                    lettersCount[0] / (double)lettersCount[1] > 0.95);
    }

    [TestMethod]
    public void TestTextGenerator2()
    {
      SortedDictionary<string, int> sortedDictionary;
      TextGenerator.TextGenerator textGenerator;
      List<string> stringList1, stringList2;

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("BiGrammDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList1 = textGenerator.Generate(100000);
      stringList2 = textGenerator.Generate(100000);

      int abs_eps = 100;
      int biGrammCount1 = 0, biGrammCount2 = 0;

      foreach (string value in stringList1)
      {
        if (value == "ав")
        {
            biGrammCount1 ++;
        }
      }

      foreach (string value in stringList2)
      {
        if (value == "ав")
        {
            biGrammCount2 ++;
        }
      }

      Assert.IsTrue(Math.Abs(biGrammCount1 - biGrammCount2) < abs_eps);
    }

    [TestMethod]
    public void TestTextGenerator3()
    {
      SortedDictionary<string, int> sortedDictionary;
      TextGenerator.TextGenerator textGenerator;
      List<string> stringList1, stringList2;

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("WordDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList1 = textGenerator.Generate(100000);
      stringList2 = textGenerator.Generate(100000);

      int abs_eps = 100;
      double biGrammCount1 = 0, biGrammCount2 = 0;

      foreach (string value in stringList1)
      {
        if (value == "что")
        {
            biGrammCount1 ++;
        }
      }

      foreach (string value in stringList2)
      {
        if (value == "что")
        {
            biGrammCount2 ++;
        }
      }

      Assert.IsTrue(Math.Abs(biGrammCount1 - biGrammCount2) < abs_eps);
    }

    [TestMethod]
    public void TestTextGenerator4()
    {
      SortedDictionary<string, int> sortedDictionary;
      TextGenerator.TextGenerator textGenerator;
      List<string> stringList1, stringList2;

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("WordDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList1 = textGenerator.Generate(100000);
      stringList2 = textGenerator.Generate(100000);

      int abs_eps = 100;
      int biGrammCount1 = 0, biGrammCount2 = 0;

      foreach (string value in stringList1)
      {
        if (value == "и")
        {
            biGrammCount1 ++;
        }
      }

      foreach (string value in stringList2)
      {
        if (value == "который")
        {
            biGrammCount2 ++;
        }
      }

      Assert.IsTrue(Math.Abs(biGrammCount1 - biGrammCount2) < abs_eps);
    }

    [TestMethod]
    public void TestTextGenerator5()
    {
      SortedDictionary<string, int> sortedDictionary;
      TextGenerator.TextGenerator textGenerator;
      List<string> stringList1, stringList2;

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("BiGrammDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList1 = textGenerator.Generate(100000);
      stringList2 = textGenerator.Generate(100000);

      int abs_eps = 100;
      int biGrammCount1 = 0, biGrammCount2 = 0;

      foreach (string value in stringList1)
      {
        if (value == "aб")
        {
            biGrammCount1 ++;
        }
      }

      foreach (string value in stringList2)
      {
        if (value == "ба")
        {
            biGrammCount2 ++;
        }
      }

      Assert.IsTrue(Math.Abs(biGrammCount1 - biGrammCount2) < abs_eps);
    }

    [TestMethod]
    public void TestTextGenerator6()
    {
      SortedDictionary<string, int> sortedDictionary;
      TextGenerator.TextGenerator textGenerator;
      List<string> stringList1, stringList2;

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("CoupleWordDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList1 = textGenerator.Generate(100000);
      stringList2 = textGenerator.Generate(100000);

      int abs_eps = 100;
      int biGrammCount1 = 0, biGrammCount2 = 0;

      foreach (string value in stringList1)
      {
        if (value == "и не")
        {
            biGrammCount1 ++;
        }
      }

      foreach (string value in stringList2)
      {
        if (value == "несмотря на")
        {
            biGrammCount2 ++;
        }
      }

      Assert.IsTrue(Math.Abs(biGrammCount1 - biGrammCount2) < abs_eps);
    }

    [TestMethod]
    public void TestTextGenerator7()
    {
      SortedDictionary<string, int> sortedDictionary;
      TextGenerator.TextGenerator textGenerator;
      List<string> stringList1, stringList2;

      sortedDictionary = (BinFileManager.BinFileManager.ReadFromBinFileToObject<SortedDictionary<string, int>>("CoupleWordDictionary.bin"));
      textGenerator = new TextGenerator.TextGenerator(sortedDictionary);
      stringList1 = textGenerator.Generate(100000);
      stringList2 = textGenerator.Generate(100000);

      int abs_eps = 100;
      int biGrammCount1 = 0, biGrammCount2 = 0;

      foreach (string value in stringList1)
      {
        if (value == "и не")
        {
            biGrammCount1 ++;
        }
      }

      foreach (string value in stringList2)
      {
        if (value == "и")
        {
            biGrammCount2 ++;
        }
      }

      Assert.IsTrue(Math.Abs(biGrammCount1 - biGrammCount2) < abs_eps);
    }
  }
}
