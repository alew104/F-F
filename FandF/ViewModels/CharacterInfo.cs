using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FandF
{
    public class CharacterInfo : BaseViewModel
    {
        public Character Ch { get; set; }
        ObservableCollection<Item> list = new ObservableCollection<Item>();
        public CharacterInfo(Character c = null)
        {
            Title = c.Name;
            Ch = c;
            for (int i = 0; i < 7; i++)
            {
                list.Add(c.items[i]);
            }
        }

        public ObservableCollection<Item> allItems()
        {
            return list;
        }
    }
}
