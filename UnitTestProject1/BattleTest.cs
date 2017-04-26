using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FandF;

namespace UnitTestProject1
{
    [TestClass]
    public class BattleTest
    {
        [TestMethod]
        public void TakeTurnTest()
        {
			List<Character> cl;
			List<Monster> ml;
			Character a = new Character("Magnus Burnsides", "magnus.png");
			Character b = new Character("Merle Highchurch", "merle.png");
			Monster m = new Monster("Klaarg", "klaarg.png", 0 , 0, 0, 0, 0, 0);
			Monster n = new Monster("Legion", "legion.png", 0, 0, 0, 0, 10, 500);
			cl.add(a);
			cl.add(b);
			ml.add(m);
			ml.add(n);
			Battle battle = new Battle(cl, ml);
			battle.takeTurn();
			Assert.isTrue(getCharAtIndex[0].getMaxHealth != getCharAtIndex[0].getCurrentHealth);
        }

        [TestMethod]
        public void CharAttackTest()
        {
            List<Character> cl;
			List<Monster> ml;
			Character a = new Character("Magnus Burnsides", "magnus.png");
			Character b = new Character("Merle Highchurch", "merle.png");
			Monster m = new Monster("Klaarg", "klaarg.png", 0 , 0, 0, 0, 0, 0);
			Monster n = new Monster("Legion", "legion.png", 0, 0, 0, 0, 10, 500);
			cl.add(a);
			cl.add(b);
			ml.add(m);
			ml.add(n);
			Battle battle = new Battle(cl, ml);
			battle.charAttack(battle.getCharAtIndex[0], battle.getMonsterAtIndex[0]);
			Assert.isTrue(battle.getMonsterAtIndex[0].getMaxHealth != getMonsterAtIndex[0].getCurrentHealth);
        }

        [TestMethod]
        public void MonsAttackTest()
        {
            List<Character> cl;
			List<Monster> ml;
			Character a = new Character("Magnus Burnsides", "magnus.png");
			Character b = new Character("Merle Highchurch", "merle.png");
			Monster m = new Monster("Klaarg", "klaarg.png", 0 , 0, 0, 0, 0, 0);
			Monster n = new Monster("Legion", "legion.png", 0, 0, 0, 0, 10, 500);
			cl.add(a);
			cl.add(b);
			ml.add(m);
			ml.add(n);
			Battle battle = new Battle(cl, ml);
			battle.monsAttack(battle.getMonsterAtIndex[0], battle.getCharacterAtIndex[0]);
			Assert.isTrue(battle.getCharacterAtIndex[0].getMaxHealth != getCharacterAtIndex[0].getCurrentHealth);
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