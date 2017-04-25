using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FandF.Views;
using FandF.Services;

namespace FandF.Views
{
    public partial class MonsterDetailPage : ContentPage
    {
        MonsterDetailViewModel viewModel;
        DBMonsterController itemview;

        public MonsterDetailPage(MonsterDetailViewModel viewModel)
        {
            InitializeComponent();
            itemview = new DBMonsterController();
            BindingContext = this.viewModel = viewModel;
        }

        async void DeleteItem(object sender, EventArgs args)
        {
            MonsterDBModel monster = viewModel.GetMonster();
            itemview.DeleteMonster(monster);
            await Navigation.PopToRootAsync();
        }

        async void UpdateItem(object sender, EventArgs args)
        {
            MonsterDBModel Item = viewModel.GetMonster();
            await Navigation.PushAsync(new NewMonsterPage(Item));
        }

    }
}
