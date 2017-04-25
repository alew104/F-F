using SQLite;
using FandF.Droid;
using System.IO;
using FandF.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace FandF.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "FandF.db3";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}