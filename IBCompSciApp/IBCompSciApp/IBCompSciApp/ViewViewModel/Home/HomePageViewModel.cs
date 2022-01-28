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

        public ICommand SeriesClicked { get; set; }
        public ICommand BookClicked { get; set; }
        public ICommand TimesClicked { get; set; }

        public HomePageViewModel()
        {
            Title = "Home";
            SaveUsers();
            SeriesClicked = new Command(SeriesClickedAsync);
            BookClicked = new Command(BookClickedAsync);
            TimesClicked = new Command(TimesClickedAsync);
        }

        private async void SeriesClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Series.SeriesView());
        }

        private async void BookClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NextBook.NextBookView());
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
               