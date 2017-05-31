using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FandF.Services;
using FandF.Views;
using System.Diagnostics;

namespace FandF.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (button.Text == "Score")
            {
                await Navigation.PushAsync(new ScorePage());
            }

            if (button.Text == "Battle")
            {
                DBCharacterController db = new DBCharacterController();
                List<CharacterDBModel> dbChars = db.getAllCharacters();
                Random rand = new Random();


                int charIndex = rand.Next(0, dbChars.Count);
                CharacterDBModel c1 = dbChars[charIndex];
                dbChars.RemoveAt(charIndex);
                charIndex = rand.Next(0, dbChars.Count);
                CharacterDBModel c2 = dbChars[charIndex];
                dbChars.RemoveAt(charIndex); 
                charIndex = rand.Next(0, dbChars.Count);
                CharacterDBModel c3 = dbChars[charIndex];
                dbChars.RemoveAt(charIndex); 
                charIndex = rand.Next(0, dbChars.Count);
                CharacterDBModel c4 = dbChars[charIndex];
                dbChars.RemoveAt(charIndex);

                Character ch1 = new Character(c1.Name, c1.Image, c1.Str, c1.Def, c1.Dex, c1.Health);
                Character ch2 = new Character(c2.Name, c2.Image, c2.Str, c2.Def, c2.Dex, c2.Health);
                Character ch3 = new Character(c3.Name, c3.Image, c3.Str, c3.Def, c3.Dex, c3.Health);
                Character ch4 = new Character(c4.Name, c4.Image, c4.Str, c4.Def, c4.Dex, c4.Health);


                await Navigation.PushAsync(new BattlePage(new BattleViewModel(ch1, ch2, ch3, ch4)));
            }

            if (button.Text == "Inventory")
            {
                await Navigation.PushAsync(new InventoryPage());
            }

            if (button.Text == "Monsters")
            {
                await Navigation.PushAsync(new MonstersPage());
            }

            if (button.Text == "Items")
            {
                await Navigation.PushAsync(new ItemsPage());
            }

            if (button.Text == "Character")
            {
                await Navigation.PushAsync(new CharacterPage());
            }
        }
    }
}
