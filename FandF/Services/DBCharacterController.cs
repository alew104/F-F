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

            // initialize db with initial characters


            // If the table is empty, initialize the collection
            if (!database.Table<CharacterDBModel>().Any())
            {
                CharacterDBModel c1 = new CharacterDBModel { Name = "Thief", Def = 5, Dex = 20, Health = 25, Str = 10 };
                CharacterDBModel c2 = new CharacterDBModel { Name = "Knight", Def = 20, Dex = 10, Health = 40, Str = 10 };
                CharacterDBModel c3 = new CharacterDBModel { Name = "Archer", Def = 10, Dex = 15, Health = 25, Str = 15 };
                CharacterDBModel c4 = new CharacterDBModel { Name = "Mage", Def = 5, Dex = 5, Health = 15, Str = 20 };

                SaveCharacter(c1);
                SaveCharacter(c2);
                SaveCharacter(c3);
                SaveCharacter(c4);
            }
        }
        public void AddNewCharacter(CharacterDBModel Character)
        {
            this.Characters.Add(Character);
        }

        // Delete a character
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

        // Update/Insert character
        // if ID is null it is a new character
        // if ID is not null then it is a character that needs to be updated
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

        // Takes an ID of a character and finds the character
        // returns a character with ID -1 if there was an error
        public CharacterDBModel getCharacter(int id)
        {
            lock (collisionLock)
            {
                List<CharacterDBModel> result = database.Query<CharacterDBModel>("select * from CharacterDBModel where id = ?", id);
                if (result.Count == 0)
                {
                    return new CharacterDBModel {Id = -1, Name = "Query Error"};
                }
                return result[0];
            }
        }


    }
}
