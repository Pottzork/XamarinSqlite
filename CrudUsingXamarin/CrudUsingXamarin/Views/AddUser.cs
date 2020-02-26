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
    public class AddUser : ContentPage
    {
        private Entry _nameEntry;
        private Entry _lastNameEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public AddUser()
        {
            this.Title = "Add User";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "First Name";
            stackLayout.Children.Add(_nameEntry);

            _lastNameEntry = new Entry();
            _lastNameEntry.Keyboard = Keyboard.Text;
            _lastNameEntry.Placeholder = "First Name";
            stackLayout.Children.Add(_lastNameEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);


            Content = stackLayout;


        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<User>();

            var maxPk = db.Table<User>().OrderByDescending(c => c.Id).FirstOrDefault();

            User user = new User()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Name = _nameEntry.Text,
                LastName = _lastNameEntry.Text
            };

            db.Insert(user);
            await DisplayAlert(null, user.Name + " Saved", "Ok");
            await Navigation.PopAsync();
        }
    }
}