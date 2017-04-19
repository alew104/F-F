using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FandF;

namespace UnitTestProject1
{
    [TestClass]
    public class MonsterTest
    {
        [TestMethod]
        public void IsMonsterAliveTest()
        {
            Character c = new Character("Merle Highchurch", "merle.png");
            c.setCurrentHealth(0);
            Assert.IsFalse(c.isAlive());
        }
    }
}
