using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using FandF.Helpers;
using FandF.Models.DBModels;

namespace FandF.Services
{
    class DBScoreController
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Score> Items { get; set; }

        public DBScoreController()
        {
            database =
                DependencyService.Get<IDatabaseConnection>().
                DbConnection();

            this.Items =
                new ObservableCollection<Score>(database.Table<Score>());

            // If the table is empty, initialize the collection
            if (!database.Table<Score>().Any())
            {
            }
        }

        public int DeleteItem(Score item)
        {
            var id = item.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Score>(id);
                }
            }
            this.Items.Remove(item);
            return id;
        }


        public int SaveItem(Score item)
        {
            lock (collisionLock)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else
                {
                    database.Insert(item);
                    return item.Id;
                }
            }
        }

        // Takes an ID of a item and finds the item
        // returns a item with ID -1 if there was an error
        public Score getItem(int id)
        {
            lock (collisionLock)
            {
                List<Score> result = database.Query<Score>("select * from Score where id = ?", id);
                if (result.Count == 0)
                {
                    return new Score { Id = -1, Points = -1 };
                }
                return result[0];
            }
        }

        // returns number of entries in db 
        public int getCount()
        {
            lock (collisionLock)
            {
                List<Score> result = database.Query<Score>("SELECT * FROM Score");
                return result.Count;
            }
        }

        public List<Score> getAllItems()
        {
            return database.Query<Score>("SELECT * FROM Score ORDER BY points DESC");
        }

        public void closeDatabase()
        {
            lock (collisionLock)
            {
                database.Close();
            }
        }
    }
}