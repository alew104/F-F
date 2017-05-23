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
    class DBItemController
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<ItemDBModel> Items { get; set; }

        public DBItemController()
        {
            database =
                DependencyService.Get<IDatabaseConnection>().
                DbConnection();

            this.Items =
                new ObservableCollection<ItemDBModel>(database.Table<ItemDBModel>());

            // If the table is empty, initialize the collection
            if (!database.Table<ItemDBModel>().Any())
            {
                ItemDBModel c1 = new ItemDBModel { Name = "Mjollnir", Desc = "Thor's very own hammer", Str = 10, Dex = 5 };
                ItemDBModel c2 = new ItemDBModel { Name = "Excalibur", Desc = "An ancient holy sword", Def = 10, Str = 5 };
                ItemDBModel c3 = new ItemDBModel { Name = "Muramasa", Desc  = "A cursed Japanese blade", Def = -10, Dex = 15, Health = -5, Str = 15 };
                ItemDBModel c4 = new ItemDBModel { Name = "Odin's Shield",Desc = "The shield used to defend Asgard",  Def = 10, Health = 5};

                SaveItem(c1);
                SaveItem(c2);
                SaveItem(c3);
                SaveItem(c4);
            }
        }

        public int DeleteItem(ItemDBModel item)
        {
            var id = item.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<ItemDBModel>(id);
                }
            }
            this.Items.Remove(item);
            return id;
        }


        public int SaveItem(ItemDBModel item)
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
        public ItemDBModel getItem(int id)
        {
            lock (collisionLock)
            {
                List<ItemDBModel> result = database.Query<ItemDBModel>("select * from ItemDBModel where id = ?", id);
                if (result.Count == 0)
                {
                    return new ItemDBModel {Id = -1, Name = "Query Error"};
                }
                return result[0];
            }
        }

        // returns number of entries in db 
        public int getCount()
        {
            lock (collisionLock)
            {
                List<ItemDBModel> result = database.Query<ItemDBModel>("SELECT * FROM ItemDBModel");
                return result.Count;
            }
        }

        public List<ItemDBModel> getAllItems()
        {
            return database.Query<ItemDBModel>("SELECT * FROM ItemDBModel");
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
                database.DropTable<ItemDBModel>();
            }
        }

        public void createTable()
        {
            lock (collisionLock)
            {
                database.CreateTable<ItemDBModel>();
            }
        }
    }
}
