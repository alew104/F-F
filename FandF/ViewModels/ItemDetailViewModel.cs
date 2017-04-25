using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FandF
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDBModel Item { get; set; }
        public ItemDetailViewModel(ItemDBModel item = null)
        {
            Title = item.Name;
            Item = item;
        }

        public ItemDBModel GetItem()
        {
            return this.Item;
        }
    }
}
