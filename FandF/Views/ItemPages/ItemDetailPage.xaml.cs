using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FandF.Views;
using FandF.Services;

namespace FandF.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        DBItemController itemview;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            itemview = new DBItemController();
            BindingContext = this.viewModel = viewModel;
        }

        async void DeleteItem(object sender, EventArgs args)
        {
            ItemDBModel Item = viewModel.GetItem();
            itemview.DeleteItem(Item);
            await Navigation.PopToRootAsync();
        }

        async void UpdateItem(object sender, EventArgs args)
        {
            ItemDBModel Item = viewModel.GetItem();
            await Navigation.PushAsync(new NewItemPage(Item));
        }

    }
}
