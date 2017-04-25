using System;
using System.Collections.Generic;
using FandF.Services;
using Xamarin.Forms;

namespace FandF
{
    public partial class NewCharacterPage : ContentPage
    {
        public CharacterDBModel Character { get; set; }
        DBCharacterController itemview;

        public NewCharacterPage()
        {
            InitializeComponent();
            itemview = new DBCharacterController();
            Title = "New Item";
            Character = new CharacterDBModel
            {
                Name = "class name",
                Image = "image uri"
            };

            BindingContext = this;
        }

        public NewCharacterPage(CharacterDBModel item)
        {
            InitializeComponent();
            itemview = new DBCharacterController();
            Title = "Edit Character";
            Character = item;

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            itemview.SaveCharacter(Character);
            await Navigation.PopToRootAsync();
        }
    }
}
