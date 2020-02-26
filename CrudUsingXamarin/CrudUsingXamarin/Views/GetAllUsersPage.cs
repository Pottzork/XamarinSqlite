using CrudUsingXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CrudUsingXamarin.Views
{
    public class GetAllUsersPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myDB.db3");
       
        public GetAllUsersPage()
        {

            this.Title = "Users";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<User>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}