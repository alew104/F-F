using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using FandF.Views;
using FandF.Services;
using System.Collections.ObjectModel;

namespace FandF
{
    public partial class MonstersPage : ContentPage
    {
        DBMonsterController dataAccess;

        public MonstersPage()
        {
            InitializeComponent();

            BindingContext = dataAccess = new DBMonsterController();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MonsterDBModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new MonsterDetailPage(new MonsterDetailViewModel(item)));

            // Manually deselect item
            MonstersListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewMonsterPage());
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
