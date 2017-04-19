using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FandF;

namespace UnitTestProject1
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void LevelUpTest()
        {
            Character c = new Character("Magnus Burnsides", "magnus.png");
            c.gainExp(110);
            Assert.AreEqual(2, c.getLevel());
        }

        [TestMethod]
        public void IsCharacterAliveTest()
        {
            Character c = new Character("Merle Highchurch", "merle.png");
            c.setCurrentHealth(0);
            Assert.IsFalse(c.isAlive());
        }

        [TestMethod]
        public void GetItemStatsTest()
        {
            Character c = new Character("Taako Taco", "taako.png");
            Item i1 = new Item();
            Item i2 = new Item();
            i1.setStr(5);
            i2.setStr(5);
            c.addItem(i1);
            c.addItem(i2);
            Assert.Equals(10, c.getItemStr());
        }
    }
}
