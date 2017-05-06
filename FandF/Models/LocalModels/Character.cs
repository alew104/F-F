using System;
using System.Collections.Generic;

namespace FandF
{
    public class Character : ObservableObject
    {
        public int Id;
        public String Name { get; set; }
        public int Level { get; set; }
        public int ExpPoints { get; set; }
        public String Image { get; set; }
        public int Str { get; set; }
        public int Def { get; set; }
        public int Dex { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public List<Item> items { get; set; }

        public Character()
        {
            Name = "default";
            Image = "default";
        }
        //Genereate a new character with random stats
        public Character(String name, String image)
        {
            this.Name = name;
            items = new List<Item>();
            this.Image = image;
            initRandomStats();
            this.CurrentHealth = this.MaxHealth;
        }

        //Generate a new character with specified stats
        public Character(String name, String image, int Str, int Def, int Dex, int Health)
        {
            this.Name = name;
            items = new List<Item>();
            this.Image = image;
            this.Str = Str;
            this.Def = Def;
            this.Dex = Dex;
            this.MaxHealth = Health;
            this.CurrentHealth = this.MaxHealth;
            this.Level = 1;
            this.ExpPoints = 100;
        }

        /**** GETTERS ****/

        public String getName()
        {
            return this.Name;
        }

        public int getLevel()
        {
            return this.Level;
        }

        public int getExpPoints()
        {
            return this.ExpPoints;
        }

        public String getImage()
        {
            return this.Image;
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
            this.Name = name;
        }

        public void setLevel(int level)
        {
            this.Level = level;
        }

        public void setExpPoints(int expPoints)
        {
            this.ExpPoints = expPoints;
        }

        public void setImage(String image)
        {
            this.Image = image;
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
            foreach (Item item in items)
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
            this.ExpPoints += exp;
            int newLevel = (this.ExpPoints / 100);
            if (newLevel > this.Level)
            {
                levelUp(newLevel - this.Level);
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

            this.Level += numLevels;
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
            setLevel(1);
            setExpPoints(100);
        }
    }
}
