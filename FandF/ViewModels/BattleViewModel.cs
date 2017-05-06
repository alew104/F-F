using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using System.Diagnostics;
using FandF.Services;

namespace FandF
{
    public class BattleViewModel : BaseViewModel//INotifyPropertyChanged
    {
        public Character C1 { get; set; }
        public Character C2 { get; set; }
        public Character C3 { get; set; }
        public Character C4 { get; set; }

        public Monster m1 { get; set; }
        public Monster m2 { get; set; }
        public Monster m3 { get; set; }
        public Monster m4 { get; set; }

        public Battle battle { get; set; }

        public BattleViewModel(Character ch1, Character ch2, Character ch3, Character ch4)
        {
            Title = "Battle";
            C1 = ch1;
            C2 = ch2;
            C3 = ch3;
            C4 = ch4;

        }


        public List<Character> getCharacters()
        {
            return new List<Character> { C1, C2, C3, C4 };
        }

        public List<Monster> getMonsters()
        {
            return new List<Monster> { m1, m2, m3, m4 };
        }

        public List<Monster> generateNewMonsters()
        {
            m1 = generateMonster(1, C1.Level);
            m2 = generateMonster(2, C2.Level);
            m3 = generateMonster(3, C3.Level);
            m4 = generateMonster(4, C4.Level);
            return new List<Monster> { m1, m2, m3, m4 };
        }


        private Monster generateMonster(int id, int level)
        {
            DBMonsterController db = new DBMonsterController();
            MonsterDBModel m = db.getMonster(id);
            return new Monster(m.Name, m.Image, m.Str, m.Def, m.Dex, m.Health, level, m.ExpValue);
        }

    }
}
