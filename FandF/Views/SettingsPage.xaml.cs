using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FandF.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        public Label randomResultsLabel;
        public Switch randomResultsSwitch;
        public Label superResultsLabel;
        public Switch superResultsSwitch;
        public Label serverItemsLabel;
        public Switch serverItemsSwitch;
        public Label debugLabel;
        public Switch debugSwitch;
        public Label criticalHitLabel;
        public Switch criticalHitSwitch;
        public Label criticalMissLabel;
        public Switch criticalMissSwitch;
        public Label itemUseLabel;
        public Switch itemUseSwitch;
        public Label magicUseLabel;
        public Switch magicUseSwitch;
        public Label healingUseLabel;
        public Switch healingUseSwitch;
        public Label battleEventsLabel;
        public Switch battleEventsSwitch;
        protected StackLayout layout;

        public SettingsPage()
        {
            InitializeComponent();

            

            //RANDOM RESULTS
            randomResultsLabel = new Label
            {
                Text = "Random Results: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            randomResultsSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            randomResultsSwitch.Toggled += toggleRandomResults;

            

            //SUPER RESULTS
            superResultsLabel = new Label
            {
                Text = "Super Results: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            superResultsSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            superResultsSwitch.Toggled += toggleSuperResults;

            

            //SERVER ITEMS
            serverItemsLabel = new Label
            {
                Text = "Server Items: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            serverItemsSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            serverItemsSwitch.Toggled += toggleServerItems;



            

            //Had to define debug switch higher up
            debugSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            //CRITICAL HIT
            criticalHitLabel = new Label
            {
                Text = "Critical Hits: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            criticalHitSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            criticalHitSwitch.Toggled += toggleCriticalHit;

            

            //CRITICAL MISS
            criticalMissLabel = new Label
            {
                Text = "Critical Misses: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            criticalMissSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            criticalMissSwitch.Toggled += toggleCriticalMiss;

            

            //ITEM USE
            itemUseLabel = new Label
            {
                Text = "Item Usage: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            itemUseSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            itemUseSwitch.Toggled += toggleItemUse;

            

            //MAGIC USE
            magicUseLabel = new Label
            {
                Text = "Magic Usage: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            magicUseSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            magicUseSwitch.Toggled += toggleMagicUse;

            

            //HEALING USE
            healingUseLabel = new Label
            {
                Text = "Healing Usage: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            healingUseSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            healingUseSwitch.Toggled += toggleHealingUse;

            

            //BATTLE EVENTS
            battleEventsLabel = new Label
            {
                Text = "Battle Events: Off",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            battleEventsSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            battleEventsSwitch.Toggled += toggleBattleEvents;

            

            //DEBUG
            debugLabel = new Label
            {
                Text = "Debug Mode: Off",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            debugSwitch.Toggled += toggleDebug;

            



            layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 0
            };


            layout.Children.Add(serverItemsSwitch);
            layout.Children.Add(serverItemsLabel);
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            layout.Children.Add(randomResultsSwitch);
            layout.Children.Add(randomResultsLabel);
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            randomResultsSwitch.IsEnabled = false;
            layout.Children.Add(superResultsSwitch);
            layout.Children.Add(superResultsLabel);
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            superResultsSwitch.IsEnabled = false;
            layout.Children.Add(debugSwitch);
            layout.Children.Add(debugLabel);
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            layout.Children.Add(criticalHitSwitch);
            layout.Children.Add(criticalHitLabel);
            criticalHitSwitch.IsEnabled = false;
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            layout.Children.Add(criticalMissSwitch);
            layout.Children.Add(criticalMissLabel);
            criticalMissSwitch.IsEnabled = false;
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            layout.Children.Add(itemUseSwitch);
            layout.Children.Add(itemUseLabel);
            itemUseSwitch.IsEnabled = false;
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            layout.Children.Add(magicUseSwitch);
            layout.Children.Add(magicUseLabel);
            magicUseSwitch.IsEnabled = false;
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            layout.Children.Add(healingUseSwitch);
            layout.Children.Add(healingUseLabel);
            healingUseSwitch.IsEnabled = false;
            layout.Children.Add(new BoxView { HeightRequest = 5, Color = Xamarin.Forms.Color.Black, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand });
            layout.Children.Add(battleEventsSwitch);
            layout.Children.Add(battleEventsLabel);
            battleEventsSwitch.IsEnabled = false;


            ScrollView scrollView = new ScrollView { Content = layout };
            Content = scrollView;

            
        }

        void toggleRandomResults(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                randomResultsLabel.Text = "Random Results: On";
            }
            else
            {
                randomResultsLabel.Text = "Random Results: Off";
            }
        }

        void toggleSuperResults(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                superResultsLabel.Text = "Super Results: On";
            }
            else
            {
                superResultsLabel.Text = "Super Results: Off";
            }
        }

        void toggleServerItems(object sender, ToggledEventArgs e)
        {
            if (serverItemsSwitch.IsToggled == false)
            {
                randomResultsSwitch.IsToggled = false;
                randomResultsSwitch.IsEnabled = false;
                superResultsSwitch.IsToggled = false;
                superResultsSwitch.IsEnabled = false;
                serverItemsLabel.Text = "Server Items: Off";
            }
            else
            {
                randomResultsSwitch.IsEnabled = true;
                superResultsSwitch.IsEnabled = true;
                serverItemsLabel.Text = "Server Items: On";
            }
        }

        void toggleCriticalHit(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                criticalHitLabel.Text = "Critical Hits: On";
            }
            else
            {
                criticalHitLabel.Text = "Critical Hits: Off";
            }
        }

        void toggleCriticalMiss(object sender, ToggledEventArgs e)
        {
            if (criticalMissSwitch.IsToggled == true)
            {
                criticalHitSwitch.IsToggled = false;
                criticalHitSwitch.IsEnabled = false;
                criticalMissLabel.Text = "Critical Misses: On";
            }
            else if (criticalMissSwitch.IsToggled == false && debugSwitch.IsToggled == true)
            {
                criticalHitSwitch.IsEnabled = true;
                criticalMissLabel.Text = "Critical Misses: Off";
            }
        }

        void toggleItemUse(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                itemUseLabel.Text = "Item Usage: On";
            }
            else
            {
                itemUseLabel.Text = "Item Usage: Off";
            }
        }

        void toggleMagicUse(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                magicUseLabel.Text = "Magic Usage: On";
            }
            else
            {
                magicUseLabel.Text = "Magic Usage: Off";
            }
        }

        void toggleHealingUse(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                healingUseLabel.Text = "Healing Usage: On";
            }
            else
            {
                healingUseLabel.Text = "Healing Usage: Off";
            }
        }

        void toggleBattleEvents(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                battleEventsLabel.Text = "Battle Events: On";
            }
            else
            {
                battleEventsLabel.Text = "Battle Events: Off";
            }
        }

        void toggleDebug(object sender, ToggledEventArgs e)
        {
            /*if (e.Value)
            {
                debugLabel.Text = "Debug Mode: On";
            }
            else
            {
                debugLabel.Text = "Debug Mode: Off";
            }*/
            if (debugSwitch.IsToggled == false)
            {
                criticalHitSwitch.IsToggled = false;
                criticalHitSwitch.IsEnabled = false;
                criticalMissSwitch.IsToggled = false;
                criticalMissSwitch.IsEnabled = false;
                itemUseSwitch.IsToggled = false;
                itemUseSwitch.IsEnabled = false;
                magicUseSwitch.IsToggled = false;
                magicUseSwitch.IsEnabled = false;
                healingUseSwitch.IsToggled = false;
                healingUseSwitch.IsEnabled = false;
                battleEventsSwitch.IsToggled = false;
                battleEventsSwitch.IsEnabled = false;
                debugLabel.Text = "Debug Mode: Off";
            }
            else
            {
                criticalHitSwitch.IsEnabled = true;
                criticalMissSwitch.IsEnabled = true;
                itemUseSwitch.IsEnabled = true;
                magicUseSwitch.IsEnabled = true;
                healingUseSwitch.IsEnabled = true;
                battleEventsSwitch.IsEnabled = true;
                debugLabel.Text = "Debug Mode: On";
            }
        }
    }
}
