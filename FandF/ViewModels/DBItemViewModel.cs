using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using FandF.Helpers;

namespace FandF.ViewModels
{
    class DBItemViewModel
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Item> Items { get; set; }

        public DBItemViewModel()
        {
            database =
                DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            //database.CreateTable<Item>();

            this.Items =
                new ObservableCollection<Item>(database.Table<Item>());

            // If the table is empty, initialize the collection
            if (!database.Table<Item>().Any())
            {
                AddNewItem(new Item
                {
                    Text = "There are no items",
                    Desc = "Please add an item"
                });
            }
        }

        public void AddNewItem(Item item)
        {
            this.Items.Add(item);
        }

        public IEnumerable<Item> GetItems()
        {
            lock (collisionLock)
            {
                return database.Query<Item>("SELECT * FROM Item").AsEnumerable();
            }
        }

        public Item getItem(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Item>().FirstOrDefault(Item => Item.Id == id);
            }
        }

        public int DeleteItem(Item item)
        {
            var id = item.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Item>(id);
                }
            }
            this.Items.Remove(item);
            return id;
        }


        public int SaveItem(Item item)
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
