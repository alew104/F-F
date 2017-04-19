using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FandF;

namespace UnitTestProject1
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void CharacterLevelUpTest()
        {
            Character c = new Character("Magnus Burnsides", "magnus.png");
            c.gainExp(110);
            Assert.AreEqual(2, c.getLevel());
        }

        [TestMethod]
        public void CharacterIsAliveTest()
        {
            Character c = new Character("Merle Highchurch", "merle.png");
            c.setCurrentHealth(0);
            Assert.IsFalse(c.isAlive());
        }

        [TestMethod]
        public void CharacterAddItemTest()
        {
            Character c = new Character("The Director", "thedirector.png");
            Item i1 = new Item();
            i1.setStr(50);
            c.addItem(i1);
            Assert.AreEqual(50, c.getItemStr());
        }

        [TestMethod]
        public void CharacterGetMultipleItemsStatsTest()
        {
            Character c = new Character("Taako Taco", "taako.png");
            Item i1 = new Item();
            Item i2 = new Item();
            i1.setStr(5);
            i2.setStr(5);
            c.addItem(i1);
            c.addItem(i2);
            Assert.AreEqual(10, c.getItemStr());
        }
    }
}
