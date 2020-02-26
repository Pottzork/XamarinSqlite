using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CrudUsingXamarin.Interfaces;
using SQLite;

namespace CrudUsingXamarin.Droid.Implementations
{
    class SQLite_Android : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "RegistrationDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFilename);

            //Create the connection
            var conn = new SQLiteConnection(path);

            //return the database connection
            return conn;
        }
    }
}