using SQLite;
using System.ComponentModel;
namespace FandF
{
    [Table("Item")]
    public class Item : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                this._text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public string _desc;
        public string Desc
        {
            get
            {
                return _desc;
            }
            set
            {
                this._desc = value;
                OnPropertyChanged(nameof(Desc));
            }
        }
        private int _str;

        public int Str
        {
            get
            {
                return _str;
            }
            set
            {
                this._str = value;
                OnPropertyChanged(nameof(Str));
            }
        }

        private int _def;
        public int Def
        {
            get
            {
                return _def;
            }
            set
            {
                this._def = value;
                OnPropertyChanged(nameof(Def));
            }
        }

        private int _dex;
        public int Dex
        {
            get
            {
                return _dex;
            }
            set
            {
                this._dex = value;
                OnPropertyChanged(nameof(Dex));
            }
        }

        private int _health;
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                this._health = value;
                OnPropertyChanged(nameof(Health));
            }
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


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}