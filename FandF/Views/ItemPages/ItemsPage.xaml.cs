using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using FandF.Views;
using FandF.Services;
using System.Collections.ObjectModel;

namespace FandF
{
    public partial class ItemsPage : ContentPage
    {
        DBItemController dataAccess;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = dataAccess = new DBItemController();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ItemDBModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // The instance of CustomersDataAccess
            // is the data binding source
            this.BindingContext = this.dataAccess;
        }
    }
}
