using IBCompSciApp.Models;
using MyFirstProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.Home
{
    class HomePageViewModel : BaseViewModel
    {

        public ICommand TimesClicked { get; set; }

        public HomePageViewModel()
        {
            Title = "Home";
            SaveUsers();
            TimesClicked = new Command(TimesClickedAsync);
        }

        private async void TimesClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ReadingTimes.ReadingTimesView());
        }

        private void SaveUsers()
        {
            CurrentUsers users = new CurrentUsers();
            string allUsers = users.ToString();
            FileManager.WriteToFile("Users.txt", allUsers);
        }
    }
}
               