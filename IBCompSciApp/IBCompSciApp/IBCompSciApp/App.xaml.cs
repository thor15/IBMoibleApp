using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBCompSciApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ViewViewModel.MainPage.MainPage());
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
