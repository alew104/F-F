using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace FandF
{
    public class Character : ObservableObject
    {
        private String name;
        private int level;
        private int expPoints;
        private String image;
        private int Str;
        private int Def;
        private int Dex;
        private int MaxHealth;
        private int CurrentHealth;
        private List<Item> items;

        //Genereate a new character with random stats
        public Character(String name, String image)
        {
            this.name = name;
            items = new List<Item>();
            this.image = image;
            initRandomStats();
            this.CurrentHealth = this.MaxHealth;
        }

        //Generate a new character with specified stats
        public Character(String name, String image, int Str, int Def, int Dex, int Health)
        {
            this.name = name;
            items = new List<Item>();
            this.image = image;
            this.Str = Str;
            this.Def = Def;
            this.Dex = Dex;
            this.MaxHealth = Health;
            this.CurrentHealth = this.MaxHealth;
        }

        /**** GETTERS ****/

        public String getName()
        {
            return this.name;
        }

        public int getLevel()
        {
            return this.level;
        }

        public int getExpPoints()
        {
            return this.level;
        }

        public String getImage()
        {
            return this.image;
        }

        public int getStr()
        {
            return Str;
        }

        public int getDef()
        {
            return Def;
        }

        public int getDex()
        {
            return Dex;
        }

        public int getMaxHealth()
        {
            return MaxHealth;
        }

        public int getCurrentHealth()
        {
            return CurrentHealth;
        }

        /**** SETTERS ****/

        public void setName(String name)
        {
            this.name = name;
        }

        public void setLevel(int level)
        {
            this.level = level;
        }
        
        public void setExpPoints(int expPoints)
        {
            this.expPoints = expPoints;
        }

        public void setImage(String image)
        {
            this.image = image;
        }

        public void setStr(int Str)
        {
            this.Str = Str;
        }

        public void setDef(int Def)
        {
            this.Def = Def;
        }

        public void setDex(int Dex)
        {
            this.Dex = Dex;
        }

        public void setMaxHealth(int Health)
        {
            this.MaxHealth = Health;
        }

        public void setCurrentHealth(int currHealth)
        {
            this.CurrentHealth = currHealth;
        }

        /**** BUSINESS LOGIC ****/

     
        //Adds a new item to the inventory of this character
        public void addItem(Item newThing)
        {
            items.Add(newThing);

        }

        //The following functions return the total item modifiers that are
        //attached to items in the character's inventory
        public int getItemStr()
        {
            int totalStr = 0;
            foreach(Item item in items)
            {
                totalStr += item.getStr();
            }
            return totalStr;
        }

        public int getItemDef()
        {
            int totalDef = 0;
            foreach (Item item in items)
            {
                totalDef += item.getDex();
            }
            return totalDef;
        }

        public int getItemDex()
        {
            int totalDex = 0;
            foreach (Item item in items)
            {
                totalDex += item.getDex();
            }
            return totalDex;
        }

        public int getItemHealth()
        {
            int totalHealth = 0;
            foreach (Item item in items)
            {
                totalHealth += item.getHealth();
            }
            return totalHealth;
        }

        //Returns true if the character is still alive
        public bool isAlive()
        {
            return (CurrentHealth > 0);
        }

        //Adds experience points to the player's count, if 
        //new level (new level every 100 exp), level up
        public void gainExp(int exp)
        {
            this.expPoints += exp;
            int newLevel = (this.expPoints / 100);
            if (newLevel > this.level)
            {
                levelUp(newLevel - this.level);
            }
        }

        //Adds 1d4 to each skill stat per level
        //And 1d10 to health per level
        //Adds level
        private void levelUp(int numLevels)
        {
            Random rand = new Random();

            for (int i = 0; i < numLevels; i++)
            {
                setStr(getStr() + rand.Next(1, 5)); 
                setDex(getDex() + rand.Next(1, 5)); 
                setDef(getDef() + rand.Next(1, 5));
            }

            for (int i = 0; i < numLevels; i++)
            {
                setMaxHealth(getMaxHealth() + rand.Next(1, 11));
            }

            this.level += numLevels;
        }


        //Sets the private stat fields of Str, Dex, Def and Health to
        //random values within a reasonable range
        private void initRandomStats()
        {
            Random rand = new Random();
            setStr(rand.Next(1, 5)); //Str between 1 and 4
            setDex(rand.Next(1, 5)); //Dex between 1 and 4
            setDef(rand.Next(1, 5)); //Def between 1 and 4
            setMaxHealth(rand.Next(20, 41)); //Health between 20 and 40
        }
    }
}
