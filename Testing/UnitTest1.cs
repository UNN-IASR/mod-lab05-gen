using CharGenerator;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        Random rd = new Random(41);
        [TestMethod]
        public void TestBigramChar1()
        {
            int countTrue = 100;
            int countAns = new BigramChar(rd).GetText(countTrue)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();

            Assert.AreEqual(countTrue, countAns);
        }

        [TestMethod]
        public void TestBigramWord1()
        {
            int countTrue = 100;
            int countAns = new BigramWord(rd).GetText(countTrue)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();

            Assert.AreEqual(countTrue, countAns);
        }

        [TestMethod]
        public void TestBigramPairWord1()
        {
            int countTrue = 100;
            int countAns = new BigramPairWord(rd).GetText(countTrue)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();

            Assert.AreEqual(countTrue, countAns / 2);
        }

        [TestMethod]
        public void TestBigramChar2()
        {
            Random rd1 = new Random(2);
            Random rd2 = new Random(2);

            int countTrue = 100;
            string ans1 = new BigramChar(rd1).GetText(countTrue);
            string ans2 = new BigramChar(rd2).GetText(countTrue);

            Assert.AreEqual(ans1, ans2);
        }

        [TestMethod]
        public void TestBigramChar3()
        {
            Random rd1 = new Random(2);
            Random rd2 = new Random(3);

            int countTrue = 100;
            string ans1 = new BigramChar(rd1).GetText(countTrue);
            string ans2 = new BigramChar(rd2).GetText(countTrue);

            Assert.AreNotEqual(ans1, ans2);
        }

        [TestMethod]
        public void TestBigramWord2()
        {
            Random rd1 = new Random(2);
            Random rd2 = new Random(2);

            int countTrue = 100;
            string ans1 = new BigramWord(rd1).GetText(countTrue);
            string ans2 = new BigramWord(rd2).GetText(countTrue);

            Assert.AreEqual(ans1, ans2);
        }

        [TestMethod]
        public void TestBigramWord3()
        {
            Random rd1 = new Random(2);
            Random rd2 = new Random(3);

            int countTrue = 100;
            string ans1 = new BigramWord(rd1).GetText(countTrue);
            string ans2 = new BigramWord(rd2).GetText(countTrue);

            Assert.AreNotEqual(ans1, ans2);
        }

        [TestMethod]
        public void TestBigramPairWord2()
        {
            Random rd1 = new Random(2);
            Random rd2 = new Random(2);

            int countTrue = 100;
            string ans1 = new BigramPairWord(rd1).GetText(countTrue);
            string ans2 = new BigramPairWord(rd2).GetText(countTrue);

            Assert.AreEqual(ans1, ans2);
        }

        [TestMethod]
        public void TestBigramPairWord3()
        {
            Random rd1 = new Random(2);
            Random rd2 = new Random(3);

            int countTrue = 100;
            string ans1 = new BigramPairWord(rd1).GetText(countTrue);
            string ans2 = new BigramPairWord(rd2).GetText(countTrue);

            Assert.AreNotEqual(ans1, ans2);
        }
    }
}