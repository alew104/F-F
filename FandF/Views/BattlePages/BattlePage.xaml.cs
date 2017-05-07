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
	public partial class BattlePage : ContentPage
	{   
        BattleViewModel vm;
        Battle battle;
		public BattlePage (BattleViewModel bm)
		{
            InitializeComponent ();
            // set binding context to objects/fields in the viewmodel
            BindingContext = this.vm = bm;
            // generates initial set of monsters 
            vm.generateNewMonsters();
            // lists for the battle class to be created
            List<Monster> mList = vm.getMonsters();
            List<Character> cList = vm.getCharacters();

            // battle class created
            battle = new Battle(cList, mList);
        }
        //************************************************************
        // battle logic here
        // i assume this is where we put the simulation portion
        // ie battle class runs until characters are at 0 hp
        //************************************************************

        //simulation that runs until all characters dead
        public void runSimulation()
        {
            while(battle.isPartyAlive())
            {
                battle.takeTurn();
            }
            //FIXME: output results to screen
        }

        //For the turn by turn functionality
        public void runTurn()
        {
            battle.takeTurn();
            //FIXME: output results of turn to screen
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Text == "Attack")
            {
                runTurn();
            }
            if(button.Text == "Run to End")
            {
                runSimulation();
            }
        }
    }
}
