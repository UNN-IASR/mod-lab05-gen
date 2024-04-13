using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;
namespace TestProject1;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        DzGenerator1 dz1 = new DzGenerator1();
        dz1.ReadFile("../../../../test1.txt");
        var res = dz1.Complete();
        Assert.AreEqual("a",res);
    } 
    [TestMethod]
    public void TestMethod2()
    {
        DzGenerator1 dz1 = new DzGenerator1(); 
        dz1.ReadFile("../../../../test2.txt");
        var res = dz1.Complete();
        Assert.IsNotNull(res);
    }
    [TestMethod]
    public void TestMethod3()
    {
        DzGenerator1 dz1 = new DzGenerator1();
        dz1.ReadFile("../../../../test3.txt");
        var res = dz1.Complete();
        Assert.IsTrue(res == "a" || res == "b"|| res == "c");
    }
    [TestMethod]
    public void TestMethod4()
    {
        DzGenerator2 dz2 = new DzGenerator2();
        dz2.ReadFile("../../../../test4.txt");
        var res = dz2.Complete();
        Assert.AreNotEqual(res, "b");
    }
    [TestMethod]
    public void TestMethod5()
    {
        DzGenerator2 dz2 = new DzGenerator2();
        dz2.ReadFile("../../../../test5.txt");
        var res = dz2.Complete();
        Assert.IsNotNull(res);
    }
    [TestMethod]
    public void TestMethod6()
    {
        DzGenerator2 dz2 = new DzGenerator2();
        dz2.ReadFile("../../../../test6.txt");
        var res = dz2.Complete();
        Assert.IsTrue(res == "a" || res == "b");
    }
}