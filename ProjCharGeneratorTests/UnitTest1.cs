using generator;

namespace TestProject1;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        List<string> syms = new List<string>{"one", "two", "three"};
        List<int> weights = new List<int>{1, 2, 3};
        Generator gen = new Generator(syms, weights);
        Assert.AreEqual(gen.syms.Count, syms.Count);
        Assert.AreEqual(gen.weights.Count, weights.Count);
    }
    [TestMethod]
    public void TestMethod2()
    {
        List<string> syms = new List<string>{"one", "two", "three"};
        List<int> weights = new List<int>{1, 2, 3};
        Generator gen = new Generator(syms, weights);
        Assert.AreEqual(6, gen.max);
    }
    [TestMethod]
    public void TestMethod3()
    {
        List<string> syms = new List<string>{"one", "two", "three"};
        List<int> weights = new List<int>{1, 2, 3};
        Generator gen = new Generator(syms, weights);
        string res = gen.getSym();
        Assert.IsTrue(res == "one" || res == "two" || res == "three");
    }
    [TestMethod]
    public void TestMethod4()
    {
        List<string> syms = new List<string>{"one", "two", "three"};
        List<int> weights = new List<int>{1, 2, 3};
        Generator gen = new Generator(syms, weights);
        string res = "";
        for (int i = 0; i < 15; i++) res += gen.getSym() + ",";
        Assert.AreEqual(15, res.Split(',', StringSplitOptions.RemoveEmptyEntries).Length);
    }
    [TestMethod]
    public void TestMethod5()
    {
        List<string> syms = new List<string>();
        List<int> weights = new List<int>();
        Generator gen = new Generator(syms, weights);
        Assert.IsTrue(string.IsNullOrEmpty(gen.getSym()));
    }
    [TestMethod]
    public void TestMethod6()
    {
        List<string> syms = new List<string>{"one", "two", "three"};
        List<int> weights = new List<int>();
        Generator gen = new Generator(syms, weights);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => gen.getSym());
    }
}