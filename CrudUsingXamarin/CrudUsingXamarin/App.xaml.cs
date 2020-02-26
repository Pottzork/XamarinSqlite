using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrudUsingXamarin.Views;


namespace CrudUsingXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
