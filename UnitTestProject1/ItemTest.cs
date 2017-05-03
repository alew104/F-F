using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FandF;

namespace UnitTestProject1
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void ItemConstructionTest()
        {
            Item i = new Item("Umbra Staff",  "Eats the magic power of fallen foes");
            Assert.AreEqual(i._name, "Umbra Staff");
        }

        [TestMethod]
        public void ItemGetAndSetStrengthTest()
        {
            Item i = new Item("Rail Splitter", "Can chop down a tree with a single strike once per day");
            i.setStr(44);
            Assert.AreEqual(i.getStr(), 44);
        }
    }
}
