using System;
using System.Collections.Generic;
using FandF.Services;

using Xamarin.Forms;

namespace FandF
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        DBItemController itemview;

        public NewItemPage()
        {
            InitializeComponent();
            itemview = new DBItemController();
            Title = "New Item";
            Item = new Item
            {
                Text = "Item name",
                Desc = "This is a nice description"
            };

            BindingContext = this;
        }

        public NewItemPage(Item item)
        {
            InitializeComponent();
            itemview = new DBItemController();
            Title = "Edit Item";
            Item = item;

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            itemview.SaveItem(Item);
            await Navigation.PopToRootAsync();
        }
    }
}
