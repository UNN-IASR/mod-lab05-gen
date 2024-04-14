using generator;
namespace ProjCharGeneratorTests;

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void BigramSimpleTest()
    {
        string[] syms = ["aa"];
        int[] rate = [10];
        BigramGenerator gen = new BigramGenerator(syms, rate);
        string result = "";
        for (int i = 0; i < 10; i++) result += gen.getBigram();
        Assert.AreEqual(20, result.Length);
    }
    [TestMethod]
    public void BigramLoadTest() {
        string[] syms = ["ab", "bc", "cd", "de", "ef", "fg"];
        int[] rate = [10, 20, 30, 40, 50, 60];
        BigramGenerator gen = new BigramGenerator(syms, rate);
        Assert.IsTrue(gen.data.Keys.ToArray().SequenceEqual(syms));
    }
    [TestMethod]
    public void BigramEmptyErrorTest()
    {
        string[] syms = [];
        int[] rate = [];
        BigramGenerator gen = new BigramGenerator(syms, rate);
        Assert.ThrowsException<Exception>(() => gen.getBigram());
    }
    [TestMethod]
    public void BigramLengthErrorTest()
    {
        string[] syms = ["ab", "bc", "cd", "de", "ef", "fg"];
        int[] rate = [10];
        Assert.ThrowsException<Exception>(() => new BigramGenerator(syms, rate));
    }
    [TestMethod]
    public void WordSimpleTest()
    {
        string[] syms = ["aa"];
        double[] rate = [10];
        WordGenerator gen = new WordGenerator(syms, rate);
        string result = "";
        for (int i = 0; i < 10; i++) result += gen.getWord();
        Assert.AreEqual(20, result.Length);
    }
    [TestMethod]
    public void WordLoadTest() {
        string[] syms = ["ab", "bc", "cd", "de", "ef", "fg"];
        double[] rate = [10, 20, 30, 40, 50, 60];
        WordGenerator gen = new WordGenerator(syms, rate);
        Assert.IsTrue(gen.data.Keys.ToArray().SequenceEqual(syms));
    }
    [TestMethod]
    public void WordEmptyErrorTest()
    {
        string[] syms = [];
        double[] rate = [];
        WordGenerator gen = new WordGenerator(syms, rate);
        Assert.ThrowsException<Exception>(() => gen.getWord());
    }
    [TestMethod]
    public void WordLengthErrorTest()
    {
        string[] syms = ["ab", "bc", "cd", "de", "ef", "fg"];
        double[] rate = [10];
        Assert.ThrowsException<Exception>(() => new WordGenerator(syms, rate));
    }
}