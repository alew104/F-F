using SQLite;
using System;
using System.IO;
using FandF.iOS;
using FandF.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace FandF.iOS
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "FandF.db3";
            string personalFolder =
              System.Environment.
              GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder =
              Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}