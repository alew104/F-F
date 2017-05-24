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
    class DBBatFXController
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<BatEffects> Items { get; set; }

        public DBBatFXController()
        {
            database =
                DependencyService.Get<IDatabaseConnection>().
                DbConnection();

            this.Items =
                new ObservableCollection<BatEffects>(database.Table<BatEffects>());

            // If the table is empty, initialize the collection
        }

        public int DeleteItem(BatEffects item)
        {
            var id = item.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<BatEffects>(id);
                }
            }
            this.Items.Remove(item);
            return id;
        }


        public int SaveItem(BatEffects item)
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
        public BatEffects getItem(int id)
        {
            lock (collisionLock)
            {
                List<BatEffects> result = database.Query<BatEffects>("select * from BatEffects where id = ?", id);
                if (result.Count == 0)
                {
                    return new BatEffects { Id = -1, Name = "Query Error" };
                }
                return result[0];
            }
        }

        // returns number of entries in db 
        public int getCount()
        {
            lock (collisionLock)
            {
                List<BatEffects> result = database.Query<BatEffects>("SELECT * FROM BatEffects");
                return result.Count;
            }
        }

        public List<BatEffects> getAllItems()
        {
            return database.Query<BatEffects>("SELECT * FROM BatEffects");
        }

        public void closeDatabase()
        {
            lock (collisionLock)
            {
                database.Close();
            }
        }

        public void dropTable()
        {
            lock (collisionLock)
            {
                database.DropTable<BatEffects>();
            }
        }

        public void createTable()
        {
            lock (collisionLock)
            {
                database.CreateTable<BatEffects>();
            }
        }
    }
}
