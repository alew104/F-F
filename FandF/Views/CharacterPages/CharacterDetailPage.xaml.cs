using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FandF.Views;
using FandF.Services;

namespace FandF.Views
{
    public partial class CharacterDetailPage : ContentPage
    {
        CharacterDetailViewModel viewModel;
        DBCharacterController itemview;

        public CharacterDetailPage(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();
            itemview = new DBCharacterController();
            BindingContext = this.viewModel = viewModel;
        }

        async void DeleteItem(object sender, EventArgs args)
        {
            CharacterDBModel Item = viewModel.GetCharacter();
            itemview.DeleteCharacter(Item);
            await Navigation.PopToRootAsync();
        }

        async void UpdateItem(object sender, EventArgs args)
        {
            CharacterDBModel Item = viewModel.GetCharacter();
            await Navigation.PushAsync(new NewCharacterPage(Item));
        }

    }
}
