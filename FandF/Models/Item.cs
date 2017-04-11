using System;

using Newtonsoft.Json;

namespace FandF
{
	public class Item : ObservableObject
	{
        private int Str;
        private int Def;
        private int Dex;
        private int Health;

        public int getStr()
        {
            return Str;
        }

        public int getDef()
        {
            return Def;
        }

        public int getDex()
        {
            return Dex;
        }

        public int getHealth()
        {
            return Health;
        }

        string id = string.Empty;

		[JsonIgnore]
		public string Id
		{
			get { return id; }
			set { SetProperty(ref id, value); }
		}

		string text = string.Empty;
		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}
	}
}
