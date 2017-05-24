using System;
using System.Collections.Generic;
using System.Text;
using FandF.Services;

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

                    //Find living character to attack
                    Character charToAttack = characters[rand.Next(characters.Count)];
                    while (!charToAttack.isAlive() && isPartyAlive())
                    {
                        charToAttack = characters[rand.Next(characters.Count)];
                    }

                    monsAttack(currentMonster, charToAttack);
                }
            }
            roundTurn = (roundTurn + 1) % (characters.Count + monsters.Count);
        }

        public void charAttack(Character myChar, Monster myMons)
        {
            int damageCalc = 0;
            Random rand = new Random();
            int diceRoll = rand.Next(1, 21);

            int missThreshold = 4;

            //if attack is a hit
            if (diceRoll > missThreshold)
            {
                damageCalc = (myChar.Str + myChar.getItemStr()) - myMons.Def;
                if (damageCalc <= 0)
                    damageCalc = 2; //TESTING
                if (diceRoll == 20) //Critical hit
                    damageCalc *= 2;

                //myMons.setCurrentHealth(myMons.getCurrentHealth()-damageCalc);
                int monsHealth = myMons.CurrentHealth - damageCalc;
                if (monsHealth < 0)
                    monsHealth = 0;

                myMons.CurrentHealth = monsHealth;
                //if monster dies, character gains expvalue
                if (myMons.CurrentHealth <= 0)
                {
                    myChar.gainExp(myMons.expValue);
                }

                if(diceRoll == 20)
                    logLine = myChar.Name + " critically hit " + myMons.Name + " for " + damageCalc + " damage!!!";
                else
                    logLine = myChar.Name + " hit " + myMons.Name + " for " + damageCalc + " damage!";


            } else if (diceRoll == 1) { //Critical miss
                criticalMiss(myChar, myMons);
            }
            else
            {
                logLine = myChar.Name + "  missed " + myMons.Name;
            }

        }

        private void criticalMiss(Character myChar, Monster myMons)
        {


            if (myChar.hasItems())
            {
                Item removedItem = myChar.removeRandomItem();
                logLine = myChar.Name + " critically missed " + myMons.Name + " and dropped " + removedItem._name + "!";
            }
            else
            {
                logLine = myChar.Name + " critically missed " + myMons.Name + " but had nothing to drop!";
            }
        }

        public void monsAttack(Monster myMons, Character myChar)
        {
            int damageCalc = 0;
            Random rand = new Random();
            int diceRoll = rand.Next(1, 21);

            int missThreshold = 4;
            

			//if attack is a hit
			if (diceRoll > missThreshold)
			{
                damageCalc = myMons.Str - (myChar.Def + myChar.getItemDef());
                if (damageCalc <= 0)
                    damageCalc = 2; //TESTING
                if (diceRoll == 20) //Critical hit
                    damageCalc *= 2;

                int charHealth = myChar.CurrentHealth - damageCalc;
                if (charHealth < 0)
                    charHealth = 0;

                myChar.CurrentHealth = charHealth;

                if(diceRoll == 20)
                    logLine = myMons.Name + " critially hit " + myChar.Name + " for " + damageCalc + " damage!!!";
                else
                    logLine = myMons.Name + " attacked " + myChar.Name + " for " + damageCalc + " damage!";
            } else
            {
                logLine = myMons.Name + " missed " + myChar.Name;
            }
        }

        private Monster getMonsterWithLeastHealth()
        {
            //Max health monster so all other monsters are weaker
            Monster weakest = new Monster("", "", -1, -1, -1, Int32.MaxValue, 1, -1);
            foreach(Monster myMons in monsters)
            {
                if(myMons.CurrentHealth < weakest.CurrentHealth && myMons.isAlive())
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
            turnOrder.Reverse();
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

        public List<Character> endOfBattle()
        {
            int ITEMS_TO_GENERATE = 2;

            DBItemController itemAccess = new DBItemController();
            List<ItemDBModel> allItems = itemAccess.getAllItems();

            Random rand = new Random();

            //Generate random items and assign randomly to characters
            for (int i = 0; i < ITEMS_TO_GENERATE; i++)
            {
                ItemDBModel myItemModel = allItems[rand.Next(0,allItems.Count)];
                Item myItem = new Item(myItemModel.Name, myItemModel.Desc);
                myItem.setDef(myItemModel.Def);
                myItem.setDex(myItemModel.Dex);
                myItem.setHealth(myItemModel.Health);
                myItem.setStr(myItemModel.Str);
                myItem.setUsage(myItemModel.Usage);
                myItem.setBodyPart(myItemModel.BodyPart);

                int charToAssign = rand.Next(0, 4);
                while(isPartyAlive() && !characters[charToAssign].isAlive())
                    charToAssign = rand.Next(0, 4);
                characters[charToAssign].addItem(myItem);
            }

            return characters;
        }
    }
}
