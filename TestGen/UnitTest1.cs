namespace TestGen;
using generator;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        WordsGen wg = new WordsGen();
        int truesize = 500;
        Assert.AreEqual(wg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod11()
    {
        WordsGen wg = new WordsGen();
        int truesize = 499;
        Assert.AreNotEqual(wg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod2()
    {
        CharGenerator cg = new CharGenerator();
        int truesize = 33;
        Assert.AreEqual(cg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod21()
    {
        CharGenerator cg = new CharGenerator();
        int truesize = 30;
        Assert.AreNotEqual(cg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod3()
    {
        BinaryCharGen bcg = new BinaryCharGen();
        int truesize = 33;
        Assert.AreEqual(bcg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod31()
    {
        BinaryCharGen bcg = new BinaryCharGen();
        int truesize = 40;
        Assert.AreNotEqual(bcg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod4()
    {
        WordsGen wg = new WordsGen();
        string s = wg.getWord();
        Assert.IsTrue(wg.isWordInData(s));
    }
    [TestMethod]
    public void TestMethod5()
    {
        CharGenerator cg = new CharGenerator();
        char c = cg.getSym();
        Assert.IsTrue(cg.isCharInData(c));
    }
    [TestMethod]
    public void TestMethod6()
    {
        string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        Random r = new Random();
        char c = syms[r.Next(0,syms.Length)];
        BinaryCharGen bcg = new BinaryCharGen();
        char bc  = bcg.getSym(c);
        Assert.IsTrue(bcg.isBinCharInData(bc));
    }
}