using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using FandF.Helpers;
using FandF.Views;
using FandF.Models.DBModels;

namespace FandF
{
    public partial class App : Application
    {
        private SQLiteConnection database;

        public App()
        {
            InitializeComponent();

            database =
               DependencyService.Get<IDatabaseConnection>().
               DbConnection();
            database.CreateTable<ItemDBModel>();
            database.CreateTable<CharacterDBModel>();
            database.CreateTable<MonsterDBModel>();
            database.CreateTable<Score>();
            database.CreateTable<PartyScore>();
            database.Close();
            GoToMainPage();
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new Page1())
                    {
                        Title = "Game Screen",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    },
                    new NavigationPage(new SettingsPage())
                    {
                        Title = "Settings",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    },
                }
            };
        }

    }
}
