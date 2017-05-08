using System;
using System.Collections.Generic;
using SQLite;

using Newtonsoft.Json;

namespace FandF
{
    public class Monster : ObservableObject
    {
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

		private int _expValue;
		public int expValue
		{
			get
			{
                return _expValue;
			}
			set
			{
                this._expValue= value;
                OnPropertyChanged(nameof(expValue));
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

        //Generate a new monster with specified base stats, level, and expValue
        public Monster(String name, String image, int Str, int Def, int Dex, int Health, int level, int expValue)
        {
            this.Name = name;
            this.Image = image;
            this.Str = Str;
            this.Def = Def;
            this.Dex = Dex;
            this.MaxHealth = Health;
            this.CurrentHealth = this.MaxHealth;
            this.Level = 1;
            this.levelUp(level - 1);
            this.expValue = expValue;
        }

        /**** GETTERS ****/
        /**

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
        /**

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
                //setStr(getStr() + rand.Next(1, 5));
                //setDex(getDex() + rand.Next(1, 5));
                //setDef(getDef() + rand.Next(1, 5));
                Str = this.Str + rand.Next(1, 5);
                Dex = this.Dex + rand.Next(1, 5);
                Def = this.Def + rand.Next(1, 5);

            }

            for (int i = 0; i < numLevels; i++)
            {
                //setMaxHealth(getMaxHealth() + rand.Next(1, 11));
                MaxHealth = this.MaxHealth + rand.Next(1, 11);
            }

            this.Level += numLevels;
        }
    }
}
