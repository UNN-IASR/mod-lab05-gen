using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;

namespace classTest;

[TestClass]
public class CharGenerator2Tests
{

    [TestMethod]
    public void ReturnsNonEmptyString()
    {
        var symbols = new Tuple<string, int>[]
        {
            Tuple.Create("a", 1)
        };
        var generator = new CharGenerator2(symbols);

        var result = generator.generate();

        Assert.IsFalse(string.IsNullOrEmpty(result));
    }

    [TestMethod]
    public void ReturnsCorrectSymbol()
    {
        var symbols = new Tuple<string, int>[]
        {
            Tuple.Create("a", 1)
        };
        var generator = new CharGenerator2(symbols);

        var result = generator.generate();

        Assert.AreEqual("a", result);
    }

    [TestMethod]
    public void ReturnsOneOfGivenSymbols()
    {
        var symbols = new Tuple<string, int>[]
        {
            Tuple.Create("a", 1),
            Tuple.Create("b", 1)
        };
        var generator = new CharGenerator2(symbols);

        var result = generator.generate();

        Assert.IsTrue(result == "a" || result == "b");
    }

    [TestMethod]
    public void ReturnsEmptyStringIfSumOfWeightsIsZero()
    {
        var symbols = new Tuple<string, int>[]
        {
            Tuple.Create("a", 0),
            Tuple.Create("b", 0)
        };
        var generator = new CharGenerator2(symbols);

        var result = generator.generate();

        Assert.IsTrue(string.IsNullOrEmpty(result));
    }
    
    [TestMethod]
    public void ReturnsNonEmptyStringWord()
    {
        var symbols = new Tuple<string, int>[]
        {
            Tuple.Create("aaaaaaaa", 1)
        };
        var generator = new CharGenerator2(symbols);

        var result = generator.generate();

        Assert.IsFalse(string.IsNullOrEmpty(result));
    }

    [TestMethod]
    public void ReturnsCorrectWord()
    {
        var words = new Tuple<string, int>[]
        {
            Tuple.Create("aaaaaaa", 1)
        };
        var generator = new CharGenerator2(words);

        var result = generator.generate();

        Assert.AreEqual("aaaaaaa", result);
    }

    [TestMethod]
    public void ReturnsOneOfGivenWords()
    {
        var words = new Tuple<string, int>[]
        {
            Tuple.Create("aaaaa", 1),
            Tuple.Create("bbbbb", 1)
        };
        var generator = new CharGenerator2(words);

        var result = generator.generate();

        Assert.IsTrue(result == "aaaaa" || result == "bbbbb");
    }

    [TestMethod]
    public void ReturnsEmptyStringIfSumOfWeightsIsZeroForWords()
    {
        var words = new Tuple<string, int>[]
        {
            Tuple.Create("aaaaa", 0),
            Tuple.Create("bbbbb", 0)
        };
        var generator = new CharGenerator2(words);

        var result = generator.generate();

        Assert.IsTrue(string.IsNullOrEmpty(result));
    }
}