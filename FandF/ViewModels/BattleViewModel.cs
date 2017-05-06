using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using System.Diagnostics;

namespace FandF
{
    public class BattleViewModel : BaseViewModel//INotifyPropertyChanged
    {
        public Character C1 { get; set; }
        public Character C2 { get; set; }
        public Character C3 { get; set; }
        public Character C4 { get; set; }

        public BattleViewModel(Character ch1, Character ch2, Character ch3, Character ch4)
        {
            Title = "Battle";
            C1 = ch1;
            C2 = ch2;
            C3 = ch3;
            C4 = ch4;
        }
    }
}
