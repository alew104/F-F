using System;
using System.Collections.Generic;
using FandF.Services;

using Xamarin.Forms;

namespace FandF
{
    public partial class NewItemPage : ContentPage
    {
        public ItemDBModel Item { get; set; }
        DBItemController itemview;

        public NewItemPage()
        {
            InitializeComponent();
            itemview = new DBItemController();
            Title = "New Item";
            Item = new ItemDBModel
            {
                Name = "Item name",
                Desc = "This is a nice description"
            };

            BindingContext = this;
        }

        public NewItemPage(ItemDBModel item)
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
