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
            //database.CreateTable<Item>();

            this.Items =
                new ObservableCollection<ItemDBModel>(database.Table<ItemDBModel>());

            // If the table is empty, initialize the collection
            if (!database.Table<ItemDBModel>().Any())
            {
                AddNewItem(new ItemDBModel
                {
                    Name = "There are no items",
                    Desc = "Please add an item"
                });
            }
        }

        public void AddNewItem(ItemDBModel item)
        {
            this.Items.Add(item);
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
    }
}
