using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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
            //vm.generateNewMonsters(); now this is in battle view model
            // lists for the battle class to be created
            List<Monster> mList = vm.getMonsters();
            List<Character> cList = vm.getCharacters();

            //used these to check if monsters were created in the view model and put into the list
            //Debug.WriteLine(String.Format("Hello {0} {1}", vm.C1.Name, vm.m1.Name));
            //Debug.WriteLine(String.Format("Hello {0} {1}", cList[0].Name, mList[0].Name));
			
            // battle class created
			battle = new Battle(cList, mList);
        }

        // battle logic here
        // i assume this is where we put the simulation portion
        // ie battle class runs until characters are at 0 hp

        //*************************************************************************
        //ALL THE STUFF THAT LUKE ADDED THAT MIGHT NEED TO GO SOMEWHERE ELSE!!!!
        //ALL CODE BELOW MAY NEED TO BE MOVED ELSEWHERE
        //PENDING TEAM APPROVAL
        //*************************************************************************

        //simulation that runs until all characters dead
        public void runSimulation()
        {
            while(battle.isPartyAlive())
            {
                if(!battle.areMonstersAlive())
                {
                    //FIXME: Distribute items, loot, exp, etc.

                    //need to make a new instance of a battle
                    //with new monsters, but the same characters...
                    vm.generateNewMonsters();
                    List<Monster> mList = vm.getMonsters();
                    List<Character> cList = vm.getCharacters(); //I think we want to get the characters from the previous battle object,
                                                                //So that their health doesnt magically regenerate when monsters die

                    //battle class reinstantiated
                    battle = new Battle(cList, mList);
                }
                battle.takeTurn();
            }
            //FIXME: output results to screen
        }

        //For the turn by turn functionality
        public void runTurn()
        {
            
            if(!battle.areMonstersAlive())
            {
                //FIXME: need to make a new instance of a battle
                //with new monsters, but the same characters...

            }
            battle.takeTurn();
            //FIXME: output results of turn to screen
        }

        //SEE BATTLEPAGE.XAML FOR BUTTONS I ADDED
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
