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
            Monster m = new Monster("Klaarg", "klaarg.png");
            m.setCurrentHealth(0);
            Assert.IsFalse(m.isAlive());
        }
    }
}
