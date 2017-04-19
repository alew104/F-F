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

        /*[TestMethod]
        public void GetItemStatsTest()
        {
            Character c = new Character("Taako Taco", "taako.png");
            c.addItem(new Item("Umbral Staff", 0, 0, 10, 0));
            c.addItem(new Item("Ring of Frost", 0, 0, 5, 0));
            Assert.Equals(15, c.getItemDex());
        }*/
    }
}
