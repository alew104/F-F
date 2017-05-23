
using Xamarin.Forms;
using FandF.Views;
using FandF.Services;
using System;

namespace FandF.Views
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
		}

        async void OnButtonClicked(object sender, EventArgs args)
        {
            APIController api = new APIController();
            api.postJSON();
        }
    }
}
