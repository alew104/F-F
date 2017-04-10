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
        private int Health;
        private List<Item> items;

        private int TotalStr;
        private int TotalDef;
        private int TotalDex;
        private int TotalHealth;

        public Character(String name, String image)
        {
            this.name = name;
            items = new List<Item>();
            this.image = image;
            initRandomStats();
        }

        public Character(String name, String image, int Str, int Def, int Dex, int Health)
        {
            this.name = name;
            items = new List<Item>();
            this.image = image;
            this.Str = Str;
            this.Def = Def;
            this.Dex = Dex;
            this.Health = Health;
        }

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

        public int getHealth()
        {
            return Health;
        }

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

        public void setHealth(int Health)
        {
            this.Health = Health;
        }

        public void addItem(Item newThing)
        {
            items.Add(newThing);

        }


        //Sets the private stat fields of Str, Dex, Def and Health to
        //random values within a reasonable range
        private void initRandomStats()
        {
            Random rand = new Random();
            setStr(rand.Next(1, 5)); //Str between 1 and 4
            setDex(rand.Next(1, 5)); //Dex between 1 and 4
            setDef(rand.Next(1, 5)); //Def between 1 and 4
            setHealth(rand.Next(20, 41)); //Health between 20 and 40
        }
    }
}
