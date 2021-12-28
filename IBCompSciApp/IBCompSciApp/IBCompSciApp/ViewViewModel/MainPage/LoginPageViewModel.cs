using MyFirstProject.ViewModels;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.MainPage
{
    class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginClicked { get; set; }

        public LoginPageViewModel()
        {
            Title = "Login";
            LoginClicked = new Command(LoginClickedAsync);
        }

        private async void LoginClickedAsync(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Home.HomePageView());
        }
    }
}
