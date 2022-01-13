using IBCompSciApp.Models;
using MyFirstProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBCompSciApp.ViewViewModel.ForgotPassword.ResetPassword
{
    class ResetPasswordViewModel : BaseViewModel
    {
        private string _passwordText;
        public string PasswordText
        {
            get
            {
                return _passwordText;
            }
            set
            {
                if(_passwordText != value)
                {
                    SetProperty(ref _passwordText, value);
                }
            }
        }

        private string _secondPasswordText;
        public string SecondPasswordText
        {
            get
            {
                return _secondPasswordText;
            }
            set
            {
                if (_secondPasswordText != value)
                {
                    SetProperty(ref _secondPasswordText, value);
                }
            }
        }

        public ICommand ResetPasswordClicked { get; set; }

        private User userPassword;

        public ResetPasswordViewModel(User user)
        {
            userPassword = user;
            ResetPasswordClicked = new Command(ResetPasswordClickedAsync);
        }

        private async void ResetPasswordClickedAsync(object obj)
        {
            if (string.IsNullOrEmpty(_passwordText.Trim()))
            {
                await Application.Current.MainPage.DisplayAlert("Sign Up", "Password Empty", "Ok");
                return;
            }

            if (!_passwordText.Equals(_secondPasswordText))
            {
                await Application.Current.MainPage.DisplayAlert("Sign Up", "Passwords do not match", "Ok");
                return;
            }

            userPassword.SetPassword(_secondPasswordText);
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
