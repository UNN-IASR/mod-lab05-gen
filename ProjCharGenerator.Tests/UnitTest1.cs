﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using generator;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1_1()
        {
            CharGenerator_1 charGenerator_1 = new CharGenerator_1();
            Assert.AreEqual(charGenerator_1.count_syms, Math.Sqrt(charGenerator_1.veroyatnost.Length));
        }

        [TestMethod]
        public void Test1_2()
        {
            CharGenerator_1 charGenerator_1 = new CharGenerator_1();
            charGenerator_1.Ubrat_Nuli();
            charGenerator_1.Diapazon_Summ();
            Assert.AreEqual(charGenerator_1.summa, charGenerator_1.verhnie_granici[charGenerator_1.count_syms - 1, charGenerator_1.count_syms - 1]);
        }

        [TestMethod]
        public void Test1_3()
        {
            CharGenerator_1 charGenerator_1 = new CharGenerator_1();
            charGenerator_1.Ubrat_Nuli();
            charGenerator_1.Diapazon_Summ();
            charGenerator_1.getSym();
            Assert.AreEqual(charGenerator_1.getSym().Length, 2);
        }


        [TestMethod]
        public void Test2_1()
        {
            CharGenerator_2 charGenerator_2 = new CharGenerator_2();
            Assert.AreEqual(charGenerator_2.slova[0], "и");
        }

        [TestMethod]
        public void Test2_2()
        {
            CharGenerator_2 charGenerator_2 = new CharGenerator_2();
            charGenerator_2.Mimnimizacia_veroyatnostnih_chisel();
            Assert.AreEqual(charGenerator_2.chastota[0], 13986435);
        }

        [TestMethod]
        public void Test2_3()
        {
            CharGenerator_2 charGenerator_2 = new CharGenerator_2();
            charGenerator_2.Mimnimizacia_veroyatnostnih_chisel();
            Assert.AreEqual(charGenerator_2.summa, charGenerator_2.veroyatnost[99]);
        }



    }
}
