using System;
using System.Collections.Generic;
using System.Text;

namespace FandF
{
    public class Battle : ObservableObject
    {
        private List<Character> characters;
        private List<Monster> monsters;
        private List<String> turnOrder; //Elements formatted "[fighterDex].[arrayDesignation].[posInArray]"
        private int roundTurn;
        private int overallTurn;

        //Currently takes characters and monsters as parameters
        public Battle(List<Character> characters, List<Monster> monsters)
        {
            this.characters = characters;
            this.monsters = monsters;
            turnOrder = determineTurnOrder();
            roundTurn = 0;
            overallTurn = 0;
        }

        /**** GETTERS ****/

        public Character getCharacterAtIndex(int index)
        {
            return characters[index];
        }

        public Monster getMonsterAtIndex(int index)
        {
            return monsters[index];
        }

        public int getTurn()
        {
            return overallTurn;
        }

        /**** SETTERS ****/



        /**** BUSINESS LOGIC ****/

        public void takeTurn()
        {
            String[] combatant = turnOrder[roundTurn].Split('.');

            if(combatant[1] == "c") //Fighter is a character
            {
                Character currentCharacter = characters[Int32.Parse(combatant[2])];
                if (currentCharacter.isAlive())
                {
                    overallTurn++;
                    charAttack(currentCharacter, getMonsterWithLeastHealth());
                }
            }
            else //Fighter is a monster
            {
                Monster currentMonster = monsters[Int32.Parse(combatant[2])];
                if (currentMonster.isAlive())
                {
                    Random rand = new Random();

                    overallTurn++;
                    monsAttack(currentMonster, characters[rand.Next(characters.Count)]);
                }
            }
            roundTurn = (roundTurn + 1) % (characters.Count + monsters.Count);
        }

        public void charAttack(Character myChar, Monster myMons)
        {
            //myChar should call gainExp if myMons is dead after attack 
        }

        public void monsAttack(Monster myMons, Character myChar)
        {
            //TODO: all of it
        }

        private Monster getMonsterWithLeastHealth()
        {
            Monster weakest = monsters[0];
            foreach(Monster myMons in monsters)
            {
                if(myMons.getCurrentHealth() < weakest.getCurrentHealth())
                {
                    weakest = myMons;
                }
            }

            return weakest;
        }

        //Returns a sorted list of strings that dictate turn order in format "[fighterDex].[arrayDesignation].[posInArray]"
        private List<String> determineTurnOrder()
        {
            foreach(Character myChar in characters)
            {
                turnOrder.Add(myChar.getDex() + ".c." + characters.IndexOf(myChar));
            }
            foreach(Monster myMons in monsters)
            {
                turnOrder.Add(myMons.getDex() + ".m." + monsters.IndexOf(myMons));
            }

            //The default sort will sort the fighters by dexterities and prioritize characters over monsters
            turnOrder.Sort();
            return turnOrder;
        }
    }
}
