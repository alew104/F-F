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
        private string _uri;
        private int _usage;
        private string _bodypart;

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

        public Item (string name, int str, int def, int dex, int health, string uri, int usage, string bodypart)
        {
            _name = name;
            _str = str;
            _def = def;
            _dex = dex;
            _health = health;
            _uri = uri;
            _usage = usage;
            _bodypart = bodypart;
        }

        public string getBodyPart()
        {
            return _bodypart;
        }

        public int getUsage()
        {
            return _usage;
        }

        public void setUsage(int i)
        {
            _usage = i;
        }

        public void setBodyPart(string s)
        {
            _bodypart = s;
        }

        public string getURI()
        {
            return _uri;
        }

        public void setURI(string s)
        {
            _uri = s;
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