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
    class DBPartyController
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<PartyScore> Items { get; set; }

        public DBPartyController()
        {
            database =
                DependencyService.Get<IDatabaseConnection>().
                DbConnection();

            this.Items =
                new ObservableCollection<PartyScore>(database.Table<PartyScore>());

            // If the table is empty, initialize the collection
            if (!database.Table<PartyScore>().Any())
            {
            }
        }

        public int DeleteItem(PartyScore item)
        {
            var id = item.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<PartyScore>(id);
                }
            }
            this.Items.Remove(item);
            return id;
        }


        public int SaveItem(PartyScore item)
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
        public PartyScore getItem(int id)
        {
            lock (collisionLock)
            {
                List<PartyScore> result = database.Query<PartyScore>("select * from PartyScore where id = ?", id);
                if (result.Count == 0)
                {
                    return new PartyScore { Id = -1, Name = "query error" };
                }
                return result[0];
            }
        }

        // returns number of entries in db 
        public int getCount()
        {
            lock (collisionLock)
            {
                List<PartyScore> result = database.Query<PartyScore>("SELECT * FROM PartyScore");
                return result.Count;
            }
        }

        public List<PartyScore> getAllItems()
        {
            return database.Query<PartyScore>("SELECT * FROM PartyScore");
        }

        public List<PartyScore> getAllItems(int id)
        {
            return database.Query<PartyScore>("SELECT * FROM PartyScore where partyid = ?", id);
        }

        public int getMaxPartyId()
        {
            lock (collisionLock)
            {
                List<PartyScore> result = database.Query<PartyScore>("SELECT * FROM PartyScore WHERE partyid = (SELECT MAX(partyid) FROM PartyScore)");
                return result[0].PartyId;
            }
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


