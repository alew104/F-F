using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FandF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndGamePage : ContentPage
    {
        List<Character> cList;
        int numBattles { get; set; }

        public EndGamePage(List<Character> currentChars, int battles)
        {
            InitializeComponent();

			cList = currentChars;
			scoreView.ItemsSource = cList;
            numBattles = battles;
        }
    }
}
