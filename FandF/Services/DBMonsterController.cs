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
    class DBMonsterController
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<MonsterDBModel> Monsters { get; set; }

        public DBMonsterController()
        {
            database =
                DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            //database.CreateTable<Monster>();

            this.Monsters =
                new ObservableCollection<MonsterDBModel>(database.Table<MonsterDBModel>());

            // If the table is empty, initialize the collection
            if (!database.Table<MonsterDBModel>().Any())
            {
                AddNewMonster(new MonsterDBModel
                {
                    Name = "There are no monsters",
                    Image = "This is an image uri",
                });
            }
        }

        public void AddNewMonster(MonsterDBModel Monster)
        {
            this.Monsters.Add(Monster);
        }

        public int DeleteMonster(MonsterDBModel Monster)
        {
            var id = Monster.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<MonsterDBModel>(id);
                }
            }
            this.Monsters.Remove(Monster);
            return id;
        }


        public int SaveMonster(MonsterDBModel Monster)
        {
            lock (collisionLock)
            {
                if (Monster.Id != 0)
                {
                    database.Update(Monster);
                    return Monster.Id;
                }
                else
                {
                    database.Insert(Monster);
                    return Monster.Id;
                }
            }
        }
        
        // Takes an ID of a character and finds the character
        // returns a character with ID -1 if there was an error
        public MonsterDBModel getMonster(int id)
        {
            lock (collisionLock)
            {
                List<MonsterDBModel> result = database.Query<MonsterDBModel>("select * from CharacterDBModel where ?", id);
                if (result.Count == 0)
                {
                    return new MonsterDBModel {Id = -1, Name = "Query Error"};
                }
                return result[0];
            }
        }
    }
}
