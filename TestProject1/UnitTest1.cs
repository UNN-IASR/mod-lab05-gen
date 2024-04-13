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
        dz1.ReadFile("test1");
        var res = dz1.Complete();
        Assert.AreEqual("a",res);
    } 
    public void TestMethod2()
    {
        DzGenerator1 dz1 = new DzGenerator1(); 
        dz1.ReadFile("test2");
        var res = dz1.Complete();
        Assert.IsNull(res);
    }
    public void TestMethod3()
    {
        DzGenerator1 dz1 = new DzGenerator1();
        dz1.ReadFile("test3");
        var res = dz1.Complete();
        Assert.IsTrue(res == "a" || res == "b"|| res == "c");
    }
    public void TestMethod4()
    {
        DzGenerator2 dz2 = new DzGenerator2();
        dz2.ReadFile("test4");
        var res = dz2.Complete();
        Assert.AreNotEqual(res, "b");
    }
    public void TestMethod5()
    {
        DzGenerator2 dz2 = new DzGenerator2();
        dz2.ReadFile("test5");
        var res = dz2.Complete();
        Assert.IsNotNull(res);
    }
    public void TestMethod6()
    {
        DzGenerator2 dz2 = new DzGenerator2();
        dz2.ReadFile("test6");
        var res = dz2.Complete();
        Assert.IsTrue(res == "a" || res == "b");
    }
}