using SQLite;
using System.ComponentModel;
namespace FandF
{
    [Table("BatEffects")]
    public class BatEffects : INotifyPropertyChanged
    {
        public string ListName => string.Format("{0} {1}", Id, Name);
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

        public int _tier;

        public int Tier
        {
            get
            {
                return _tier;
            }
            set
            {
                this._tier = value;
                OnPropertyChanged(nameof(Tier));
            }
        }

        public string _target;

        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                this._target = value;
                OnPropertyChanged(nameof(Target));
            }
        }

        public string _attributemodified;

        public string Attribute
        {
            get
            {
                return _attributemodified;
            }
            set
            {
                this._attributemodified = value;
                OnPropertyChanged(nameof(Attribute));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}