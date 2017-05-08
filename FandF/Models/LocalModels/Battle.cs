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
        public string logLine { get; set; }

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

        public List<Character> getParty()
        {
            //FIXME: need to deep copy all characters in party, then return new list.
            //This may involve giving Character a clone method.
            List<Character> temp = new List<Character>();
            return temp;
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
            Random rand = new Random();
            int diceRoll = rand.Next(1, 21);

            //see if monster dodges
            int dodgeCalc = (myChar.Dex + myChar.getItemDex()) - myMons.Dex;

            //if attack is a hit
            if(dodgeCalc > diceRoll){
                int damageCalc = (myChar.Str + myChar.getItemStr()) - myMons.Def;
                //myMons.setCurrentHealth(myMons.getCurrentHealth()-damageCalc);
                myMons.CurrentHealth = myMons.CurrentHealth - damageCalc;
                //if monster dies, character gains expvalue
                if(myMons.CurrentHealth <= 0){
                    myChar.gainExp(myMons.expValue);
                }
            }

        }

        public void monsAttack(Monster myMons, Character myChar)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 21);

            //see if character dodges
            int dodgeCalc = myMons.Dex - (myChar.Dex + myChar.getItemDex());

			//if attack is a hit
			if (dodgeCalc > diceRoll)
			{
                int damageCalc = myMons.Str - (myChar.Def + myChar.getItemDef());
                myChar.CurrentHealth = (myChar.CurrentHealth - damageCalc);
			}
        }

        private Monster getMonsterWithLeastHealth()
        {
            Monster weakest = monsters[0];
            foreach(Monster myMons in monsters)
            {
                if(myMons.CurrentHealth < weakest.CurrentHealth)
                {
                    weakest = myMons;
                }
            }

            return weakest;
        }

        //Returns a sorted list of strings that dictate turn order in format "[fighterDex].[arrayDesignation].[posInArray]"
        private List<String> determineTurnOrder()
        {
            List<String> turnOrder = new List<String>();
            foreach(Character myChar in characters)
            {
                turnOrder.Add(myChar.Dex + ".c." + characters.IndexOf(myChar));
            }
            foreach(Monster myMons in monsters)
            {
                turnOrder.Add(myMons.Dex + ".m." + monsters.IndexOf(myMons));
            }

            //The default sort will sort the fighters by dexterities and prioritize characters over monsters
            turnOrder.Sort();
            return turnOrder;
        }

        //Determine if party is dead
        public bool isPartyAlive()
        {
            foreach(Character character in this.characters)
            {
                if(character.CurrentHealth > 0) //if at least one alive, return true
                {
                    return true;
                }
            }
            return false;
        }

        //did party kill all monsters in this battle?
        public bool areMonstersAlive()
        {
            foreach(Monster monster in this.monsters)
            {
                if(monster.CurrentHealth > 0) //if at least one alive, return true
                {
                    return true;
                }
            }
            return false;
        }
    }
}
