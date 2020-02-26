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
    public class EditUsersPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _lastNameEntry;
        private Button _button;

        User _user = new User();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditUsersPage()
        {
            this.Title = "Edit User";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<User>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsEnabled = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "First Name";
            stackLayout.Children.Add(_nameEntry);

            _lastNameEntry = new Entry();
            _lastNameEntry.Keyboard = Keyboard.Text;
            _lastNameEntry.Placeholder = "Last Name";
            stackLayout.Children.Add(_lastNameEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            User user = new User()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                LastName = _lastNameEntry.Text
            };


            db.Update(user);
            await Navigation.PopAsync();

        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _user = (User)e.SelectedItem;
            _idEntry.Text = _user.Id.ToString();
            _nameEntry.Text = _user.Name;
            _lastNameEntry.Text = _user.LastName;

        }
    }
}