using SQLite;
using System.ComponentModel;
namespace FandF
{
    [Table("MonsterDBModel")]
    public class MonsterDBModel : INotifyPropertyChanged
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

        public string _name;
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

        public string _image;
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

        private int _expval;

        public int ExpValue
        {
            get
            {
                return _expval;
            }
            set
            {
                this._expval = value;
                OnPropertyChanged(nameof(ExpValue));
            }
        }

        /*
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
        */


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
