using SQLite;
using System.ComponentModel;
namespace FandF
{
    public class Item : ObservableObject
    {

        public string _name {get; set;}
        public string _desc;
        private int _str;
        private int _def;
        private int _dex;
        private int _health;

        public Item()
        {

        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        public Item(string name, string desc)
        {
            _name = name;
            _desc = desc;
        }

        public int getStr()
        {
            return _str;
        }

        public int getDex()
        {
            return _dex;
        }

        public int getDef()
        {
            return _def;
        }

        public int getHealth()
        {
            return _health;
        }

        public void setStr(int val)
        {
            _str = val;
        }
        public void setDef(int val)
        {
            _def = val;
        }
        public void setDex(int val)
        {
            _dex = val;
        }

        public void setHealth(int val)
        {
            _health = val;
        }
    }
}