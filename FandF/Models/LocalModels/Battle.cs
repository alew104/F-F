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
            if(myChar.items[5] != null && myChar.CurrentHealth < myChar.MaxHealth)
            {
                healingTurn(myChar);
            }
            else if(myChar.items[6] != null)
            {
                magicTurn(myChar, myMons);
            }
            else
            {
                weaponAttack(myChar, myMons);
            }

        }

        private void healingTurn(Character myChar)
        {
            //Heal player
            Item item = myChar.items[5];
            myChar.CurrentHealth = myChar.CurrentHealth + item.getHealth();
            if (myChar.CurrentHealth > myChar.MaxHealth)
                myChar.CurrentHealth = myChar.MaxHealth;

            //Use/remove item
            String itemStatus = "it can be used again!";
            myChar.items[5].setUsage(myChar.items[5].getUsage() - 1);
            if (myChar.items[5].getUsage() <= 0)
            {
                myChar.items[5] = null;
                itemStatus = "it broke!";
            }

            logLine = myChar.Name + " healed for " + item.getHealth() + " points of damage thanks to " + item._name + " and " + itemStatus;
        }

        private void magicTurn(Character myChar, Monster myMons)
        {
            Item item = myChar.items[6];
            String spellTarget = null;
            if (item.getBodyPart() == "MAGICDIRECT")
            {
                myMons.CurrentHealth = myMons.CurrentHealth + item.getHealth();
                myMons.Def = myMons.Def + item.getDef();
                myMons.Dex = myMons.Dex + item.getDex();
                myMons.Str = myMons.Str + item.getDex();
                spellTarget = myMons.Name;
            } else if(item.getBodyPart() == "MAGICALL")
            {
                spellTarget = "all monsters!";
                foreach (Monster mons in this.monsters)
                {
                    mons.CurrentHealth = myMons.CurrentHealth + item.getHealth();
                    mons.Def = myMons.Def + item.getDef();
                    mons.Dex = myMons.Dex + item.getDex();
                    mons.Str = myMons.Str + item.getDex();
                }
            }

            
            myChar.items[6].setUsage(myChar.items[6].getUsage() - 1);
            if(myChar.items[6].getUsage() <= 0)
            {
                myChar.items[6] = null;
               // itemStatus = "it broke!";
            }

            if (myMons.CurrentHealth <= 0)
            {
                myChar.gainExp(myMons.expValue);
            }


            logLine = myChar.Name + " dealed " + Math.Abs(item.getHealth()) + " points of damage by casting " + item._name + " on " + spellTarget;
        }

        private void weaponAttack(Character myChar, Monster myMons)
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
                
                if(myChar.items[4] == null)
                {
                    damageCalc = 2;
                }

                int monsHealth = myMons.CurrentHealth - damageCalc;
                if (monsHealth < 0)
                    monsHealth = 0;

                myMons.CurrentHealth = monsHealth;
                //if monster dies, character gains expvalue
                if (myMons.CurrentHealth <= 0)
                {
                    myChar.gainExp(myMons.expValue);
                }

                //Usage stuff
                Item attkItem = new Item("fists", "hard meat hammers");
                String itemStatus = "!";

                if (myChar.items[4] != null)
                {
                    attkItem = myChar.items[4];
                    myChar.items[4].setUsage(myChar.items[4].getUsage() - 1);
                    if (myChar.items[4].getUsage() <= 0)
                    {
                        myChar.items[4] = null;
                        itemStatus = " and it broke!";
                    }
                }

                if (diceRoll == 20)
                    logLine = myChar.Name + " critically hit " + myMons.Name + " for " + damageCalc + " damage using " + attkItem._name + itemStatus;
                else
                    logLine = myChar.Name + " hit " + myMons.Name + " for " + damageCalc + " damage using " + attkItem._name + itemStatus;


            }
            else if (diceRoll == 1)
            { //Critical miss
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

                //Usage stuff
                String itemStatus = "!";
                int itemIndex;
                if (myChar.items[0] != null)
                    itemIndex = 0;
                else if (myChar.items[1] != null)
                    itemIndex = 1;
                else if (myChar.items[2] != null)
                    itemIndex = 2;
                else
                    itemIndex = 3;

                if (myChar.items[itemIndex] != null)
                {
                    Item itemToStrike = myChar.items[itemIndex];
                    itemToStrike.setUsage(itemToStrike.getUsage() - 1);
                    if (itemToStrike.getUsage() <= 0)
                    {
                        myChar.items[itemIndex] = null;
                        itemStatus = " and the " + itemToStrike._name + " broke!";
                    }
                }

                if (diceRoll == 20)
                    logLine = myMons.Name + " critially attacked " + myChar.Name + " for " + damageCalc + " damage" + itemStatus;
                else
                    logLine = myMons.Name + " attacked " + myChar.Name + " for " + damageCalc + " damage" + itemStatus;
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
            int ITEMS_TO_GENERATE = 4;

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
