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
    public class BattleViewModel : INotifyPropertyChanged
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

        public string output { get; set; }
        public string Title { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


        // the characters that are going to be in the battle
        public BattleViewModel(Character ch1, Character ch2, Character ch3, Character ch4)
        {
            Title = "Battle";
            // specify these for binding
            C1 = ch1;
            C2 = ch2;
            C3 = ch3;
            C4 = ch4;

            generateNewMonsters();

        }

        // returns the characters as a list
        public List<Character> getCharacters()
        {
            return new List<Character> { C1, C2, C3, C4 };
        }

        // returns the monsters as a list
        public List<Monster> getMonsters()
        {
            return new List<Monster> { m1, m2, m3, m4 };
        }

        // Generates new monsters for the characters to fight
        // Run this before starting a new battle
        public List<Monster> generateNewMonsters()
        {
            // setting them up for binds
            m1 = generateMonster(C1.Level);
            m2 = generateMonster(C2.Level);
            m3 = generateMonster(C3.Level);
            m4 = generateMonster(C4.Level);
            return new List<Monster> { m1, m2, m3, m4 };
        }

        public void setCharacters(List<Character> c)
        {
            C1 = c[0];
            C2 = c[1];
            C3 = c[2];
            C4 = c[3];
        }


        private Monster generateMonster(int level)
        {
            // initiate new db connection
            DBMonsterController db = new DBMonsterController();
            // get number of entries
            int max = db.getCount();
            // rng an id to grab
            Random rand = new Random();
            int id = rand.Next(1, max);
            //get that monster from the db
            MonsterDBModel m = db.getMonster(id);
            // generate new monster
            return new Monster(m.Name, m.Image, m.Str, m.Def, m.Dex, m.Health, level, m.ExpValue);
        }

    }
}
