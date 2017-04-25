using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FandF
{
    public class MonsterDetailViewModel : BaseViewModel
    {
        public MonsterDBModel Monster { get; set; }
        public MonsterDetailViewModel(MonsterDBModel monster = null)
        {
            Title = monster.Name;
            Monster = monster;
        }

        public MonsterDBModel GetMonster()
        {
            return this.Monster;
        }
    }
}
