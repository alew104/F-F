using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using FandF.Helpers;

namespace FandF.Services
{
    class DBCharacterController
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<CharacterDBModel> Characters { get; set; }

        public DBCharacterController()
        {
            database =
                DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            //database.CreateTable<Character>();

            this.Characters =
                new ObservableCollection<CharacterDBModel>(database.Table<CharacterDBModel>());

            // If the table is empty, initialize the collection
            if (!database.Table<CharacterDBModel>().Any())
            {
                AddNewCharacter(new CharacterDBModel
                {
                    Name = "There are no characters",
                    Image = "This is an image uri",
                });
            }
        }

        public void AddNewCharacter(CharacterDBModel Character)
        {
            this.Characters.Add(Character);
        }

        public int DeleteCharacter(CharacterDBModel Character)
        {
            var id = Character.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<CharacterDBModel>(id);
                }
            }
            this.Characters.Remove(Character);
            return id;
        }


        public int SaveCharacter(CharacterDBModel Character)
        {
            lock (collisionLock)
            {
                if (Character.Id != 0)
                {
                    database.Update(Character);
                    return Character.Id;
                }
                else
                {
                    database.Insert(Character);
                    return Character.Id;
                }
            }
        }
    }
}
