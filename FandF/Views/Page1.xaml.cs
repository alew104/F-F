using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FandF.Views;

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
                await Navigation.PushAsync(new BattlePage());
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
