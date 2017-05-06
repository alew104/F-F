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
            BindingContext = this.vm = bm;
            List<Monster> mList = vm.getMonsters();
            List<Character> cList = vm.getCharacters();

            battle = new Battle(cList, mList);
        }

        // battle logic here


	}
}
