using System;
using System.Collections.Generic;
using FandF.Services;
using Xamarin.Forms;

namespace FandF
{
    public partial class NewMonsterPage : ContentPage
    {
        public MonsterDBModel Monster { get; set; }
        DBMonsterController itemview;

        public NewMonsterPage()
        {
            InitializeComponent();
            itemview = new DBMonsterController();
            Title = "New Item";
            Monster = new MonsterDBModel
            {
                Name = "monster name",
                Image = "image uri"
            };

            BindingContext = this;
        }

        public NewMonsterPage(MonsterDBModel monster)
        {
            InitializeComponent();
            itemview = new DBMonsterController();
            Title = "Edit Monster";
            Monster = monster;

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            itemview.SaveMonster(Monster);
            await Navigation.PopToRootAsync();
        }
    }
}
