using System;
using System.Collections.Generic;

namespace FandF
{
    public class Character : ObservableObject
    {
        public Item[] items;
        /*
         0 = HEAD
         1 = TORSO
         2 = FEET
         3 = DEFARM
         4 = ATTKARM
         5 = HEALING
         6 = MAGICALL, MAGICDIRECT
             */

		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		private int _level;
		public int Level
		{
			get
			{
				return _level;
			}
			set
			{
				this._level = value;
				OnPropertyChanged(nameof(Level));
			}
		}

		private int _expPoints;
		public int ExpPoints
		{
			get
			{
                return _expPoints;
			}
			set
			{
				this._expPoints = value;
                OnPropertyChanged(nameof(ExpPoints));
			}
		}

		private string _image;
		public string Image
		{
			get
			{
				return _image;
			}
			set
			{
				this._image = value;
				OnPropertyChanged(nameof(Image));
			}
		}

		private int _Str;
		public int Str
		{
			get
			{
				return _Str;
			}
			set
			{
				this._Str = value;
				OnPropertyChanged(nameof(Str));
			}
		}

		private int _Def;
		public int Def
		{
			get
			{
				return _Def;
			}
			set
			{
				this._Def = value;
				OnPropertyChanged(nameof(Def));
			}
		}

		private int _Dex;
		public int Dex
		{
			get
			{
				return _Dex;
			}
			set
			{
				this._Dex = value;
				OnPropertyChanged(nameof(Dex));
			}
		}

		private int _maxHealth;
		public int MaxHealth
		{
			get
			{
				return _maxHealth;
			}
			set
			{
				this._maxHealth = value;
				OnPropertyChanged(nameof(MaxHealth));
			}
		}

		private int _currentHealth;
		public int CurrentHealth
		{
			get
			{
				return _currentHealth;
			}
			set
			{
				this._currentHealth = value;
				OnPropertyChanged(nameof(CurrentHealth));
			}
		}

        public Character()
        {
            Name = "default";
            Image = "default";
        }
        //Genereate a new character with random stats
        public Character(String name, String image)
        {
            this.Name = name;
            items = new Item[7];
            this.Image = image;
            initRandomStats();
            this.CurrentHealth = this.MaxHealth;
        }

        //Generate a new character with specified stats
        public Character(String name, String image, int Str, int Def, int Dex, int Health)
        {
            this.Name = name;
            items = new Item[7];
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
            if (newThing.getBodyPart() == "HEAD")
            {
                items[0] = newThing;
            }
            else if (newThing.getBodyPart() == "TORSO")
            {
                items[1] = newThing;
            }
            else if (newThing.getBodyPart() == "FEET")
            {
                items[2] = newThing;
            }
            else if (newThing.getBodyPart() == "DEFARM")
            {
                items[3] = newThing;
            }
            else if (newThing.getBodyPart() == "ATTKARM")
            {
                items[4] = newThing;
            }
            else if (newThing.getBodyPart() == "HEALING")
            {
                items[5] = newThing;
            }
            else if (newThing.getBodyPart() == "MAGICDIRECT" || newThing.getBodyPart() == "MAGICALL")
            {
                items[6] = newThing;
            }
        }

        public bool hasItems()
        {
            for(int i = 0; i < 7; i++)
            {
                if (items[i] != null)
                    return true;
            }
            return false;
        }

        //Adds a new item to the inventory of this character
        public Item removeRandomItem()
        {
            Random rand = new Random();
            int itemToRemove = rand.Next(0, 7);
            while(items[itemToRemove] == null && hasItems())
                itemToRemove = rand.Next(0, 7);
            Item itemToReturn = items[itemToRemove];
            items[itemToRemove] = null;

            return itemToReturn;
        }

        //The following functions return the total item modifiers that are
        //attached to items in the character's inventory
        public int getItemStr()
        {
            int totalStr = 0;
            foreach (Item item in items)
            {
                if(item != null)
                    totalStr += item.getStr();
            }
            return totalStr;
        }

        public int getItemDef()
        {
            int totalDef = 0;
            foreach (Item item in items)
            {
                if (item != null)
                    totalDef += item.getDex();
            }
            return totalDef;
        }

        public int getItemDex()
        {
            int totalDex = 0;
            foreach (Item item in items)
            {
                if (item != null)
                    totalDex += item.getDex();
            }
            return totalDex;
        }

        public int getItemHealth()
        {
            int totalHealth = 0;
            foreach (Item item in items)
            {
                if (item != null)
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
                //setStr(getStr() + rand.Next(1, 5));
               // setDex(getDex() + rand.Next(1, 5));
                //setDef(getDef() + rand.Next(1, 5));
                Str = this.Str + rand.Next(1, 5);
                Dex = this.Dex + rand.Next(1, 5);
                Def = this.Def + rand.Next(1, 5);
            }

            for (int i = 0; i < numLevels; i++)
            {
                //setMaxHealth(getMaxHealth() + rand.Next(1, 11));
                MaxHealth = MaxHealth + rand.Next(1, 11);
            }

            this.Level += numLevels;
        }


        //Sets the private stat fields of Str, Dex, Def and Health to
        //random values within a reasonable range
        private void initRandomStats()
        {
            Random rand = new Random();
            //setStr(rand.Next(1, 5)); //Str between 1 and 4
            //setDex(rand.Next(1, 5)); //Dex between 1 and 4
            //setDef(rand.Next(1, 5)); //Def between 1 and 4
            //setMaxHealth(rand.Next(20, 41)); //Health between 20 and 40
            //setLevel(1);
            //setExpPoints(100);
            Str = rand.Next(1, 5);
            Dex = rand.Next(1, 5);
            Def = rand.Next(1, 5);
            MaxHealth = rand.Next(20, 41);
            Level = 1;
            ExpPoints = 100;
        }
    }
}
