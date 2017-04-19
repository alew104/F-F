using System;
using System.Collections.Generic;
using SQLite;

using Newtonsoft.Json;

namespace FandF
{
    public class Monster : ObservableObject
    {
        private String name;
        private int level;
        private int expValue;
        private String image;
        private int Str;
        private int Def;
        private int Dex;
        private int MaxHealth;
        private int CurrentHealth;

        //Generate a new monster with specified base stats, level, and expValue
        public Monster(String name, String image, int Str, int Def, int Dex, int Health, int level, int expValue)
        {
            this.name = name;
            this.image = image;
            this.Str = Str;
            this.Def = Def;
            this.Dex = Dex;
            this.MaxHealth = Health;
            this.CurrentHealth = this.MaxHealth;
            this.level = 1;
            this.levelUp(level - 1);
            this.expValue = expValue;
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

        public int getExpValue()
        {
            return this.expValue;
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

        public void setExpValue(int expValue)
        {
            this.expValue = expValue;
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

        //Returns true if the monster is still alive
        public bool isAlive()
        {
            return (CurrentHealth > 0);
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
    }
}
