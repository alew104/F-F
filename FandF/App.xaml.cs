using System.Collections.Generic;

using Xamarin.Forms;
using FandF.Views;

namespace FandF
{
	public partial class App : Application
	{
		public static bool UseMockDataStore = true;
		public static string BackendUrl = "https://localhost:5000";

		public static IDictionary<string, string> LoginParameters => null;

		public App()
		{
			InitializeComponent();

			if (UseMockDataStore)
				DependencyService.Register<MockDataStore>();
			else
				DependencyService.Register<CloudDataStore>();

			SetMainPage();
		}

		public static void SetMainPage()
		{
			if (!UseMockDataStore && !Settings.IsLoggedIn)
			{
				{
					
				};
			}
			else
			{
				GoToMainPage();
			}
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
				}
			};
		}
	}
}
