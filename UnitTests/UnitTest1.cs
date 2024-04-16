namespace UnitTests;
using generator;

[TestClass]
public class BigramsGeneratorTests
{
    BigramsGenerator generator;

    public BigramsGeneratorTests()
    {
        generator = new BigramsGenerator();
    }

    [TestMethod]
    public void Test_OneLength()
    {
        int result = generator.StartGenerator(1).Length;

        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Test_TwoLength()
    {
        int result = generator.StartGenerator(2).Length;

        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Test_0Length()
    {
        int result = generator.StartGenerator(0).Length;

        Assert.AreEqual(0, result);
    }
}

[TestClass]
public class WordsGeneratorTests
{
    WordsGenerator generator;

    public WordsGeneratorTests()
    {
        generator = new WordsGenerator();
    }

    [TestMethod]
    public void Test_OneLength()
    {
        var result = generator.StartGenerator(2).Split(" ").ToList();

        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    public void Test_TwoLength()
    {
        var result = generator.StartGenerator(3).Split(" ").ToList();

        Assert.AreEqual(3, result.Count);
    }

    [TestMethod]
    public void Test_0Length()
    {
        var result = generator.StartGenerator(1).Split(" ").ToList();

        Assert.AreEqual(1, result.Count);
    }
}