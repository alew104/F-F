using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FandF
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        public CharacterDBModel Character { get; set; }
        public CharacterDetailViewModel(CharacterDBModel item = null)
        {
            Title = item.Name;
            Character = item;
        }

        public CharacterDBModel GetCharacter()
        {
            return this.Character;
        }
    }
}
