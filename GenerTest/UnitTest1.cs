using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;

namespace GenerTest
{
    [TestClass]

    public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        WordGenerator wg = new WordGenerator();
        int truesize = 500;
        Assert.AreEqual(wg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod11()
    {
        WordGenerator wg = new WordGenerator();
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
        BinGenerator bcg = new BinGenerator();
        int truesize = 694;
        Assert.AreEqual(bcg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod31()
    {
        BinGenerator bcg = new BinGenerator();
        int truesize = 690;
        Assert.AreNotEqual(bcg.getSize(), truesize);
    }
    [TestMethod]
    public void TestMethod4()
    {
        WordGenerator wg = new WordGenerator();
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
        BinGenerator bcg = new BinGenerator();
        string bc = bcg.getBigram();
        Assert.IsTrue(bcg.isBigramInData(bc));
    }
}
}

