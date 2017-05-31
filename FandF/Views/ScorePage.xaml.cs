using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using FandF.Views;
using FandF.Services;
using FandF.Models.DBModels;
using System.Collections.ObjectModel;

namespace FandF
{
    public partial class ScorePage : ContentPage
    {
        DBScoreController dataAccess;
        DBPartyController partyDB;

        public ScorePage()
        {
            InitializeComponent();

            partyDB = new DBPartyController();
            dataAccess = new DBScoreController();
            BindingContext = dataAccess = new DBScoreController();
            ScoresListView.ItemsSource = dataAccess.getAllItems();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var score = args.SelectedItem as Score;
            if (score == null)
                return;

            //Find associated character information to selected score
            List<PartyScore> partyScores = partyDB.getAllItems(score.Id);
            List<Character> myChars = new List<Character>(); 
            foreach(PartyScore partyScore in partyScores)
            {
                Character myChar = new Character(partyScore.Name, partyScore.Image);
                myChar.Level = partyScore.Levels;
                myChar.ExpPoints = partyScore.ExpPoints;
                myChars.Add(myChar);
            }

            await Navigation.PushAsync(new EndGamePage(myChars, partyScores[0].Battles));

            // Manually deselect item
            ScoresListView.SelectedItem = null;
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
