using generator;
using System;
using System.IO;
namespace Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1_SumWeight()
    {
        CharGenerator2 gen = new CharGenerator2();
        Assert.AreEqual(gen.SumWeight(), 4814);    
    }
    [TestMethod]
    public void TestMethod2_Rule()
    {
        CharGenerator2 gen = new CharGenerator2();
        Assert.AreEqual(gen.Rule(4)[0], 0);    
    }
     [TestMethod]
    public void TestMethod3_Rule()
    {
        CharGenerator2 gen = new CharGenerator2();
        Assert.AreEqual(gen.Rule(4)[1], 1);    
    }
    [TestMethod]
    public void TestMethod4_Rule()
    {
        CharGenerator2 gen = new CharGenerator2();
        Assert.AreEqual(gen.Rule(50)[1], 3);    
    }
    [TestMethod]
    public void TestMethod5_GenSum()
    {
        CharGenerator2 gen = new CharGenerator2();
        Assert.IsTrue(gen.getSym() is string);    
    }
        [TestMethod]
    public void TestMethod6_SumWeight()
    {
        CharGenerator3 gen = new CharGenerator3();
        Assert.AreEqual(gen.SumWeight(), 62445);    
    }
    [TestMethod]
    public void TestMethod7_Rule()
    {
        CharGenerator3 gen = new CharGenerator3();
        Assert.AreEqual(gen.Rule(1), 0);    
    }
     [TestMethod]
    public void TestMethod8_Rule()
    {
        CharGenerator3 gen = new CharGenerator3();
        Assert.AreEqual(gen.Rule(10000), 1);    
    }
    [TestMethod]
    public void TestMethod9_Rule()
    {
        CharGenerator3 gen = new CharGenerator3();
        Assert.AreEqual(gen.Rule(62444), 99);    
    }
    [TestMethod]
    public void TestMethod10_GenSum()
    {
        CharGenerator3 gen = new CharGenerator3();
        Assert.IsTrue(gen.getSym() is string);    
    }
    
}